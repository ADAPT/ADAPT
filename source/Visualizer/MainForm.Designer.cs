namespace Visualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._splitContainerMain = new System.Windows.Forms.SplitContainer();
            this._splitContainerPlugin = new System.Windows.Forms.SplitContainer();
            this._textBoxPluginPath = new System.Windows.Forms.TextBox();
            this._buttonLoadPlugins = new System.Windows.Forms.Button();
            this._buttonBrowsePluginLocation = new System.Windows.Forms.Button();
            this._labelPluginLocation = new System.Windows.Forms.Label();
            this._textBoxDatacardPath = new System.Windows.Forms.TextBox();
            this._buttonLoadDatacard = new System.Windows.Forms.Button();
            this._labelDataCard = new System.Windows.Forms.Label();
            this._buttonBrowseDatacard = new System.Windows.Forms.Button();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._splitContainerViewer = new System.Windows.Forms.SplitContainer();
            this._propertyGridViewer = new System.Windows.Forms.PropertyGrid();
            this._splitContainerMap = new System.Windows.Forms.SplitContainer();
            this._tabControlViewer = new System.Windows.Forms.TabControl();
            this._tabPageSpatial = new System.Windows.Forms.TabPage();
            this._tabPageRawData = new System.Windows.Forms.TabPage();
            this._dataGridViewRawData = new System.Windows.Forms.DataGridView();
            this._dataGridViewTotals = new System.Windows.Forms.DataGridView();
            this._dataGridColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._labelTotals = new System.Windows.Forms.Label();
            this._groupBoxExport = new System.Windows.Forms.GroupBox();
            this._buttonExportDatacard = new System.Windows.Forms.Button();
            this._comboBoxPlugins = new System.Windows.Forms.ComboBox();
            this._labelExportFormat = new System.Windows.Forms.Label();
            this._buttonBrowseExportPath = new System.Windows.Forms.Button();
            this._textBoxExportPath = new System.Windows.Forms.TextBox();
            this._labelPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMain)).BeginInit();
            this._splitContainerMain.Panel1.SuspendLayout();
            this._splitContainerMain.Panel2.SuspendLayout();
            this._splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPlugin)).BeginInit();
            this._splitContainerPlugin.Panel1.SuspendLayout();
            this._splitContainerPlugin.Panel2.SuspendLayout();
            this._splitContainerPlugin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerViewer)).BeginInit();
            this._splitContainerViewer.Panel1.SuspendLayout();
            this._splitContainerViewer.Panel2.SuspendLayout();
            this._splitContainerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMap)).BeginInit();
            this._splitContainerMap.Panel1.SuspendLayout();
            this._splitContainerMap.Panel2.SuspendLayout();
            this._splitContainerMap.SuspendLayout();
            this._tabControlViewer.SuspendLayout();
            this._tabPageRawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRawData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTotals)).BeginInit();
            this._groupBoxExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainerMain
            // 
            this._splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainerMain.IsSplitterFixed = true;
            this._splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this._splitContainerMain.Name = "_splitContainerMain";
            this._splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainerMain.Panel1
            // 
            this._splitContainerMain.Panel1.Controls.Add(this._splitContainerPlugin);
            // 
            // _splitContainerMain.Panel2
            // 
            this._splitContainerMain.Panel2.Controls.Add(this._splitContainer);
            this._splitContainerMain.Size = new System.Drawing.Size(999, 742);
            this._splitContainerMain.SplitterDistance = 85;
            this._splitContainerMain.TabIndex = 0;
            // 
            // _splitContainerPlugin
            // 
            this._splitContainerPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerPlugin.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainerPlugin.IsSplitterFixed = true;
            this._splitContainerPlugin.Location = new System.Drawing.Point(0, 0);
            this._splitContainerPlugin.Name = "_splitContainerPlugin";
            this._splitContainerPlugin.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainerPlugin.Panel1
            // 
            this._splitContainerPlugin.Panel1.Controls.Add(this._textBoxPluginPath);
            this._splitContainerPlugin.Panel1.Controls.Add(this._buttonLoadPlugins);
            this._splitContainerPlugin.Panel1.Controls.Add(this._buttonBrowsePluginLocation);
            this._splitContainerPlugin.Panel1.Controls.Add(this._labelPluginLocation);
            // 
            // _splitContainerPlugin.Panel2
            // 
            this._splitContainerPlugin.Panel2.Controls.Add(this._textBoxDatacardPath);
            this._splitContainerPlugin.Panel2.Controls.Add(this._buttonLoadDatacard);
            this._splitContainerPlugin.Panel2.Controls.Add(this._labelDataCard);
            this._splitContainerPlugin.Panel2.Controls.Add(this._buttonBrowseDatacard);
            this._splitContainerPlugin.Size = new System.Drawing.Size(999, 85);
            this._splitContainerPlugin.SplitterDistance = 42;
            this._splitContainerPlugin.TabIndex = 4;
            // 
            // _textBoxPluginPath
            // 
            this._textBoxPluginPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxPluginPath.Location = new System.Drawing.Point(94, 11);
            this._textBoxPluginPath.Name = "_textBoxPluginPath";
            this._textBoxPluginPath.Size = new System.Drawing.Size(715, 20);
            this._textBoxPluginPath.TabIndex = 5;
            // 
            // _buttonLoadPlugins
            // 
            this._buttonLoadPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonLoadPlugins.Location = new System.Drawing.Point(875, 10);
            this._buttonLoadPlugins.Name = "_buttonLoadPlugins";
            this._buttonLoadPlugins.Size = new System.Drawing.Size(110, 23);
            this._buttonLoadPlugins.TabIndex = 7;
            this._buttonLoadPlugins.Text = "Load Plugins";
            this._buttonLoadPlugins.UseVisualStyleBackColor = true;
            this._buttonLoadPlugins.Click += new System.EventHandler(this._buttonLoadPlugins_Click);
            // 
            // _buttonBrowsePluginLocation
            // 
            this._buttonBrowsePluginLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBrowsePluginLocation.Location = new System.Drawing.Point(815, 10);
            this._buttonBrowsePluginLocation.Name = "_buttonBrowsePluginLocation";
            this._buttonBrowsePluginLocation.Size = new System.Drawing.Size(54, 23);
            this._buttonBrowsePluginLocation.TabIndex = 6;
            this._buttonBrowsePluginLocation.Text = "Browse";
            this._buttonBrowsePluginLocation.UseVisualStyleBackColor = true;
            this._buttonBrowsePluginLocation.Click += new System.EventHandler(this._buttonBrowsePluginLocation_Click);
            // 
            // _labelPluginLocation
            // 
            this._labelPluginLocation.AutoSize = true;
            this._labelPluginLocation.Location = new System.Drawing.Point(12, 15);
            this._labelPluginLocation.Name = "_labelPluginLocation";
            this._labelPluginLocation.Size = new System.Drawing.Size(76, 13);
            this._labelPluginLocation.TabIndex = 4;
            this._labelPluginLocation.Text = "Plugin location";
            // 
            // _textBoxDatacardPath
            // 
            this._textBoxDatacardPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxDatacardPath.Location = new System.Drawing.Point(94, 7);
            this._textBoxDatacardPath.Name = "_textBoxDatacardPath";
            this._textBoxDatacardPath.Size = new System.Drawing.Size(715, 20);
            this._textBoxDatacardPath.TabIndex = 1;
            // 
            // _buttonLoadDatacard
            // 
            this._buttonLoadDatacard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonLoadDatacard.Location = new System.Drawing.Point(875, 6);
            this._buttonLoadDatacard.Name = "_buttonLoadDatacard";
            this._buttonLoadDatacard.Size = new System.Drawing.Size(110, 23);
            this._buttonLoadDatacard.TabIndex = 3;
            this._buttonLoadDatacard.Text = "Load Datacard";
            this._buttonLoadDatacard.UseVisualStyleBackColor = true;
            this._buttonLoadDatacard.Click += new System.EventHandler(this._buttonLoadDatacard_Click);
            // 
            // _labelDataCard
            // 
            this._labelDataCard.AutoSize = true;
            this._labelDataCard.Location = new System.Drawing.Point(12, 11);
            this._labelDataCard.Name = "_labelDataCard";
            this._labelDataCard.Size = new System.Drawing.Size(76, 13);
            this._labelDataCard.TabIndex = 0;
            this._labelDataCard.Text = "Datacard Path";
            // 
            // _buttonBrowseDatacard
            // 
            this._buttonBrowseDatacard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBrowseDatacard.Location = new System.Drawing.Point(815, 6);
            this._buttonBrowseDatacard.Name = "_buttonBrowseDatacard";
            this._buttonBrowseDatacard.Size = new System.Drawing.Size(54, 23);
            this._buttonBrowseDatacard.TabIndex = 2;
            this._buttonBrowseDatacard.Text = "Browse";
            this._buttonBrowseDatacard.UseVisualStyleBackColor = true;
            this._buttonBrowseDatacard.Click += new System.EventHandler(this._buttonBrowseDatacard_Click);
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Name = "_splitContainer";
            this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._splitContainerViewer);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._groupBoxExport);
            this._splitContainer.Size = new System.Drawing.Size(999, 653);
            this._splitContainer.SplitterDistance = 556;
            this._splitContainer.TabIndex = 1;
            // 
            // _splitContainerViewer
            // 
            this._splitContainerViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerViewer.Location = new System.Drawing.Point(0, 0);
            this._splitContainerViewer.Name = "_splitContainerViewer";
            // 
            // _splitContainerViewer.Panel1
            // 
            this._splitContainerViewer.Panel1.Controls.Add(this._propertyGridViewer);
            // 
            // _splitContainerViewer.Panel2
            // 
            this._splitContainerViewer.Panel2.Controls.Add(this._splitContainerMap);
            this._splitContainerViewer.Size = new System.Drawing.Size(999, 556);
            this._splitContainerViewer.SplitterDistance = 449;
            this._splitContainerViewer.TabIndex = 0;
            // 
            // _propertyGridViewer
            // 
            this._propertyGridViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertyGridViewer.Location = new System.Drawing.Point(0, 0);
            this._propertyGridViewer.Name = "_propertyGridViewer";
            this._propertyGridViewer.Size = new System.Drawing.Size(449, 556);
            this._propertyGridViewer.TabIndex = 0;
            // 
            // _splitContainerMap
            // 
            this._splitContainerMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerMap.Location = new System.Drawing.Point(0, 0);
            this._splitContainerMap.Name = "_splitContainerMap";
            this._splitContainerMap.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainerMap.Panel1
            // 
            this._splitContainerMap.Panel1.Controls.Add(this._tabControlViewer);
            // 
            // _splitContainerMap.Panel2
            // 
            this._splitContainerMap.Panel2.Controls.Add(this._dataGridViewTotals);
            this._splitContainerMap.Panel2.Controls.Add(this._labelTotals);
            this._splitContainerMap.Size = new System.Drawing.Size(546, 556);
            this._splitContainerMap.SplitterDistance = 375;
            this._splitContainerMap.TabIndex = 0;
            // 
            // _tabControlViewer
            // 
            this._tabControlViewer.Controls.Add(this._tabPageSpatial);
            this._tabControlViewer.Controls.Add(this._tabPageRawData);
            this._tabControlViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlViewer.Location = new System.Drawing.Point(0, 0);
            this._tabControlViewer.Name = "_tabControlViewer";
            this._tabControlViewer.SelectedIndex = 0;
            this._tabControlViewer.Size = new System.Drawing.Size(546, 375);
            this._tabControlViewer.TabIndex = 0;
            // 
            // _tabPageSpatial
            // 
            this._tabPageSpatial.Location = new System.Drawing.Point(4, 22);
            this._tabPageSpatial.Name = "_tabPageSpatial";
            this._tabPageSpatial.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageSpatial.Size = new System.Drawing.Size(538, 349);
            this._tabPageSpatial.TabIndex = 0;
            this._tabPageSpatial.Text = "Spatial Viewer";
            this._tabPageSpatial.UseVisualStyleBackColor = true;
            // 
            // _tabPageRawData
            // 
            this._tabPageRawData.Controls.Add(this._dataGridViewRawData);
            this._tabPageRawData.Location = new System.Drawing.Point(4, 22);
            this._tabPageRawData.Name = "_tabPageRawData";
            this._tabPageRawData.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageRawData.Size = new System.Drawing.Size(538, 349);
            this._tabPageRawData.TabIndex = 1;
            this._tabPageRawData.Text = "Raw data Viewer";
            this._tabPageRawData.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewRawData
            // 
            this._dataGridViewRawData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewRawData.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewRawData.Location = new System.Drawing.Point(3, 3);
            this._dataGridViewRawData.Name = "_dataGridViewRawData";
            this._dataGridViewRawData.Size = new System.Drawing.Size(532, 343);
            this._dataGridViewRawData.TabIndex = 0;
            // 
            // _dataGridViewTotals
            // 
            this._dataGridViewTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewTotals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dataGridColumnDescription,
            this._dataGridColumnValue});
            this._dataGridViewTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewTotals.Location = new System.Drawing.Point(0, 13);
            this._dataGridViewTotals.Name = "_dataGridViewTotals";
            this._dataGridViewTotals.RowHeadersVisible = false;
            this._dataGridViewTotals.Size = new System.Drawing.Size(546, 164);
            this._dataGridViewTotals.TabIndex = 1;
            // 
            // _dataGridColumnDescription
            // 
            this._dataGridColumnDescription.HeaderText = "Description";
            this._dataGridColumnDescription.Name = "_dataGridColumnDescription";
            this._dataGridColumnDescription.Width = 250;
            // 
            // _dataGridColumnValue
            // 
            this._dataGridColumnValue.HeaderText = "Value";
            this._dataGridColumnValue.Name = "_dataGridColumnValue";
            // 
            // _labelTotals
            // 
            this._labelTotals.AutoSize = true;
            this._labelTotals.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelTotals.Location = new System.Drawing.Point(0, 0);
            this._labelTotals.Name = "_labelTotals";
            this._labelTotals.Size = new System.Drawing.Size(36, 13);
            this._labelTotals.TabIndex = 0;
            this._labelTotals.Text = "Totals";
            // 
            // _groupBoxExport
            // 
            this._groupBoxExport.Controls.Add(this._buttonExportDatacard);
            this._groupBoxExport.Controls.Add(this._comboBoxPlugins);
            this._groupBoxExport.Controls.Add(this._labelExportFormat);
            this._groupBoxExport.Controls.Add(this._buttonBrowseExportPath);
            this._groupBoxExport.Controls.Add(this._textBoxExportPath);
            this._groupBoxExport.Controls.Add(this._labelPath);
            this._groupBoxExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxExport.Location = new System.Drawing.Point(0, 0);
            this._groupBoxExport.Name = "_groupBoxExport";
            this._groupBoxExport.Size = new System.Drawing.Size(999, 93);
            this._groupBoxExport.TabIndex = 0;
            this._groupBoxExport.TabStop = false;
            this._groupBoxExport.Text = "Export";
            // 
            // _buttonExportDatacard
            // 
            this._buttonExportDatacard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonExportDatacard.Location = new System.Drawing.Point(931, 50);
            this._buttonExportDatacard.Name = "_buttonExportDatacard";
            this._buttonExportDatacard.Size = new System.Drawing.Size(54, 23);
            this._buttonExportDatacard.TabIndex = 8;
            this._buttonExportDatacard.Text = "Export";
            this._buttonExportDatacard.UseVisualStyleBackColor = true;
            // 
            // _comboBoxPlugins
            // 
            this._comboBoxPlugins.FormattingEnabled = true;
            this._comboBoxPlugins.Location = new System.Drawing.Point(94, 51);
            this._comboBoxPlugins.Name = "_comboBoxPlugins";
            this._comboBoxPlugins.Size = new System.Drawing.Size(286, 21);
            this._comboBoxPlugins.TabIndex = 7;
            // 
            // _labelExportFormat
            // 
            this._labelExportFormat.AutoSize = true;
            this._labelExportFormat.Location = new System.Drawing.Point(49, 55);
            this._labelExportFormat.Name = "_labelExportFormat";
            this._labelExportFormat.Size = new System.Drawing.Size(39, 13);
            this._labelExportFormat.TabIndex = 6;
            this._labelExportFormat.Text = "Format";
            // 
            // _buttonBrowseExportPath
            // 
            this._buttonBrowseExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBrowseExportPath.Location = new System.Drawing.Point(931, 21);
            this._buttonBrowseExportPath.Name = "_buttonBrowseExportPath";
            this._buttonBrowseExportPath.Size = new System.Drawing.Size(54, 23);
            this._buttonBrowseExportPath.TabIndex = 5;
            this._buttonBrowseExportPath.Text = "Browse";
            this._buttonBrowseExportPath.UseVisualStyleBackColor = true;
            this._buttonBrowseExportPath.Click += new System.EventHandler(this._buttonBrowseExportPath_Click);
            // 
            // _textBoxExportPath
            // 
            this._textBoxExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxExportPath.Location = new System.Drawing.Point(94, 22);
            this._textBoxExportPath.Name = "_textBoxExportPath";
            this._textBoxExportPath.Size = new System.Drawing.Size(831, 20);
            this._textBoxExportPath.TabIndex = 4;
            // 
            // _labelPath
            // 
            this._labelPath.AutoSize = true;
            this._labelPath.Location = new System.Drawing.Point(26, 25);
            this._labelPath.Name = "_labelPath";
            this._labelPath.Size = new System.Drawing.Size(62, 13);
            this._labelPath.TabIndex = 4;
            this._labelPath.Text = "Export Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 742);
            this.Controls.Add(this._splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ADAPT - Visualizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._splitContainerMain.Panel1.ResumeLayout(false);
            this._splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMain)).EndInit();
            this._splitContainerMain.ResumeLayout(false);
            this._splitContainerPlugin.Panel1.ResumeLayout(false);
            this._splitContainerPlugin.Panel1.PerformLayout();
            this._splitContainerPlugin.Panel2.ResumeLayout(false);
            this._splitContainerPlugin.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPlugin)).EndInit();
            this._splitContainerPlugin.ResumeLayout(false);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this._splitContainerViewer.Panel1.ResumeLayout(false);
            this._splitContainerViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerViewer)).EndInit();
            this._splitContainerViewer.ResumeLayout(false);
            this._splitContainerMap.Panel1.ResumeLayout(false);
            this._splitContainerMap.Panel2.ResumeLayout(false);
            this._splitContainerMap.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMap)).EndInit();
            this._splitContainerMap.ResumeLayout(false);
            this._tabControlViewer.ResumeLayout(false);
            this._tabPageRawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRawData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTotals)).EndInit();
            this._groupBoxExport.ResumeLayout(false);
            this._groupBoxExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainerMain;
        private System.Windows.Forms.Button _buttonLoadDatacard;
        private System.Windows.Forms.Button _buttonBrowseDatacard;
        private System.Windows.Forms.TextBox _textBoxDatacardPath;
        private System.Windows.Forms.Label _labelDataCard;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.SplitContainer _splitContainerViewer;
        private System.Windows.Forms.PropertyGrid _propertyGridViewer;
        private System.Windows.Forms.SplitContainer _splitContainerMap;
        private System.Windows.Forms.TabControl _tabControlViewer;
        private System.Windows.Forms.TabPage _tabPageSpatial;
        private System.Windows.Forms.TabPage _tabPageRawData;
        private System.Windows.Forms.DataGridView _dataGridViewRawData;
        private System.Windows.Forms.DataGridView _dataGridViewTotals;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnValue;
        private System.Windows.Forms.Label _labelTotals;
        private System.Windows.Forms.GroupBox _groupBoxExport;
        private System.Windows.Forms.Button _buttonExportDatacard;
        private System.Windows.Forms.ComboBox _comboBoxPlugins;
        private System.Windows.Forms.Label _labelExportFormat;
        private System.Windows.Forms.Button _buttonBrowseExportPath;
        private System.Windows.Forms.TextBox _textBoxExportPath;
        private System.Windows.Forms.Label _labelPath;
        private System.Windows.Forms.SplitContainer _splitContainerPlugin;
        private System.Windows.Forms.TextBox _textBoxPluginPath;
        private System.Windows.Forms.Button _buttonLoadPlugins;
        private System.Windows.Forms.Button _buttonBrowsePluginLocation;
        private System.Windows.Forms.Label _labelPluginLocation;
    }
}

