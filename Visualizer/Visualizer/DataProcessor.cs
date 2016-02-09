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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class DataProcessor
    {
        private readonly TabPage _spatialViewer;
        private readonly DataGridView _rawDataViewer;
        private readonly DataGridView _totalsViewer;
        private double _minX;
        private double _maxX;
        private double _minY;
        private double _maxY;

        public DataProcessor(TabPage spatialViewer, DataGridView rawDataViewer, DataGridView totalsViewer)
        {
            _spatialViewer = spatialViewer;
            _rawDataViewer = rawDataViewer;
            _totalsViewer = totalsViewer;
        }

        private Graphics SpatialViewerGraphics
        {
            get { return _spatialViewer.CreateGraphics(); }
        }

        private static Pen Pen
        {
            get { return new Pen(Color.Black, 2); }
        }

        public void ProcessOperationData(OperationData operationData)
        {
            _rawDataViewer.Rows.Clear();
            _rawDataViewer.Columns.Clear();

            var spatialRecords = operationData.GetSpatialRecords();
            var meters = GetSections(operationData).SelectMany(x => x.GetMeters()).Where(x => x.Representation != null);

            CreateColumns(meters);

            foreach (var spatialRecord in spatialRecords)
            {
                CreateRow(meters, spatialRecord);
            }
        }

        private void CreateColumns(IEnumerable<Meter> meters)
        {
            foreach (var meter in meters)
            {
                _rawDataViewer.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = meter.Representation.Code});
            }
        }

        private void CreateRow(IEnumerable<Meter> meters, SpatialRecord spatialRecord)
        {
            var dataGridViewRow = new DataGridViewRow();
            foreach (var meter in meters)
            {
                if (meter as NumericMeter != null)
                    CreateNumericMeterCell(spatialRecord, meter, dataGridViewRow);

                if (meter as EnumeratedMeter != null)
                    CreateEnumeratedMeterCell(spatialRecord, meter, dataGridViewRow);
            }
            _rawDataViewer.Rows.Add(dataGridViewRow);
        }

        private static void CreateEnumeratedMeterCell(SpatialRecord spatialRecord, Meter meter, DataGridViewRow dataGridViewRow)
        {
            var enumeratedValue = spatialRecord.GetMeterValue(meter) as EnumeratedValue;
            var dataGridViewCell = new DataGridViewTextBoxCell
            {
                Value = enumeratedValue != null ? enumeratedValue.Value.Value : ""
            };
            dataGridViewRow.Cells.Add(dataGridViewCell);
        }

        private static void CreateNumericMeterCell(SpatialRecord spatialRecord, Meter meter, DataGridViewRow dataGridViewRow)
        {
            var numericRepresentationValue = spatialRecord.GetMeterValue(meter) as NumericRepresentationValue;
            var value = numericRepresentationValue != null
                ? numericRepresentationValue.Value.Value.ToString(CultureInfo.InvariantCulture) + " " +
                  numericRepresentationValue.Value.UnitOfMeasure.Code
                : "";
            var dataGridViewCell = new DataGridViewTextBoxCell {Value = value};
            dataGridViewRow.Cells.Add(dataGridViewCell);
        }

        private static IEnumerable<Section> GetSections(OperationData operationData)
        {
            for (var i = 0; i < operationData.MaxDepth; i++)
            {
                foreach (var section in operationData.GetSections(i))
                {
                    yield return section;
                }
            }
        }

        public void ProcessGuidance(GuidanceGroup guidanceGroup, List<GuidancePattern> guidancePatterns)
        {
            foreach (var id in guidanceGroup.GuidancePatternIds)
            {
                ProcessGuidancePattern(guidancePatterns, id);
            }
        }

        public void ProcessBoundary(FieldBoundary fieldBoundary)
        {
            using (var graphics = SpatialViewerGraphics)
            {
                foreach (var polygon in fieldBoundary.SpatialData.Polygons)
                {
                    var projectedPoints = polygon.ExteriorRing.Points.Select(point => point.ToUtm()).ToList();
                    var delta = GetDelta(projectedPoints);
                    var screenPolygon = projectedPoints.Select(point => point.ToXy(_minX, _minY, delta)).ToArray();

                    graphics.Clear(Color.White);

                    SetOriginPoint(delta, graphics);

                    graphics.DrawPolygon(Pen, screenPolygon);
                }
            }
        }

        private void ProcessGuidancePattern(IEnumerable<GuidancePattern> guidancePatterns, int id)
        {
            var guidancePattern = guidancePatterns.First(pattern => pattern.Id.ReferenceId == id);
            ProccessGuidancePattern(guidancePattern);
        }

        public void ProccessGuidancePattern(GuidancePattern guidancePattern)
        {
            using (var graphics = SpatialViewerGraphics)
            {
                graphics.Clear(Color.White);

                if (guidancePattern is APlus)
                {
                    var points = new List<Point> { ((APlus)guidancePattern).Point.ToUtm() };
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessAPlus(guidancePattern as APlus, graphics, delta);
                }
                else if (guidancePattern is AbLine)
                {
                    var points = new List<Point> { ((AbLine)guidancePattern).A.ToUtm(), ((AbLine)guidancePattern).B.ToUtm() };
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessAbLine(guidancePattern as AbLine, graphics, delta);
                }
                else if (guidancePattern is AbCurve)
                {
                    var points = ((AbCurve) guidancePattern).Shape.SelectMany(x => x.Points).Select(x => x.ToUtm()).ToList();
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessAbCurve(guidancePattern as AbCurve, graphics, delta);
                }
                else if (guidancePattern is CenterPivot)
                {
                    var points = new List<Point> { ((CenterPivot)guidancePattern).Center.ToUtm(), ((CenterPivot)guidancePattern).EndPoint.ToUtm(), ((CenterPivot)guidancePattern).StartPoint.ToUtm() };
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessCenterPivot(guidancePattern as CenterPivot, graphics, delta);
                }
                else if (guidancePattern is MultiAbLine)
                {
                    var points = ((MultiAbLine)guidancePattern).AbLines.SelectMany(x => new List<Point>{ x.A.ToUtm(), x.B.ToUtm() }).ToList();
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessMultiAbLine(guidancePattern as MultiAbLine, graphics, delta);
                }
                else if (guidancePattern is Spiral)
                {
                    var points = ((Spiral) guidancePattern).Shape.Points.Select(x => x.ToUtm()).ToList();
                    var delta = GetDelta(points);
                    SetOriginPoint(delta, graphics);
                    ProcessSpiral(guidancePattern as Spiral, graphics, delta);
                }
            }
        }

        private void SetOriginPoint(double delta, Graphics graphics)
        {
            var max = ((_maxY - _minY)/delta + 25) + 20;
            graphics.Transform = new Matrix(1, 0, 0, -1, 0, (float) max);
        }

        private void ProcessSpiral(Spiral spiral, Graphics graphics, double delta)
        {
            ProcessLineString(spiral.Shape, graphics, delta);
        }

        private void ProcessMultiAbLine(MultiAbLine multiAbLine, Graphics graphics, double delta)
        {
            foreach (var abline in multiAbLine.AbLines)
            {
                ProcessAbLine(abline, graphics, delta);
            }
        }

        private void ProcessCenterPivot(CenterPivot centerPivot, Graphics graphics, double delta)
        {
            throw new NotImplementedException();
        }

        private void ProcessAbCurve(AbCurve abCurve, Graphics graphics, double delta)
        {
            foreach (var lineString in abCurve.Shape)
            {
                ProcessLineString(lineString, graphics, delta);
            }
        }

        private void ProcessLineString(LineString lineString, Graphics graphics, double delta)
        {
            ProcessPoints(lineString.Points, graphics, delta);
        }

        private void ProcessAbLine(AbLine abLine, Graphics graphics, double delta)
        {
            ProcessPoints(new List<Point> {abLine.A.ToUtm(), abLine.B.ToUtm()}, graphics, delta);
        }

        private void ProcessPoints(IEnumerable<Point> points, Graphics graphics, double delta)
        {
            var screenPoints = points.Select(point => point.ToXy(_minX, _minY, delta)).ToArray();

            graphics.DrawLines(Pen, screenPoints);
        }

        private void ProcessAPlus(APlus aPlus, Graphics graphics, double delta)
        {
            var projectedPoint = aPlus.Point.ToUtm();
        }

        private double GetDelta(IList<Point> points)
        {
            double delta;
            _minX = points.Min(point => point.X);
            _maxX = points.Max(point => point.X);
            _minY = points.Min(point => point.Y);
            _maxY = points.Max(point => point.Y);
            
            var lonDistance = (_maxX - _minX);
            var latDistance = (_maxY - _minY); 

            var width = _spatialViewer.Width - 50;
            var height = _spatialViewer.Height - 50;

            if (width < height && latDistance > lonDistance)
            {
                delta = lonDistance/width;
            }
            else
            {
                delta = latDistance/height;
            }

            return delta;
        }
    }
}