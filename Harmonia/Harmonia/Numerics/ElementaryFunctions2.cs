using System;
using System.Collections.Generic;

namespace Harmonia.Numerics
{
    public static class ElementaryFunctions2
    {
        public static double SumForApproximation(this IEnumerable<double> terms)
        {
            var sum = 0.0;

            foreach (var v in terms)
            {
                var temp = sum + v;
                if (sum == temp) break;
                sum = temp;
            }
            return sum;
        }

        public static double Recurse(Func<double, double> func, double x0, int count = 100)
        {
            var r = x0;

            for (var i = 0; i < count; i++)
            {
                var temp = func(r);
                if (r == temp) break;
                r = temp;
            }
            return r;
        }

        public static double Exp(double x)
        {
            return GetTerms().SumForApproximation();

            IEnumerable<double> GetTerms()
            {
                var c = 1.0;
                var p = 1.0;
                yield return 1.0;

                for (var i = 1; i < 100; i++)
                {
                    c *= i;
                    p *= x;
                    yield return p / c;
                }
            }
        }

        public static double Log(double x)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x), x, "The value must be positive.");

            return 2 * GetTerms().SumForApproximation();

            IEnumerable<double> GetTerms()
            {
                // http://math-lab.main.jp/taylor7b.html
                var t = (x - 1) / (x + 1);

                var t2 = t * t;
                var p = t;
                yield return t;

                for (var i = 3; i < 100; i += 2)
                {
                    p *= t2;
                    yield return p / i;
                }
            }
        }

        public static double Sqrt(double x) => Recurse(t => (t + x / t) / 2, x);

        public static double Cbrt(double x) => Recurse(t => (2 * t + x / (t * t)) / 3, x);
    }
}
