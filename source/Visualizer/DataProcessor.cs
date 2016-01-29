using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel;
using Point = AgGateway.ADAPT.ApplicationDataModel.Point;

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

        public void ProcessLoggedData(LoggedData loggedData)
        {
            throw new NotImplementedException();
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
            using (var g = SpatialViewerGraphics)
            {
                foreach (var polygon in fieldBoundary.SpatialData.Polygons)
                {
                    var projectedPoints = polygon.ExteriorRing.Points.Select(point => point.ToUtm()).ToList();
                    var delta = GetDelta(projectedPoints);
                    var screenPolygon = projectedPoints.Select(point => point.ToXy(_minX, _minY, delta)).ToArray();

                    g.Clear(Color.White);
                    g.DrawPolygon(Pen, screenPolygon);
                }
            }
        }

        private void ProcessGuidancePattern(IEnumerable<GuidancePattern> guidancePatterns, int id)
        {
            using (var graphics = SpatialViewerGraphics)
            {
                graphics.Clear(Color.White);

                var guidancePattern = guidancePatterns.First(pattern => pattern.Id.ReferenceId == id);

                if (guidancePattern is APlus)
                {
                    ProcessAPlus(guidancePattern as APlus, graphics);
                }
                else if (guidancePattern is AbLine)
                {
                    ProcessAbLine(guidancePattern as AbLine, graphics);
                }
                else if (guidancePattern is AbCurve)
                {
                    ProcessAbCurve(guidancePattern as AbCurve, graphics);
                }
                else if (guidancePattern is CenterPivot)
                {
                    ProcessCenterPivot(guidancePattern as CenterPivot, graphics);
                }
                else if (guidancePattern is MultiAbLine)
                {
                    ProcessMultiAbLine(guidancePattern as MultiAbLine, graphics);
                }
                else if (guidancePattern is Spiral)
                {
                    ProcessSpiral(guidancePattern as Spiral, graphics);
                }
            }
        }

        private void ProcessSpiral(Spiral spiral, Graphics graphics)
        {
            ProcessLineString(spiral.Shape, graphics);
        }

        private void ProcessMultiAbLine(MultiAbLine multiAbLine, Graphics graphics)
        {
            foreach (var abline in multiAbLine.AbLines)
            {
                ProcessAbLine(abline, graphics);
            }
        }

        private void ProcessCenterPivot(CenterPivot centerPivot, Graphics graphics)
        {
            throw new NotImplementedException();
        }

        private void ProcessAbCurve(AbCurve abCurve, Graphics graphics)
        {
            foreach (var lineString in abCurve.Shape)
            {
                ProcessLineString(lineString, graphics);
            }
        }

        private void ProcessLineString(LineString lineString, Graphics graphics)
        {
            ProcessPoints(lineString.Points, graphics);
        }

        private void ProcessAbLine(AbLine abLine, Graphics graphics)
        {
            ProcessPoints(new List<Point> {abLine.A.ToUtm(), abLine.B.ToUtm()}, graphics);
        }

        private void ProcessPoints(IEnumerable<Point> points, Graphics graphics)
        {
            var projectedPoints = points.Select(point => point.ToUtm()).ToList();
            var delta = GetDelta(projectedPoints);
            var screenPoints = projectedPoints.Select(point => point.ToXy(_minX, _minY, delta)).ToArray();

            graphics.DrawLines(Pen, screenPoints);
        }

        private void ProcessAPlus(APlus aPlus, Graphics graphics)
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