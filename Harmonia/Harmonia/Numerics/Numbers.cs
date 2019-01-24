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

        public static int Lcm(int x, int y) => x * y / Gcd(x, y);

        public static bool IsSquareNumber(int x)
        {
            var r = Math.Sqrt(x);
            return Math.Round(r) == r;
        }
    }
}
