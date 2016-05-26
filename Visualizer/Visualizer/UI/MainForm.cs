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
using System.Drawing;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class MainForm : Form
    {
        private readonly Model _model;
        private readonly BoundaryProcessor _boundaryProcessor;
        private readonly GuidanceProcessor _guidanceProcessor;
        private readonly OperationDataProcessor _operationDataProcessor;

        public MainForm()
        {
            InitializeComponent();

            _model = new Model();
            _operationDataProcessor = new OperationDataProcessor();
            _boundaryProcessor = new BoundaryProcessor(_tabPageSpatial);
            _guidanceProcessor = new GuidanceProcessor(_tabPageSpatial);
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

        private void _tabPageSpatial_Paint(object sender, PaintEventArgs e)
        {
            if (_tabPageSpatial.Tag == null)
            {
                return;
            }

            ProcessData(_tabPageSpatial.Tag as TreeNode);
        }

        private void _aboutToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm(new AboutForm());
        }

        private void _importToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm(new ImportForm(_model, _treeViewMetadata, _dataGridViewRawData));
        }

        private void _exportToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm(new ExportForm(_model));
        }

        private void ShowForm(Form form)
        {
            form.ShowDialog(this);
        }

        private void _buttonExportRawData_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".csv", 
                Filter = @"CSV File (.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _model.WriteCsvFile(saveFileDialog.FileName, _dataGridViewRawData);
            }
        }

        private void ProcessData(TreeNode treeNode)
        {
            var objectWithIndex = (ObjectWithIndex)treeNode.Tag;
            var element = objectWithIndex.Element;

            if (element is FieldBoundary)
            {
                _boundaryProcessor.ProcessBoundary(element as FieldBoundary);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidanceGroup)
            {
                _guidanceProcessor.ProcessGuidance(element as GuidanceGroup, _model.ApplicationDataModels[objectWithIndex.ApplicationDataModelIndex].Catalog.GuidancePatterns);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidancePattern)
            {
                _guidanceProcessor.ProccessGuidancePattern(element as GuidancePattern);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is OperationData)
            {
                _dataGridViewRawData.DataSource = _operationDataProcessor.ProcessOperationData(element as OperationData);
                _tabControlViewer.SelectedTab = _tabPageRawData;
            }
        }
    }
}