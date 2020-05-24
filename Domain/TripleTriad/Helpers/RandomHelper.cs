using System;

namespace TripleTriad.Helpers
{
    public static class RandomHelper
    {
        private static int NewHashCode => Guid.NewGuid().GetHashCode();

        public static bool NextBool(double probability)
        {
            var random = new Random(NewHashCode);
            return random.NextDouble() <= probability;
        }
    }
}