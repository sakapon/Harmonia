using System;
using System.Collections.Generic;

namespace Harmonia.Sort
{
	public static class BucketSortHelper
	{
		// 値の範囲は [0, max]
		// O(n + max)
		public static void BucketSort(this int[] source, int max)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));

			var b = new int[max + 1];
			foreach (var x in source)
				++b[x];
			for (int i = -1, x = 0; x <= max; ++x)
				for (int k = 0; k < b[x]; ++k)
					source[++i] = x;
		}

		// 値の範囲は [0, max]
		// O(n + max)
		public static void BucketSort<T>(this T[] source, Func<T, int> keySelector, int max)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));

			var b = new List<T>[max + 1];

			int key;
			foreach (var o in source)
				if (b[key = keySelector(o)] == null) b[key] = new List<T> { o };
				else b[key].Add(o);

			var i = -1;
			foreach (var l in b)
				if (l != null)
					foreach (var o in l)
						source[++i] = o;
		}
	}
}
