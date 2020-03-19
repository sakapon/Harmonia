using System;
using System.Collections.Generic;

namespace Harmonia.Trees
{
	public static class Heap1
	{
		public static Heap1<T> Create<T>(IEnumerable<T> values = null, bool descending = false)
		{
			var c = Comparer<T>.Default;
			return descending ?
				new Heap1<T>(values, (x, y) => c.Compare(y, x)) :
				new Heap1<T>(values, c.Compare);
		}

		public static Heap1<T> Create<T, TKey>(Func<T, TKey> keySelector, IEnumerable<T> values = null, bool descending = false)
		{
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

			var c = Comparer<TKey>.Default;
			return descending ?
				new Heap1<T>(values, (x, y) => c.Compare(keySelector(y), keySelector(x))) :
				new Heap1<T>(values, (x, y) => c.Compare(keySelector(x), keySelector(y)));
		}
	}

	/// <summary>
	/// Represents a binary heap.
	/// </summary>
	/// <typeparam name="T">The type of the object.</typeparam>
	/// <remarks>
	/// 内部では 1-indexed のため、raw array (直接のソートなど) では使われません。
	/// したがって、実質的に Priority Queue として使われます。
	/// </remarks>
	public class Heap1<T>
	{
		List<T> l = new List<T> { default(T) };
		Comparison<T> c;

		public T First
		{
			get
			{
				if (l.Count <= 1) throw new InvalidOperationException("The heap is empty.");
				return l[1];
			}
		}

		public int Count => l.Count - 1;
		public bool Any => l.Count > 1;

		internal Heap1(IEnumerable<T> values, Comparison<T> comparison)
		{
			c = comparison ?? throw new ArgumentNullException(nameof(comparison));
			if (values != null) foreach (var v in values) Push(v);
		}

		// x の親: x/2
		// x の子: 2x, 2x+1
		void Swap(int i, int j) { var o = l[i]; l[i] = l[j]; l[j] = o; }
		void UpHeap(int i)
		{
			for (int j; (j = i / 2) > 0 && c(l[j], l[i]) > 0;)
				Swap(i, i = j);
		}
		void DownHeap(int i)
		{
			for (int j; (j = 2 * i) < l.Count;)
			{
				if (j + 1 < l.Count && c(l[j], l[j + 1]) > 0) j++;
				if (c(l[i], l[j]) > 0) Swap(i, i = j); else break;
			}
		}

		public void Push(T value)
		{
			l.Add(value);
			UpHeap(Count);
		}

		public T Pop()
		{
			if (l.Count <= 1) throw new InvalidOperationException("The heap is empty.");

			var r = l[1];
			l[1] = l[Count];
			l.RemoveAt(Count);
			DownHeap(1);
			return r;
		}
	}
}
