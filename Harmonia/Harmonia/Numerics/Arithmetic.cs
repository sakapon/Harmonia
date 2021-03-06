﻿using System;

namespace Harmonia.Numerics
{
	public static class Arithmetic
	{
		// 1 << 31 == int.MinValue
		const int f31 = 1 << 31;

		// f31 -> f31
		public static int Negate(int x) => Add(~x, 1);
#if Other
		public static int Negate(int x) => ~Subtract(x, 1);
#endif

		public static int Abs(int x) => (x & f31) == 0 ? x : Negate(x);

		public static bool LessThan(int x, int y)
		{
			var nx = (x & f31) != 0;
			var ny = (y & f31) != 0;
			return (nx ^ ny) ? nx : ((x - y) & f31) != 0;
		}

		public static int Add(int x, int y)
		{
			var xor = x ^ y;
			var carry = (x & y) << 1;
			return carry == 0 ? xor : Add(xor, carry);
		}

		public static int Subtract(int x, int y)
		{
			var xor = x ^ y;
			var carry = (xor & y) << 1;
			return carry == 0 ? xor : Subtract(xor, carry);
		}
#if Other
		public static int Subtract(int x, int y) => Add(x, Negate(y));
#endif

		// Same for signed and unsigned.
		public static int Multiply(int x, int y)
		{
			var r = 0;
			for (; x != 0 && y != 0; x <<= 1, y >>= 1)
				if ((y & 1) != 0) r = Add(r, x);
			return r;
		}

		public static int Quotient(int x, int y) => Divide(x, y).q;
		public static int Remainder(int x, int y) => Divide(x, y).r;

		// x または y が int.MinValue の場合、組込み演算の結果と等しくならないことがあります。
		// y = y >> 1 & int.MaxValue などとして最上位ビットを扱う方法が考えられます。
		public static (int q, int r) Divide(int x, int y)
		{
			if (y == 0) throw new DivideByZeroException();

			var nx = (x & f31) != 0;
			var ny = (y & f31) != 0;
			if (nx || ny)
			{
				var (s, t) = Divide(Abs(x), Abs(y));
				return (nx == ny ? s : Negate(s), !nx ? t : Negate(t));
			}

			int q = 0, f = 1;
			for (; (y & 1 << 30) == 0 && LessThan(y, x); y <<= 1, f <<= 1) ;
			for (; x != 0 && f != 0; y >>= 1, f >>= 1)
				if (!LessThan(x, y)) { x = Subtract(x, y); q |= f; }
			return (q, x);
		}
	}
}
