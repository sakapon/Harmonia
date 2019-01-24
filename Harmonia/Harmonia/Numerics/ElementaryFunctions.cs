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

        public static double Tan(double x)
        {
            return Sin(x) / Cos(x);
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

        public static double Log(double x)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x), x, "The value must be positive.");

            // http://math-lab.main.jp/taylor7b.html
            var t = (x - 1) / (x + 1);

            var t2 = t * t;
            var p = t;
            var sum = t;

            for (var i = 3; i < 100; i += 2)
            {
                p *= t2;

                var temp = sum + p / i;
                if (sum == temp) break;
                sum = temp;
            }
            return 2 * sum;
        }

        public static double Pow(double x, double p)
        {
            return Exp(p * Log(x));
        }

        public static double Sqrt(double x)
        {
            var r = x;

            for (var i = 0; i < 100; i++)
            {
                var temp = (r + x / r) / 2;
                if (r == temp) break;
                r = temp;
            }
            return r;
        }

        public static double Cbrt(double x)
        {
            var r = x;

            for (var i = 0; i < 100; i++)
            {
                var temp = (2 * r + x / (r * r)) / 3;
                if (r == temp) break;
                r = temp;
            }
            return r;
        }
    }
}
