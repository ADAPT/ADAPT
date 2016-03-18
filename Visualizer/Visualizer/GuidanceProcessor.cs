/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *    Joseph Ross - Made changes to account for mapping multiple guidence patterns with the same context
  *******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class GuidanceProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly TabPage _spatialViewer;

        public GuidanceProcessor(TabPage spatialViewer)
        {
            _spatialViewer = spatialViewer;
        }

        public void ProcessGuidance(GuidanceGroup guidanceGroup, List<GuidancePattern> guidancePatterns)
        {
            using (var graphics = _spatialViewer.CreateGraphics())
            {
                _drawingUtil = new DrawingUtil(_spatialViewer.Width, _spatialViewer.Height, graphics);

                SetMinMax(guidancePatterns, guidanceGroup.GuidancePatternIds);

                foreach (var id in guidanceGroup.GuidancePatternIds)
                {
                    ProcessGuidancePattern(guidancePatterns, id);
                }
            }
        }

        private void ProcessGuidancePattern(IEnumerable<GuidancePattern> guidancePatterns, int id)
        {
            var guidancePattern = guidancePatterns.First(pattern => pattern.Id.ReferenceId == id);
            ProcessPattern(guidancePattern);
        }

        public void ProccessGuidancePattern(GuidancePattern guidancePattern)
        {
            using (var graphics = _spatialViewer.CreateGraphics())
            {
                _drawingUtil = new DrawingUtil(_spatialViewer.Width, _spatialViewer.Height, graphics);

                SetMinMax(guidancePattern);

                ProcessPattern(guidancePattern);
            }
        }

        private void SetMinMax(IEnumerable<GuidancePattern> guidancePatterns, List<int> guidancePatternIds)
        {
            var matchingGuidancePatterns = guidancePatterns.Where(pattern => guidancePatternIds.Contains(pattern.Id.ReferenceId));

            foreach (var guidancePattern in matchingGuidancePatterns)
            {
                SetMinMax(guidancePattern);
            }
        }

        private void SetMinMax(GuidancePattern guidancePattern)
        {
            if (guidancePattern is APlus)
            {
                (guidancePattern as APlus).SetMinMax(_drawingUtil);
            }
            else if (guidancePattern is AbLine)
            {
                (guidancePattern as AbLine).SetMinMax(_drawingUtil);
            }
            else if (guidancePattern is AbCurve)
            {
                (guidancePattern as AbCurve).SetMinMax(_drawingUtil);
            }
            else if (guidancePattern is CenterPivot)
            {
                (guidancePattern as CenterPivot).SetMinMax(_drawingUtil);
            }
            else if (guidancePattern is MultiAbLine)
            {
                (guidancePattern as MultiAbLine).SetMinMax(_drawingUtil);
            }
            else if (guidancePattern is Spiral)
            {
                (guidancePattern as Spiral).SetMinMax(_drawingUtil);
            }
        }

        private void ProcessPattern(GuidancePattern guidancePattern)
        {
            if (guidancePattern is APlus)
            {
                ProcessAPlus(guidancePattern as APlus);
            }
            else if (guidancePattern is AbLine)
            {
                ProcessAbLine(guidancePattern as AbLine);
            }
            else if (guidancePattern is AbCurve)
            {
                ProcessAbCurve(guidancePattern as AbCurve);
            }
            else if (guidancePattern is CenterPivot)
            {
                ProcessCenterPivot(guidancePattern as CenterPivot);
            }
            else if (guidancePattern is MultiAbLine)
            {
                ProcessMultiAbLine(guidancePattern as MultiAbLine);
            }
            else if (guidancePattern is Spiral)
            {
                ProcessSpiral(guidancePattern as Spiral);
            }
        }

        private void ProcessSpiral(Spiral spiral)
        {
            var delta = _drawingUtil.GetDelta();

            ProcessLineString(spiral.Shape, delta);
        }

        private void ProcessMultiAbLine(MultiAbLine multiAbLine)
        {
            var delta = _drawingUtil.GetDelta();

            foreach (var abLine in multiAbLine.AbLines)
            {
                ProcessPoints(new List<Point> {abLine.A, abLine.B}, delta);
            }
        }

        private void ProcessCenterPivot(CenterPivot centerPivot)
        {
            var delta = _drawingUtil.GetDelta();
            var center = centerPivot.Center.ToUtm().ToXy(_drawingUtil.MinX, _drawingUtil.MinY, delta);
            var radius = GetRadius(centerPivot);
            _drawingUtil.Graphics.DrawEllipse(DrawingUtil.Pen, center.X - radius, center.Y - radius, radius + radius, radius + radius);
        }

        private float GetRadius(CenterPivot centerPivot)
        {
            var width = centerPivot.Center.ToUtm().X - centerPivot.EndPoint.ToUtm().X;
            
            return (float)Math.Abs(width);
        }

        private void ProcessAbCurve(AbCurve abCurve)
        {
            var delta = _drawingUtil.GetDelta();

            foreach (var lineString in abCurve.Shape)
            {
                ProcessLineString(lineString, delta);
            }
        }

        private void ProcessAbLine(AbLine abLine)
        {
            var delta = _drawingUtil.GetDelta();

            ProcessPoints(new List<Point> {abLine.A, abLine.B}, delta);
        }

        private void ProcessAPlus(APlus aPlus)
        {
            var delta = _drawingUtil.GetDelta();
            var projectedPoint = aPlus.Point;
        }

        private void ProcessLineString(LineString lineString, double delta)
        {
            ProcessPoints(lineString.Points, delta);
        }

        private void ProcessPoints(IEnumerable<Point> points, double delta)
        {
            if (!points.Any() || points.Count() == 1)
                return;

            if (delta == 0.0)
                delta = 1.0;
            var screenPoints = points.Select(point => point.ToUtm()).Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, delta)).ToArray();

            _drawingUtil.Graphics.DrawLines(DrawingUtil.Pen, screenPoints);
        }
    }
}