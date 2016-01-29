using System;
using System.Drawing;

namespace AgGateway.ADAPT.Visualizer
{
   public static class PointExtension
    {
        private const double ConstDeg2Rad = 0.0174532925;
        private const double A = 6378137;
        private const double EccSquared = 0.006694380;
        private const double K0 = 0.9996;
        private const double EccPrimeSquared = (EccSquared) / (1 - EccSquared);

        public static ApplicationDataModel.Point ToUtm(this ApplicationDataModel.Point point)
        {
            var latRad = point.Y * ConstDeg2Rad;
            var longRad = point.X * ConstDeg2Rad;

            var longOriginRad = GetLongOrigin(point.X) * ConstDeg2Rad;

            var n = A / Math.Sqrt(1 - EccSquared * Math.Sin(latRad) * Math.Sin(latRad));
            var t = Math.Tan(latRad) * Math.Tan(latRad);
            var c = EccPrimeSquared * Math.Cos(latRad) * Math.Cos(latRad);
            var a1 = Math.Cos(latRad) * (longRad - longOriginRad);

            var m = A*((1 - EccSquared/4 - 3*EccSquared*EccSquared/64 - 5*EccSquared*EccSquared*EccSquared/256)*latRad
                       -
                       (3*EccSquared/8 + 3*EccSquared*EccSquared/32 + 45*EccSquared*EccSquared*EccSquared/1024)*
                       Math.Sin(2*latRad)
                       + (15*EccSquared*EccSquared/256 + 45*EccSquared*EccSquared*EccSquared/1024)*Math.Sin(4*latRad)
                       - (35*EccSquared*EccSquared*EccSquared/3072)*Math.Sin(6*latRad));

            var utmEasting = K0*n*(a1 + (1 - t + c)*a1*a1*a1/6
                                   + (5 - 18*t + t*t + 72*c - 58*EccPrimeSquared)*a1*a1*a1*a1*a1/120)
                             + 500000.0;

            var utmNorthing = K0*(m + n*Math.Tan(latRad)*(a1*a1/2 + (5 - t + 9*c + 4*c*c)*a1*a1*a1*a1/24
                                                          +
                                                          (61 - 58*t + t*t + 600*c - 330*EccPrimeSquared)*a1*a1*a1*a1*
                                                          a1*a1/720));

            if (point.Y < 0)
            {
                utmNorthing += 10000000.0;
            }

            return new ApplicationDataModel.Point {X = utmEasting, Y = utmNorthing};
        }

        public static PointF ToXy(this ApplicationDataModel.Point point, double minX, double minY, double delta)
        {
            var x = (point.X - minX)/delta+25;
            var y = (point.Y - minY)/delta+25;
             
            return new PointF((float)x, (float)y);
        }

        private static double GetLongOrigin(double lon)
        {
            double longOrigin;
            if (lon > -6 && lon < 0)
            {
                longOrigin = -3;
            }
            else if (lon < 6 && lon >= 0)
            {
                longOrigin = 3;
            }
            else
            {
                longOrigin = (int) (lon/6)*6 + 3*(int) (lon/6)/Math.Abs((int) (lon/6));
            }
            return longOrigin;
        }
    }
}