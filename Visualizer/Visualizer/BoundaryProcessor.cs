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

using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;

namespace AgGateway.ADAPT.Visualizer
{
    public class BoundaryProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly TabPage _spatialViewer;

        public BoundaryProcessor(TabPage spatialViewer)
        {
            _spatialViewer = spatialViewer;
        }

        public void ProcessBoundary(FieldBoundary fieldBoundary)
        {
            using (var graphics = _spatialViewer.CreateGraphics())
            {
                _drawingUtil = new DrawingUtil(_spatialViewer.Width, _spatialViewer.Height, graphics);

                foreach (var polygon in fieldBoundary.SpatialData.Polygons)
                {
                    var projectedPoints = polygon.ExteriorRing.Points.Select(point => point.ToUtm()).ToList();

                    var delta = _drawingUtil.GetDelta(projectedPoints);
                    _drawingUtil.SetOriginPoint(delta);

                    var screenPolygon = projectedPoints.Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, delta)).ToArray();

                    graphics.DrawPolygon(DrawingUtil.Pen, screenPolygon);
                }
            }
        }
    }
}