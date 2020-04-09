using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
	[TestClass]
	public class BucketSortHelperTest
	{
		Random random = new Random();

		[TestMethod]
		public void BucketSort_Int()
		{
			var n = 300000;
			var a = Enumerable.Range(0, n).Select(_ => random.Next(n)).ToArray();

			var a1 = (int[])a.Clone();
			var e1 = (int[])a.Clone();
			TestHelper.MeasureTime(() => BucketSortHelper.BucketSort(a1, n));
			TestHelper.MeasureTime(() => Array.Sort(e1));
			CollectionAssert.AreEqual(e1, a1);
		}

		// 最大値が小さいほど速いです。
		[TestMethod]
		public void BucketSort_IntNorm()
		{
			int next() => random.Next(-10000, 10000);
			int norm((int x, int y) v) => (int)Math.Sqrt(v.x * v.x + v.y * v.y);

			var n = 300000;
			var a = Enumerable.Range(0, n).Select(_ => (next(), next())).ToArray();

			var a1 = ((int x, int y)[])a.Clone();
			var e1 = ((int x, int y)[])a.Clone();
			TestHelper.MeasureTime(() => BucketSortHelper.BucketSort(a1, norm, 15000));
			TestHelper.MeasureTime(() => Array.Sort(Array.ConvertAll(e1, norm), e1));
			CollectionAssert.AreEqual(Array.ConvertAll(e1, norm), Array.ConvertAll(a1, norm));
		}
	}
}
