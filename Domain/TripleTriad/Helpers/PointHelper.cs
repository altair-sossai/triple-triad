using System;

namespace TripleTriad.Helpers
{
    public static class PointHelper
    {
        public static int? MaxMin(int? point)
        {
            if (point == null)
                return null;

            return MaxMin(point.Value);
        }

        public static int MaxMin(int point)
        {
            return Math.Max(0, Math.Min(10, point));
        }

        public static int? Sum(int? point, int? additionalPoint)
        {
            if (point == null)
                return null;

            if (additionalPoint == null)
                return point.Value;

            return point.Value + additionalPoint.Value;
        }
    }
}