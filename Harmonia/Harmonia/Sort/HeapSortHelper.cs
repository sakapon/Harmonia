using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Trees;

namespace Harmonia.Sort
{
	public static class HeapSortHelper
	{
		public static IEnumerable<TSource> HeapSort<TSource>(this IEnumerable<TSource> source, bool descending = false)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			var heap = Heap1.Create(source, descending);
			while (heap.Any) yield return heap.Pop();
		}

		public static IEnumerable<TSource> HeapSort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending = false)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

			var heap = Heap1.Create(v => v.k, source.Select(o => (o: o, k: keySelector(o))), descending);
			while (heap.Any) yield return heap.Pop().o;
		}
	}
}
