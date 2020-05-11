namespace Harmonia.Numerics
{
	public static class Arithmetic
	{
		public static int Add(int x, int y)
		{
			var r = x ^ y;
			var t = (x & y) << 1;
			return t == 0 ? r : Add(r, t);
		}

		public static int Subtract(int x, int y)
		{
			return Add(x, Add(~y, 1));
		}

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
	}
}
