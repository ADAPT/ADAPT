using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.Visualizer.UI;

namespace AgGateway.ADAPT.Visualizer
{
    public class Model
    {
        private readonly Action<State, string> _updateStatusAction;

        public enum State
        {
            StateIdle,
            StateImporting,
            StateExporting
        };

        private readonly DataProvider _dataProvider;
        private int _admIndex;
        private static TreeView _treeView;

        private State _currentState;
        public State CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                if (_currentState == State.StateImporting && value == State.StateIdle)
                    ShowMessageBox(@"Import Complete");

                if(_currentState == State.StateExporting && value == State.StateIdle)
                    ShowMessageBox(@"Data exported successfully.");

                _currentState = value;
            }
        }

        public Model(Action<State, string> updateStatusAction)
        {
            _updateStatusAction = updateStatusAction;
            _dataProvider = new DataProvider();
            ApplicationDataModels = new List<ApplicationDataModel.ADM.ApplicationDataModel>();

            CurrentState = State.StateIdle;
        }

        public IList<ApplicationDataModel.ADM.ApplicationDataModel> ApplicationDataModels { get; private set; }

        public ObservableCollection<string> AvailablePlugins()
        {
            if (_dataProvider == null)
                return new ObservableCollection<string>();

            return new ObservableCollection<string>(_dataProvider.AvailablePlugins);
        }

        public ObservableCollection<string> LoadPlugins(TextBox textBox)
        {
            var availablePlugins = new ObservableCollection<string>();

            if (IsValid(textBox, "Plugin"))
            {
                _dataProvider.Initialize(textBox.Text);

                if (_dataProvider.AvailablePlugins != null)
                {
                    availablePlugins = _dataProvider.AvailablePlugins;
                }
            }

            return availablePlugins;
        }

        public bool ArePluginsLoaded(TextBox pluginPathTextBox)
        {
            if (_dataProvider.PluginFactory == null)
            {
                MessageBox.Show(@"Select a valid plugin path and load them before importing a datacard.");
                pluginPathTextBox.Focus();
                return false;
            }

            return true;
        }

        public void Export(string pluginName, string initializeString, string exportPath, string cardProfileSelectedText)
        {
            try
            {
                var plugin = _dataProvider.GetPlugin(pluginName);

                if (ApplicationDataModels == null || ApplicationDataModels.Count == 0 || plugin == null)
                {
                    MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                    return;
                }

                Task.Run(() =>
                {

                    CurrentState = State.StateExporting;
                    _updateStatusAction(CurrentState, "Export in Progress");

                    var selectApplicationDataModel =
                        ApplicationDataModels.First(
                            x => x.Catalog.Description.ToLower().Equals(cardProfileSelectedText.ToLower()));
                    DataProvider.Export(plugin, selectApplicationDataModel, initializeString,
                        GetExportDirectory(exportPath));

                    CurrentState = State.StateIdle;
                    _updateStatusAction(CurrentState, "Done");
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void Import(TextBox dataCardTextBox, string initializeString, TreeView treeView)
        {
            if (IsValid(dataCardTextBox, "Datacard"))
            {
                CurrentState = State.StateImporting;
                treeView.BeginUpdate();

                ImportDataCard(dataCardTextBox.Text, initializeString, treeView);

                treeView.EndUpdate();
            }   
        }

        private void ShowMessageBox(string message)
        {
            _treeView.Invoke(new Action(() => MessageBox.Show(message)));
        }

        private void ImportDataCard(string datacardPath, string initializeString, TreeView treeView)
        {
            _treeView = treeView;

            Task.Run(() =>
            {
                _updateStatusAction(CurrentState, "Starting Import");

                ApplicationDataModels = _dataProvider.Import(datacardPath, initializeString);
                if (ApplicationDataModels == null || ApplicationDataModels.Count == 0)
                {
                    MessageBox.Show(@"Not supported data format.");
                    CurrentState = State.StateIdle;
                    _updateStatusAction(CurrentState, "Done");
                    return;
                }

                _admIndex = 0;
                for (; _admIndex < ApplicationDataModels.Count; _admIndex++)
                {
                    var applicationDataModel = ApplicationDataModels[_admIndex];

                    applicationDataModel.Documents.LoggedData.SelectMany(x => x.OperationData.ToList()).ToList();
                    
                    var parentNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => treeView.Nodes.Add("ApplicationDataModel")));

                    AddNode(applicationDataModel, parentNode);
                }
                
                CurrentState = State.StateIdle;
                _updateStatusAction(CurrentState, "Done");
                
            });

            
        }


        private void AddNode(object element, TreeNode parentNode)
        {
            if (element == null)
                return;

            var type = element.GetType();
            type = CheckType(ref element, type);
            foreach (var propertyInfo in type.GetProperties())
            {
                ParseProperty(element, parentNode, propertyInfo);
            }
        }

       

        private static Type CheckType(ref object element, Type type)
        {
            if (!type.Namespace.StartsWith("System") && !type.Namespace.StartsWith("AgGateway.ADAPT.ApplicationDataModel"))
            {
                type = type.BaseType;
                element = Convert.ChangeType(element, type);
            }
            return type;
        }

        private void ParseProperty(object element, TreeNode parentNode, PropertyInfo propertyInfo)
        {
            if (element is Func<object> || element is Func<int, object> || element is Action)
                return;

            var propertyType = propertyInfo.PropertyType;

            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (propertyType.IsGenericType && underlyingType != null)
            {
                propertyType = underlyingType;
            }

            var propertyValue = propertyInfo.GetIndexParameters().Any() ? null : propertyInfo.GetValue(element, null);

            propertyType = CheckType(ref propertyValue, propertyType);

            if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || propertyType.IsEnum)
            {
                _treeView.Invoke(new Action(() => parentNode.Nodes.Add(String.Format(@"{0}: {1}", propertyInfo.Name,
                    propertyValue))));
            }
            else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
            {
                ParseArrays(parentNode, propertyInfo, propertyValue);
            }
            else
            {
                var childNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => parentNode.Nodes.Add(propertyInfo.Name)));
                parentNode.Tag = new ObjectWithIndex(_admIndex, element);

                AddNode(propertyValue, childNode);
            }
        }


        private void ParseArrays(TreeNode parentNode, PropertyInfo propertyInfo, object propertyValue)
        {

            _updateStatusAction(CurrentState, "Parsing: " + propertyInfo.Name);

            var collectionNode = (TreeNode)_treeView.Invoke(new Func<TreeNode>(() => parentNode.Nodes.Add(propertyInfo.Name)));
            var collection = (IEnumerable)propertyValue;
            if (collection != null)
            {
                if (collection is IEnumerable<WorkingData> || collection is IEnumerable<DeviceElementUse> || collection is IEnumerable<DataLogTrigger>)
                    return;

                foreach (var child in collection)
                {
                    var childObject = child;
                    var type = CheckType(ref childObject, childObject.GetType());
                    var node = new TreeNode(type.Name)
                    {
                        Tag = new ObjectWithIndex(_admIndex, child)
                    };
                    _treeView.Invoke(new Action(() => collectionNode.Nodes.Add(node)));
                    AddNode(child, node);
                }
            }
        }
        
        private bool IsValid(TextBox textBox, string text)
        {
            if (textBox.Text == null || !Directory.Exists(textBox.Text))
            {
                MessageBox.Show(String.Format(@"Select a valid {0} path.", text));
                textBox.Focus();
                return false;
            }

            return true;
        }

        private string GetExportDirectory(string exportPath)
        {
            return exportPath != String.Empty ? exportPath : "C:\\newfile.zip";
        }

        public static void BrowseFolderDialog(IWin32Window parent, TextBox textBox)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog(parent) == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        public void WriteCsvFile(string fileName, DataGridView dataGridView)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                var sb = new StringBuilder();

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (i != 0)
                        sb.Append(",");

                    sb.Append(dataGridView.Columns[i].Name);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    sb.Append("\n");
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (j != 0)
                            sb.Append(",");

                        sb.Append(row.Cells[j].Value);
                    }
                }

                streamWriter.WriteLine(sb.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}