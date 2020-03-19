using System;

namespace Harmonia.Search
{
	public static class BinarySearch
	{
		// 条件 f を満たす最初の値を探索します。
		// f(r) は評価されません。
		// f(r - 1) が false のとき、r を返します。
		public static int First(int l, int r, Func<int, bool> f)
		{
			int m;
			while (l < r)
				if (f(m = l + (r - l - 1) / 2)) r = m;
				else l = m + 1;
			return r;
		}

		// 条件 f を満たす最後の値を探索します。
		// f(l) は評価されません。
		// f(l + 1) が false のとき、l を返します。
		public static int Last(int l, int r, Func<int, bool> f)
		{
			int m;
			while (l < r)
				if (f(m = r - (r - l - 1) / 2)) l = m;
				else r = m - 1;
			return l;
		}

		public static double First(double l, double r, Func<double, bool> f, int digits = 9)
		{
			double m;
			while (Math.Round(r - l, digits) > 0)
				if (f(m = l + (r - l) / 2)) r = m;
				else l = m;
			return r;
		}

		public static double Last(double l, double r, Func<double, bool> f, int digits = 9)
		{
			double m;
			while (Math.Round(r - l, digits) > 0)
				if (f(m = r - (r - l) / 2)) l = m;
				else r = m;
			return l;
		}
	}
}
