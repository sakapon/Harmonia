using System;
using System.Collections.Generic;

namespace Harmonia.Trees
{
	// 1-indexed
	public class Heap1<T>
	{
		public static Heap1<T> Create(T[] vs = null, bool desc = false)
		{
			var c = Comparer<T>.Default;
			return desc ?
				new Heap1<T>(vs, (x, y) => c.Compare(y, x)) :
				new Heap1<T>(vs, c.Compare);
		}

		public static Heap1<T> Create<TKey>(Func<T, TKey> getKey, T[] vs = null, bool desc = false)
		{
			var c = Comparer<TKey>.Default;
			return desc ?
				new Heap1<T>(vs, (x, y) => c.Compare(getKey(y), getKey(x))) :
				new Heap1<T>(vs, (x, y) => c.Compare(getKey(x), getKey(y)));
		}

		List<T> l = new List<T> { default(T) };
		Comparison<T> c;

		public T First => l[1];
		public int Count => l.Count - 1;
		public bool Any => l.Count > 1;

		Heap1(T[] vs, Comparison<T> _c)
		{
			c = _c;
			if (vs != null) foreach (var v in vs) Push(v);
		}

		void Swap(int i, int j) { var o = l[i]; l[i] = l[j]; l[j] = o; }
		void UpHeap(int i) { for (int j; (j = i / 2) > 0 && c(l[j], l[i]) > 0; Swap(i, i = j)) ; }
		void DownHeap(int i)
		{
			for (int j; (j = 2 * i) < l.Count;)
			{
				if (j + 1 < l.Count && c(l[j], l[j + 1]) > 0) j++;
				if (c(l[i], l[j]) > 0) Swap(i, i = j); else break;
			}
		}

		public void Push(T v)
		{
			l.Add(v);
			UpHeap(Count);
		}

		public T Pop()
		{
			var r = l[1];
			l[1] = l[Count];
			l.RemoveAt(Count);
			DownHeap(1);
			return r;
		}
	}
}
