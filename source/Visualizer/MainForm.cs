using System;
using System.IO;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.PluginManager;

namespace Visualizer
{
    public partial class MainForm : Form
    {
        private PluginFactory _pluginFactory;

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

        private void ImportDataCard(IPlugin plugin, string datacardPath)
        {
            _propertyGridViewer.SelectedObject = plugin.Import(datacardPath);

            if (_propertyGridViewer.SelectedGridItem != null &&
                _propertyGridViewer.SelectedGridItem.Parent != null &&
                _propertyGridViewer.SelectedGridItem.Parent.GridItems.Count > 0)
            {
                _propertyGridViewer.SelectedGridItem = _propertyGridViewer.SelectedGridItem.Parent.GridItems[0];
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
