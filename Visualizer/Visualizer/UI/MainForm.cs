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
        private Action<Model.State, string> _updateStatusAction;
        private static BusyForm _busyForm;

        public MainForm()
        {
            InitializeComponent();

            _updateStatusAction = UpdateStatus;
            _model = new Model(_updateStatusAction);
            _operationDataProcessor = new OperationDataProcessor();
            _boundaryProcessor = new BoundaryProcessor(_tabPageSpatial);
            _guidanceProcessor = new GuidanceProcessor(_tabPageSpatial);

            _busyForm = new BusyForm();
        }

        private void UpdateStatus(Model.State state, string s)
        {
            if (state == Model.State.StateIdle)
            {
                _busyForm.Invoke(new Action(() =>
                {
                    _busyForm.Hide();
                    _busyForm.UpdateLabel("Busy");
                }));
                
                return;
            }

            if (_busyForm != null)
            {
                if (_busyForm.InvokeRequired)
                {
                    _busyForm.Invoke(new Action(() =>
                    {
                        _busyForm.UpdateLabel(s);
                    }));
                }
                _busyForm.UpdateLabel(s);
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

        private bool OkToShowImportExport()
        {
            if (_model.CurrentState == Model.State.StateImporting)
            {
                MessageBox.Show("Currently importing.  Please Wait.");
                return false;
            }

            if (_model.CurrentState == Model.State.StateExporting)
            {
                MessageBox.Show("Currently exporting.  Please Wait.");
                return false;
            }

            if (_model.CurrentState != Model.State.StateIdle)
            {
                MessageBox.Show("Currently busy.  Please Wait.");
                return false;
            }

            return true;
        }

        private void _importToolStripButton_Click(object sender, EventArgs e)
        {
            if (OkToShowImportExport())
            {
                ShowForm(new ImportForm(_model, _treeViewMetadata, _dataGridViewRawData));
                CheckIfBusy();
            }
        }

        private void _exportToolStripButton_Click(object sender, EventArgs e)
        {
            if (OkToShowImportExport())
            {
                ShowForm(new ExportForm(_model));
                CheckIfBusy();
            }
        }

        private void ShowForm(Form form)
        {
            form.ShowDialog(this);
        }

        private void CheckIfBusy()
        {
            if (_model.CurrentState != Model.State.StateIdle)
            {      
                _busyForm.Show(this);
            }
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

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
        }

        private void ResizeBusyForm()
        {
            if (_busyForm == null || _busyForm.Visible != true)
                return;

            Point mainFormCoords = this.Location;
            int mainFormWidth = this.Size.Width;
            int mainFormHeight = this.Size.Height;
            Point mainFormCenter = new Point();
            mainFormCenter.X = mainFormCoords.X + (mainFormWidth / 2);
            mainFormCenter.Y = mainFormCoords.Y + (mainFormHeight / 2);
            Point waitFormLocation = new Point();
            waitFormLocation.X = mainFormCenter.X - (_busyForm.Width / 2);
            waitFormLocation.Y = mainFormCenter.Y - (_busyForm.Height / 2);
            _busyForm.StartPosition = FormStartPosition.Manual;
            _busyForm.Location = waitFormLocation;  
        }
    }
}