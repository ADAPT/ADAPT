namespace AgGateway.ADAPT.Visualizer.UI
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
            this._splitContainerViewer = new System.Windows.Forms.SplitContainer();
            this._treeViewMetadata = new System.Windows.Forms.TreeView();
            this._splitContainerMap = new System.Windows.Forms.SplitContainer();
            this._tabControlViewer = new System.Windows.Forms.TabControl();
            this._tabPageSpatial = new System.Windows.Forms.TabPage();
            this._tabPageRawData = new System.Windows.Forms.TabPage();
            this._buttonExportRawData = new System.Windows.Forms.Button();
            this._dataGridViewRawData = new System.Windows.Forms.DataGridView();
            this._dataGridViewTotals = new System.Windows.Forms.DataGridView();
            this._dataGridColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._labelTotals = new System.Windows.Forms.Label();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainerViewer
            // 
            this._splitContainerViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerViewer.Location = new System.Drawing.Point(0, 74);
            this._splitContainerViewer.Name = "_splitContainerViewer";
            // 
            // _splitContainerViewer.Panel1
            // 
            this._splitContainerViewer.Panel1.Controls.Add(this._treeViewMetadata);
            // 
            // _splitContainerViewer.Panel2
            // 
            this._splitContainerViewer.Panel2.Controls.Add(this._splitContainerMap);
            this._splitContainerViewer.Size = new System.Drawing.Size(999, 668);
            this._splitContainerViewer.SplitterDistance = 250;
            this._splitContainerViewer.TabIndex = 0;
            // 
            // _treeViewMetadata
            // 
            this._treeViewMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeViewMetadata.Location = new System.Drawing.Point(0, 0);
            this._treeViewMetadata.Name = "_treeViewMetadata";
            this._treeViewMetadata.Size = new System.Drawing.Size(250, 668);
            this._treeViewMetadata.TabIndex = 0;
            this._treeViewMetadata.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeViewMetadata_NodeMouseClick);
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
            this._splitContainerMap.Size = new System.Drawing.Size(745, 668);
            this._splitContainerMap.SplitterDistance = 447;
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
            this._tabControlViewer.Size = new System.Drawing.Size(745, 447);
            this._tabControlViewer.TabIndex = 0;
            // 
            // _tabPageSpatial
            // 
            this._tabPageSpatial.Location = new System.Drawing.Point(4, 22);
            this._tabPageSpatial.Name = "_tabPageSpatial";
            this._tabPageSpatial.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageSpatial.Size = new System.Drawing.Size(737, 421);
            this._tabPageSpatial.TabIndex = 0;
            this._tabPageSpatial.Text = "Spatial Viewer";
            this._tabPageSpatial.UseVisualStyleBackColor = true;
            this._tabPageSpatial.Paint += new System.Windows.Forms.PaintEventHandler(this._tabPageSpatial_Paint);
            // 
            // _tabPageRawData
            // 
            this._tabPageRawData.Controls.Add(this._buttonExportRawData);
            this._tabPageRawData.Controls.Add(this._dataGridViewRawData);
            this._tabPageRawData.Location = new System.Drawing.Point(4, 22);
            this._tabPageRawData.Name = "_tabPageRawData";
            this._tabPageRawData.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageRawData.Size = new System.Drawing.Size(737, 421);
            this._tabPageRawData.TabIndex = 1;
            this._tabPageRawData.Text = "Raw data Viewer";
            this._tabPageRawData.UseVisualStyleBackColor = true;
            // 
            // _buttonExportRawData
            // 
            this._buttonExportRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonExportRawData.Location = new System.Drawing.Point(638, 393);
            this._buttonExportRawData.Name = "_buttonExportRawData";
            this._buttonExportRawData.Size = new System.Drawing.Size(89, 23);
            this._buttonExportRawData.TabIndex = 1;
            this._buttonExportRawData.Text = "Export";
            this._buttonExportRawData.UseVisualStyleBackColor = true;
            this._buttonExportRawData.Click += new System.EventHandler(this._buttonExportRawData_Click);
            // 
            // _dataGridViewRawData
            // 
            this._dataGridViewRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridViewRawData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewRawData.Location = new System.Drawing.Point(3, 3);
            this._dataGridViewRawData.Name = "_dataGridViewRawData";
            this._dataGridViewRawData.Size = new System.Drawing.Size(731, 386);
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
            this._dataGridViewTotals.Size = new System.Drawing.Size(745, 204);
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
            // _toolStrip
            // 
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._importToolStripButton,
            this._exportToolStripButton,
            this._aboutToolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(999, 74);
            this._toolStrip.TabIndex = 9;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _importToolStripButton
            // 
            this._importToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.Enter;
            this._importToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._importToolStripButton.Name = "_importToolStripButton";
            this._importToolStripButton.Size = new System.Drawing.Size(56, 71);
            this._importToolStripButton.Text = "Import";
            this._importToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._importToolStripButton.Click += new System.EventHandler(this._importToolStripButton_Click);
            // 
            // _exportToolStripButton
            // 
            this._exportToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.Exit;
            this._exportToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exportToolStripButton.Name = "_exportToolStripButton";
            this._exportToolStripButton.Size = new System.Drawing.Size(56, 71);
            this._exportToolStripButton.Text = "Export";
            this._exportToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exportToolStripButton.Click += new System.EventHandler(this._exportToolStripButton_Click);
            // 
            // _aboutToolStripButton
            // 
            this._aboutToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.About_52;
            this._aboutToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._aboutToolStripButton.Name = "_aboutToolStripButton";
            this._aboutToolStripButton.Size = new System.Drawing.Size(56, 71);
            this._aboutToolStripButton.Text = "About";
            this._aboutToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._aboutToolStripButton.Click += new System.EventHandler(this._aboutToolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 742);
            this.Controls.Add(this._splitContainerViewer);
            this.Controls.Add(this._toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ADAPT - Visualizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
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
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainerViewer;
        private System.Windows.Forms.TreeView _treeViewMetadata;
        private System.Windows.Forms.SplitContainer _splitContainerMap;
        private System.Windows.Forms.TabControl _tabControlViewer;
        private System.Windows.Forms.TabPage _tabPageSpatial;
        private System.Windows.Forms.TabPage _tabPageRawData;
        private System.Windows.Forms.Button _buttonExportRawData;
        private System.Windows.Forms.DataGridView _dataGridViewRawData;
        private System.Windows.Forms.DataGridView _dataGridViewTotals;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnValue;
        private System.Windows.Forms.Label _labelTotals;
        private System.Windows.Forms.ToolStripButton _importToolStripButton;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _exportToolStripButton;
        private System.Windows.Forms.ToolStripButton _aboutToolStripButton;
    }
}

