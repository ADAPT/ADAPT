using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class DrawingUtil
    {
        private readonly int _width;
        private readonly int _height;
        private double _maxX;
        private double _maxY;

        public DrawingUtil(int width, int height, Graphics graphics)
        {
            _width = width;
            _height = height;
            Graphics = graphics;
        }

        public double MinX { get; private set; }
        public double MinY { get; private set; }
        public Graphics Graphics { get; private set; }

        public static Pen Pen
        {
            get { return new Pen(Color.Black, 2); }
        }

        public double GetDelta(IList<Point> points)
        {
            double delta;
            MinX = points.Min(point => point.X);
            _maxX = points.Max(point => point.X);
            MinY = points.Min(point => point.Y);
            _maxY = points.Max(point => point.Y);

            var lonDistance = (_maxX - MinX);
            var latDistance = (_maxY - MinY);

            var width = _width - 50;
            var height = _height - 50;

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

        public void SetOriginPoint(double delta)
        {
            if (delta == 0.0)
                delta = 1.0;
            var max = ((_maxY - MinY)/delta + 25) + 20;
            Graphics.Transform = new Matrix(1, 0, 0, -1, 0, (float) max);
        }
    }
}