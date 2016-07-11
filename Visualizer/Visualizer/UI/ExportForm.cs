using System;
using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.Visualizer.Properties;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class ExportForm : Form
    {
        private readonly Model _model;
        private bool _isDirty;  

        public ExportForm(Model model)
        {
            InitializeComponent();

            _model = model;

            if (_model.AvailablePlugins().Any())
                _loadedPluginsListBox.DataSource = _model.AvailablePlugins();

            foreach (var applicationDataModel in _model.ApplicationDataModels.OrderBy(x => x.Catalog.Description))
            {
                cardProfileSelection.Items.Add(applicationDataModel.Catalog.Description);
            }
        }

        private void BrowsePluginLocation_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _pluginPathTextBox);
        }

        private void BrowseExportPath_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _exportPathTextBox);
        }

        private void _loadPluginsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _loadedPluginsListBox.DataSource = _model.LoadPlugins(_pluginPathTextBox);

            Cursor.Current = Cursors.Default;
        }

        private void _exportDatacardButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _model.Export((string) _loadedPluginsListBox.SelectedItem, _initializeStringTextBox.Text, _exportPathTextBox.Text, cardProfileSelection.SelectedItem.ToString());

            Cursor.Current = Cursors.Default;

            DialogResult = DialogResult.OK;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            _pluginPathTextBox.Text = Settings.Default.PluginPath;
            _initializeStringTextBox.Text = Settings.Default.InitializeString;
            _exportPathTextBox.Text = Settings.Default.ExportPath;

            _proprietaryDataGridView.Rows.Clear();

            //TODO: where do these values come from??
//            foreach (var kvp in Settings.Default.ProprietaryValues)
//            {
//                var strings = kvp.Split(';');
//
//                var dataGridViewRow = new DataGridViewRow();
//                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = strings[0] });
//                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell { Value = strings[1] });
//
//                _proprietaryDataGridView.Rows.Add(dataGridViewRow);
//            }
        }

        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                Settings.Default.ProprietaryValues.Clear();

                foreach (DataGridViewRow row in _proprietaryDataGridView.Rows)
                {
                    Settings.Default.ProprietaryValues.Add(string.Format("{0};{1}", row.Cells[0].Value, row.Cells[1].Value));
                }    
            }

            Settings.Default.PluginPath = _pluginPathTextBox.Text;
            Settings.Default.InitializeString = _initializeStringTextBox.Text;
            Settings.Default.ExportPath = _exportPathTextBox.Text;
            Settings.Default.Save();
        }

        private void _proprietaryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _isDirty = true;
        }
    }
}
