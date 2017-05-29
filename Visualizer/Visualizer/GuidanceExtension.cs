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
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public static class GuidanceExtension
    {
        public static void SetMinMax(this APlus aPlus, DrawingUtil drawingUtil)
        {
            var points = new List<Point> {aPlus.Point.ToUtm()};

            SetMinMax(drawingUtil, points);
        }

        public static void SetMinMax(this AbLine abLine, DrawingUtil drawingUtil)
        {
            var points = new List<Point> {abLine.A.ToUtm(), abLine.B.ToUtm()};

            SetMinMax(drawingUtil, points);
        }

        public static void SetMinMax(this AbCurve abCurve, DrawingUtil drawingUtil)
        {
            var points = abCurve.Shape.SelectMany(x => x.Points).Select(x => x.ToUtm()).ToList();

            SetMinMax(drawingUtil, points);
        }

        public static void SetMinMax(this PivotGuidancePattern centerPivot, DrawingUtil drawingUtil)
        {
            var centerUtm = centerPivot.Center.ToUtm();
            var radius = Math.Abs(centerUtm.X - centerPivot.EndPoint.ToUtm().X);

            var northPoint = new Point
            {
                X = centerUtm.X,
                Y = centerUtm.Y + radius,
            };
            var southPoint = new Point
            {
                X = centerUtm.X,
                Y = centerUtm.Y - radius,
            };
            var westPoint = new Point
            {
                X = centerUtm.X - radius,
                Y = centerUtm.Y,
            };
            var eastPoint = new Point
            {
                X = centerUtm.X + radius,
                Y = centerUtm.Y,
            };

            var points = new List<Point>
            {
                northPoint,
                southPoint,
                westPoint,
                eastPoint
            };

            SetMinMax(drawingUtil, points);
        }

        public static void SetMinMax(this MultiAbLine multiAbLine, DrawingUtil drawingUtil)
        {
            var points = multiAbLine.AbLines.SelectMany(x => new List<Point> {x.A.ToUtm(), x.B.ToUtm()}).ToList();

            SetMinMax(drawingUtil, points);
        }

        public static void SetMinMax(this Spiral spiral, DrawingUtil drawingUtil)
        {
            var points = spiral.Shape.Points.Select(x => x.ToUtm()).ToList();

            SetMinMax(drawingUtil, points);
        }

        private static void SetMinMax(DrawingUtil drawingUtil, List<Point> points)
        {
            drawingUtil.SetMinMax(points);
        }
    }
}