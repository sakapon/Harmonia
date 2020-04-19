using System;

namespace Harmonia.Numerics
{
    public static class Numbers
    {
        public static int Gcd(int x, int y)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x), x, "The value must be a natural number.");
            if (y <= 0) throw new ArgumentOutOfRangeException(nameof(y), y, "The value must be a natural number.");

            var M = x;
            var m = y;

            while (true)
            {
                var r = M % m;
                if (r == 0) return m;
                M = m;
                m = r;
            }
        }

        public static int Lcm(int x, int y) => x / Gcd(x, y) * y;

        public static bool IsSquareNumber(int x)
        {
            var r = Math.Sqrt(x);
            return Math.Round(r) == r;
        }

        public static long Pow(long b, long i)
        {
            for (var r = 1L; ; b *= b)
            {
                if ((i & 1) != 0) r *= b;
                if ((i >>= 1) == 0) return r;
            }
        }

        public static double Pow(double b, long i)
        {
            for (var r = 1.0; ; b *= b)
            {
                if ((i & 1) != 0) r *= b;
                if ((i >>= 1) == 0) return r;
            }
        }

        public static decimal Pow(decimal b, long i)
        {
            for (var r = 1m; ; b *= b)
            {
                if ((i & 1) != 0) r *= b;
                if ((i >>= 1) == 0) return r;
            }
        }
    }
}
