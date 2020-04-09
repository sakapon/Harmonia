using System;

namespace Harmonia.Sort
{
	public static class RadixSortHelper
	{
		// Int32 のすべての値が対象です。
		public static void RadixSort(this int[] source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			var f = 0xFF;
			source.BucketSort(x => x & f, f);
			source.BucketSort(x => x >> 8 & f, f);
			source.BucketSort(x => x >> 16 & f, f);
			source.BucketSort(x => x >> 24 & f ^ 0x80, f);
		}

		// Int64 のすべての値が対象です。
		public static void RadixSort(this long[] source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			var f = 0xFF;
			source.BucketSort(x => (int)x & f, f);
			for (int b = 8; b < 56; b += 8)
				source.BucketSort(x => (int)(x >> b) & f, f);
			source.BucketSort(x => (int)(x >> 56) & f ^ 0x80, f);
		}
	}
}
