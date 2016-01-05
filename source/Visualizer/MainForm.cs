 /* Copyright (C) 2015 AgGateway and ADAPT Contributors
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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.PluginManager;

namespace Visualizer
{
    public partial class MainForm : Form
    {
        private PluginFactory _pluginFactory;
        private ApplicationDataModel _applicationDataModel;

        public MainForm()
        {
            InitializeComponent();
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
                _pluginFactory = new PluginFactory(textBox.Text);

                if (_pluginFactory.AvailablePlugins != null)
                {
                    object[] availablePlugins = _pluginFactory.AvailablePlugins.ToArray();

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

            if (_pluginFactory == null)
            {
                MessageBox.Show(@"Select a valid plugin path and load them before importing a datacard.");
                _textBoxPluginPath.Focus();
                return;
            }

            if (IsValid(textBox, "Datacard"))
            {
                foreach (var availablePlugin in _pluginFactory.AvailablePlugins)
                {
                    var plugin = _pluginFactory.GetPlugin(availablePlugin);
                    if (plugin.IsDataCardSupported(_textBoxDatacardPath.Text))
                    {
                        ImportDataCard(plugin, textBox.Text);
                        return;
                    }
                }

                MessageBox.Show(@"Not supported data format.");
            }
        }

        private void _buttonExportDatacard_Click(object sender, EventArgs e)
        {
            var pluginName = (string)_comboBoxPlugins.SelectedItem;
            var plugin = _pluginFactory.GetPlugin(pluginName);
            if (_applicationDataModel == null
                || plugin == null)
            {
                MessageBox.Show(@"Could not export, either not a comptable plugin or no data model to export");
                return;
            }

            plugin.Export(_applicationDataModel, GetExportDirectory());
        }

        private string GetExportDirectory()
        {
            return _textBoxExportPath.Text != string.Empty ? _textBoxExportPath.Text : "C:\\newfile.zip";
        }

        private void ImportDataCard(IPlugin plugin, string datacardPath)
        {
            _treeViewMetadata.Nodes.Clear();

            _applicationDataModel = plugin.Import(datacardPath);

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
            if (propertyType.IsGenericType && Nullable.GetUnderlyingType(propertyType) != null)
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
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
    }
}
