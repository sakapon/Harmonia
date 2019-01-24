using System;

namespace Harmonia.Numerics
{
    public static class ElementaryFunctions
    {
        public static double GetPi()
        {
            var p = 1.0;
            var sum = 1.0;

            for (var i = 3; i < 100; i += 2)
            {
                p *= -3;

                var temp = sum + 1 / (i * p);
                if (sum == temp) break;
                sum = temp;
            }
            return Math.Sqrt(12) * sum;
        }

        public static double GetE()
        {
            var c = 1.0;
            var sum = 1.0;

            for (var i = 1; i < 100; i++)
            {
                c *= i;

                var temp = sum + 1 / c;
                if (sum == temp) break;
                sum = temp;
            }
            return sum;
        }
    }
}
