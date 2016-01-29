﻿ /* Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel;

namespace AgGateway.ADAPT.Visualizer
{
    public partial class MainForm : Form
    {
        private readonly DataProvider _dataProvider;
        private readonly DataProcessor _dataProcessor;
        private ApplicationDataModel.ApplicationDataModel _applicationDataModel;

        public MainForm()
        {
            InitializeComponent();

            _dataProvider = new DataProvider();
            _dataProcessor = new DataProcessor(_tabPageSpatial, _dataGridViewRawData, _dataGridViewTotals);
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
        }

        private void _buttonLoadDatacard_Click(object sender, EventArgs e)
        {
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
                ImportDataCard(datacardPath);
            }
        }

        private void _buttonExportDatacard_Click(object sender, EventArgs e)
        {
            var pluginName = (string)_comboBoxPlugins.SelectedItem;
            var plugin = _dataProvider.GetPlugin(pluginName);

            if (_applicationDataModel == null || plugin == null)
            {
                MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                return;
            }

            DataProvider.Export(plugin, _applicationDataModel, _textBoxInitializeString.Text, GetExportDirectory());
        }

        private void _treeViewMetadata_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            using (var g = _tabPageSpatial.CreateGraphics())
            {
                g.Clear(Color.White);
            }

            var treeNode = e.Node;

            _tabPageSpatial.Tag = treeNode.Tag == null ? treeNode.Tag : treeNode;

            if (treeNode.Tag == null)
            {
                return;
            }

            ProcessData(treeNode);
        }

        private string GetExportDirectory()
        {
            return _textBoxExportPath.Text != string.Empty ? _textBoxExportPath.Text : "C:\\newfile.zip";
        }

        private void ImportDataCard(string datacardPath)
        {
            _treeViewMetadata.Nodes.Clear();

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
            {
                return;
            }

            foreach (var propertyInfo in element.GetType().GetProperties())
            {
                ParseProperty(element, parentNode, propertyInfo);
            }
        }

        private void ParseProperty(object element, TreeNode parentNode, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (propertyType.IsGenericType && underlyingType != null)
            {
                propertyType = underlyingType;
            }

            var propertyValue = propertyInfo.GetValue(element, null);

            if (propertyType.IsPrimitive || propertyType == typeof (string)) 
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
                foreach (var child in collection)
                {
                    var node = collectionNode.Nodes.Add(child.ToString());
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
                _dataProcessor.ProcessBoundary(treeNode.Tag as FieldBoundary);
            }
            else if (treeNode.Tag is GuidanceGroup)
            {
                _dataProcessor.ProcessGuidance(treeNode.Tag as GuidanceGroup, _applicationDataModel.Catalog.GuidancePatterns);
            }
            else if (treeNode.Tag is LoggedData)
            {
                _dataProcessor.ProcessLoggedData(treeNode.Tag as LoggedData);
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
    }
}
