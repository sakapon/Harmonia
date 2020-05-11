using System;

namespace Harmonia.Numerics
{
	public static class Arithmetic
	{
		public static int Negate(int x) => Add(~x, 1);

		public static int Abs(int x) => x >= 0 ? x : Negate(x);

		public static int Add(int x, int y)
		{
			var xor = x ^ y;
			var and = (x & y) << 1;
			return and == 0 ? xor : Add(xor, and);
		}

		public static int Subtract(int x, int y) => Add(x, Negate(y));

		// unsigned
		public static byte Multiply(byte x, byte y)
		{
			byte r = 0;
			for (; x != 0 && y != 0; x <<= 1, y >>= 1)
				if ((y & 1) != 0) r += x;
			return r;
		}

		// signed
		public static int Multiply(int x, int y)
		{
			var r = 0;
			for (; x != 0 && y != 0; x <<= 1, y >>= 1)
				if ((y & 1) != 0) r += x;
			return r;
		}

		public static int Quotient(int x, int y) => Divide(x, y).q;
		public static int Remainder(int x, int y) => Divide(x, y).r;

		public static (int q, int r) Divide(int x, int y)
		{
			if (y == 0) throw new DivideByZeroException();
			var (s, t) = ForPositive(Abs(x), Abs(y));
			return (x > 0 == y > 0 ? s : Negate(s), x > 0 ? t : Negate(t));

			(int, int) ForPositive(int a, int b)
			{
				int q = 0, f = 1;
				for (; (b & 0x40000000) == 0; b <<= 1, f <<= 1) ;
				for (; a != 0 && f != 0; b >>= 1, f >>= 1)
					if (a >= b) { a -= b; q |= f; }
				return (q, a);
			}
		}
	}
}
