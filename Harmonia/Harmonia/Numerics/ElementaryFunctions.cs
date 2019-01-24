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

        public static double Sin(double x)
        {
            var _x2 = -x * x;
            var c = 1.0;
            var p = x;
            var sum = x;

            for (var i = 3; i < 100; i += 2)
            {
                c *= i * (i - 1);
                p *= _x2;

                var temp = sum + p / c;
                if (sum == temp) return sum;
                sum = temp;
            }
            return sum;
        }

        public static double Cos(double x)
        {
            var _x2 = -x * x;
            var c = 1.0;
            var p = 1.0;
            var sum = 1.0;

            for (var i = 2; i < 100; i += 2)
            {
                c *= i * (i - 1);
                p *= _x2;

                var temp = sum + p / c;
                if (sum == temp) return sum;
                sum = temp;
            }
            return sum;
        }

        public static double Exp(double x)
        {
            var c = 1.0;
            var p = 1.0;
            var sum = 1.0;

            for (var i = 1; i < 100; i++)
            {
                c *= i;
                p *= x;

                var temp = sum + p / c;
                if (sum == temp) break;
                sum = temp;
            }
            return sum;
        }
    }
}
