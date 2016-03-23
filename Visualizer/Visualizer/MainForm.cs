/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.Visualizer
{
    public partial class MainForm : Form
    {
        private readonly BoundaryProcessor _boundaryProcessor;
        private readonly DataProvider _dataProvider;
        private readonly GuidanceProcessor _guidanceProcessor;
        private readonly OperationDataProcessor _operationDataProcessor;
        private ApplicationDataModel.ADM.ApplicationDataModel _applicationDataModel;

        public MainForm()
        {
            InitializeComponent();

            _dataProvider = new DataProvider();

            _operationDataProcessor = new OperationDataProcessor();
            _boundaryProcessor = new BoundaryProcessor(_tabPageSpatial);
            _guidanceProcessor = new GuidanceProcessor(_tabPageSpatial);
        }

        private void _buttonBrowsePluginLocation_Click(object sender, EventArgs e)
        {
            BrowseFolderDialog(_textBoxPluginPath);
        }

        private void _buttonBrowseDatacard_Click(object sender, EventArgs e)
        {
            BrowseFolderDialog(_textBoxDatacardPath);
        }

        private void _buttonBrowseExportPath_Click(object sender, EventArgs e)
        {
            BrowseFolderDialog(_textBoxExportPath);
        }

        private void _buttonLoadPlugins_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var textBox = _textBoxPluginPath;

            if (IsValid(textBox, "Plugin"))
            {
                _dataProvider.Initialize(textBox.Text);

                if (_dataProvider.AvailablePlugins != null)
                {
                    object[] availablePlugins = _dataProvider.AvailablePlugins.ToArray();

                    _comboBoxPlugins.Items.Clear();
                    _comboBoxPlugins.Items.Add("(Select)");
                    _comboBoxPlugins.SelectedIndex = 0;
                    _comboBoxPlugins.Items.AddRange(availablePlugins);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void _buttonLoadDatacard_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClearForm();

            var textBox = _textBoxDatacardPath;
            var datacardPath = textBox.Text;

            if (_dataProvider.PluginFactory == null)
            {
                MessageBox.Show(@"Select a valid plugin path and load them before importing a datacard.");
                _textBoxPluginPath.Focus();
                return;
            }

            if (IsValid(textBox, "Datacard"))
            {
                _treeViewMetadata.BeginUpdate();

                ImportDataCard(datacardPath);

                _treeViewMetadata.EndUpdate();
            }
            Cursor.Current = Cursors.Default;
        }

        private void _buttonExportDatacard_Click(object sender, EventArgs e)
        {
            try
            {
                var pluginName = (string) _comboBoxPlugins.SelectedItem;
                var plugin = _dataProvider.GetPlugin(pluginName);

                if (_applicationDataModel == null || plugin == null)
                {
                    MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                    return;
                }

                DataProvider.Export(plugin, _applicationDataModel, _textBoxInitializeString.Text, GetExportDirectory());

                MessageBox.Show(@"Data exported successfully.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void _treeViewMetadata_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _tabControlViewer.SelectTab(_tabPageSpatial);

            using (var g = _tabPageSpatial.CreateGraphics())
            {
                g.Clear(Color.White);
            }
            _dataGridViewRawData.DataSource = null;
            _dataGridViewTotals.DataSource = null;

            var treeNode = e.Node;

            _tabPageSpatial.Tag = treeNode.Tag == null ? treeNode.Tag : treeNode;

            if (treeNode.Tag == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            ProcessData(treeNode);
            Cursor.Current = Cursors.Default;
        }

        private void ClearForm()
        {
            _treeViewMetadata.Nodes.Clear();
            _dataGridViewRawData.Columns.Clear();
        }

        private string GetExportDirectory()
        {
            return _textBoxExportPath.Text != string.Empty ? _textBoxExportPath.Text : "C:\\newfile.zip";
        }

        private void ImportDataCard(string datacardPath)
        {
            _applicationDataModel = _dataProvider.Import(datacardPath, _textBoxInitializeString.Text);
            if (_applicationDataModel == null)
            {
                MessageBox.Show(@"Not supported data format.");
                return;
            }

            var parentNode = _treeViewMetadata.Nodes.Add("ApplicationDataModel");
            AddNode(_applicationDataModel, parentNode);
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

            if (propertyType.IsPrimitive || propertyType == typeof (string) || propertyType == typeof (DateTime) || propertyType.IsEnum)
            {
                parentNode.Nodes.Add(string.Format(@"{0}: {1}", propertyInfo.Name, propertyValue));
            }
            else if (typeof (IEnumerable).IsAssignableFrom(propertyType))
            {
                ParseArrays(parentNode, propertyInfo, propertyValue);
            }
            else
            {
                var childNode = parentNode.Nodes.Add(propertyInfo.Name);
                parentNode.Tag = element;
                AddNode(propertyValue, childNode);
            }
        }

        private void ParseArrays(TreeNode parentNode, PropertyInfo propertyInfo, object propertyValue)
        {
            var collectionNode = parentNode.Nodes.Add(propertyInfo.Name);
            var collection = (IEnumerable) propertyValue;
            if (collection != null)
            {
                if(collection is IEnumerable<Meter> || collection is IEnumerable<Section> || collection is IEnumerable<DataLogTrigger>)
                    return;

                foreach (var child in collection)
                {
                    var node = new TreeNode(child.ToString()) {Tag = child};
                    collectionNode.Nodes.Add(node);
                    AddNode(child, node);
                }
            }
        }

        private void BrowseFolderDialog(TextBox textBox)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private static bool IsValid(TextBox textBox, string text)
        {
            if (textBox.Text == null || !Directory.Exists(textBox.Text))
            {
                MessageBox.Show(string.Format(@"Select a valid {0} path.", text));
                textBox.Focus();
                return false;
            }

            return true;
        }

        private void ProcessData(TreeNode treeNode)
        {
            if (treeNode.Tag is FieldBoundary)
            {
                _boundaryProcessor.ProcessBoundary(treeNode.Tag as FieldBoundary);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (treeNode.Tag is GuidanceGroup)
            {
                _guidanceProcessor.ProcessGuidance(treeNode.Tag as GuidanceGroup, _applicationDataModel.Catalog.GuidancePatterns);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (treeNode.Tag is GuidancePattern)
            {
                _guidanceProcessor.ProccessGuidancePattern(treeNode.Tag as GuidancePattern);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (treeNode.Tag is OperationData)
            {
                _dataGridViewRawData.DataSource = _operationDataProcessor.ProcessOperationData(treeNode.Tag as OperationData);
                _tabControlViewer.SelectedTab = _tabPageRawData;
            }
        }

        private void _tabPageSpatial_Paint(object sender, PaintEventArgs e)
        {
            if (_tabPageSpatial.Tag == null)
            {
                return;
            }

            ProcessData(_tabPageSpatial.Tag as TreeNode);
        }

        private void _buttonExportRawData_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".csv", 
                Filter = "CSV File (.csv)|*.csv"
            };

            var result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                WriteCsvFile(saveFileDialog);
            }
        }

        private void WriteCsvFile(SaveFileDialog saveFileDialog)
        {
            using (var streamWriter = new StreamWriter(saveFileDialog.FileName))
            {
                var sb = new StringBuilder();

                for (int i = 0; i < _dataGridViewRawData.Columns.Count; i++)
                {
                    if (i != 0)
                        sb.Append(",");

                    sb.Append(_dataGridViewRawData.Columns[i].Name);
                }

                foreach (DataGridViewRow row in _dataGridViewRawData.Rows)
                {
                    sb.Append("\n");
                    for (int j = 0; j < _dataGridViewRawData.Columns.Count; j++)
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