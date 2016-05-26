using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.Visualizer.UI;

namespace AgGateway.ADAPT.Visualizer
{
    public class Model
    {
        private readonly DataProvider _dataProvider;
        private int _admIndex;

        public Model()
        {
            _dataProvider = new DataProvider();
            ApplicationDataModels = new List<ApplicationDataModel.ADM.ApplicationDataModel>();
        }

        public IList<ApplicationDataModel.ADM.ApplicationDataModel> ApplicationDataModels { get; private set; }

        public string[] LoadPlugins(TextBox textBox)
        {
            var availablePlugins = new List<string>();

            if (IsValid(textBox, "Plugin"))
            {
                _dataProvider.Initialize(textBox.Text);

                if (_dataProvider.AvailablePlugins != null)
                {
                    availablePlugins = _dataProvider.AvailablePlugins;
                }
            }

            return availablePlugins.ToArray();
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

        public void Export(string pluginName, string initializeString, string exportPath)
        {
            try
            {
                var plugin = _dataProvider.GetPlugin(pluginName);

                if (ApplicationDataModels == null || ApplicationDataModels.Count == 0 || plugin == null)
                {
                    MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                    return;
                }

                foreach (var applicationDataModel in ApplicationDataModels)
                {
                    DataProvider.Export(plugin, applicationDataModel, initializeString, GetExportDirectory(exportPath));
                }

                MessageBox.Show(@"Data exported successfully.");
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
                treeView.BeginUpdate();

                ImportDataCard(dataCardTextBox.Text, initializeString, treeView);

                treeView.EndUpdate();
            }
        }

        private void ImportDataCard(string datacardPath, string initializeString, TreeView treeView)
        {
            ApplicationDataModels = _dataProvider.Import(datacardPath, initializeString);
            if (ApplicationDataModels == null || ApplicationDataModels.Count == 0)
            {
                MessageBox.Show(@"Not supported data format.");
                return;
            }

            _admIndex = 0;
            for (; _admIndex < ApplicationDataModels.Count; _admIndex++)
            {
                var applicationDataModel = ApplicationDataModels[_admIndex];
                var parentNode = treeView.Nodes.Add("ApplicationDataModel");
                AddNode(applicationDataModel, parentNode);
            }
        }

        private void AddNode(object element, TreeNode parentNode)
        {
            if (element == null)
                return;

            foreach (var propertyInfo in element.GetType().GetProperties())
            {
                ParseProperty(element, parentNode, propertyInfo);
            }
        }

        private void ParseProperty(object element, TreeNode parentNode, PropertyInfo propertyInfo)
        {
            if (element is Func<object> || element is Func<int, object>)
                return;

            var propertyType = propertyInfo.PropertyType;

            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (propertyType.IsGenericType && underlyingType != null)
            {
                propertyType = underlyingType;
            }

            var propertyValue = propertyInfo.GetIndexParameters().Any() ? null : propertyInfo.GetValue(element, null);

            if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime) || propertyType.IsEnum)
            {
                parentNode.Nodes.Add(String.Format(@"{0}: {1}", propertyInfo.Name, propertyValue));
            }
            else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
            {
                ParseArrays(parentNode, propertyInfo, propertyValue);
            }
            else
            {
                var childNode = parentNode.Nodes.Add(propertyInfo.Name);
                parentNode.Tag = new ObjectWithIndex(_admIndex, element);
                AddNode(propertyValue, childNode);
            }
        }

        private void ParseArrays(TreeNode parentNode, PropertyInfo propertyInfo, object propertyValue)
        {
            var collectionNode = parentNode.Nodes.Add(propertyInfo.Name);
            var collection = (IEnumerable)propertyValue;
            if (collection != null)
            {
                if (collection is IEnumerable<Meter> || collection is IEnumerable<Section> || collection is IEnumerable<DataLogTrigger>)
                    return;

                foreach (var child in collection)
                {
                    var node = new TreeNode(child.ToString())
                    {
                        Tag = new ObjectWithIndex(_admIndex, child)
                    };
                    collectionNode.Nodes.Add(node);
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