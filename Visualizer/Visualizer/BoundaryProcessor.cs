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
                    _drawingUtil.SetMinMax(projectedPoints);
                    
                    var screenPolygon = projectedPoints.Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, _drawingUtil.GetDelta())).ToArray();

                    graphics.DrawPolygon(DrawingUtil.Pen, screenPolygon);
                }
            }
        }
    }
}