using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Trees
{
	[TestClass]
	public class Heap1Test
	{
		Random random = new Random();

		[TestMethod]
		public void Sort()
		{
			var values = Enumerable.Range(0, 100000).Select(i => random.Next(100000)).ToArray();
			var actual = TestHelper.MeasureTime(() => Heap1<int>.Create(values));
			var a = new int[values.Length];
			TestHelper.MeasureTime(() => { for (var i = 0; i < a.Length; i++) a[i] = actual.Pop(); });
			var e = (int[])values.Clone();
			TestHelper.MeasureTime(() => Array.Sort(e));
			CollectionAssert.AreEqual(e, a);
		}

		[TestMethod]
		public void SortDescending()
		{
			var values = Enumerable.Range(0, 100000).Select(i => random.Next(100000)).ToArray();
			var actual = TestHelper.MeasureTime(() => Heap1<int>.Create(values, true));
			var a = new int[values.Length];
			TestHelper.MeasureTime(() => { for (var i = 0; i < a.Length; i++, actual.Pop()) a[i] = actual.First; });
			var e = TestHelper.MeasureTime(() => values.OrderByDescending(x => x).ToArray());
			CollectionAssert.AreEqual(e, a);
		}

		[TestMethod]
		public void SortDescending_String()
		{
			var values = Enumerable.Range(0, 100000).Select(i => random.Next(100000)).ToArray();
			var actual = TestHelper.MeasureTime(() => Heap1<int>.Create(x => x.ToString(), values, true));
			var a = new List<int>();
			TestHelper.MeasureTime(() => { while (actual.Any) a.Add(actual.Pop()); });
			var e = TestHelper.MeasureTime(() => values.OrderByDescending(x => x.ToString()).ToArray());
			CollectionAssert.AreEqual(e, a);
		}
	}
}
