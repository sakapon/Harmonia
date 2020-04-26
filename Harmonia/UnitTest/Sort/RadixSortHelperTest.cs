using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Sort;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
	[TestClass]
	public class RadixSortHelperTest
	{
		Random random = new Random();

		[TestMethod]
		public void RadixSort_Int32()
		{
			var n = 300000;
			var a = Enumerable.Range(0, n).Select(_ => random.Next(int.MinValue, int.MaxValue)).ToArray();

			var a1 = (int[])a.Clone();
			var e1 = (int[])a.Clone();
			TimeHelper.Measure(() => RadixSortHelper.RadixSort(a1));
			TimeHelper.Measure(() => Array.Sort(e1));
			CollectionAssert.AreEqual(e1, a1);
		}

		[TestMethod]
		public void RadixSort_Int64()
		{
			var n = 300000;
			var a = Enumerable.Range(0, n).Select(_ => (long)random.Next(int.MinValue, int.MaxValue) * random.Next(int.MinValue, int.MaxValue)).ToArray();

			var a1 = (long[])a.Clone();
			var e1 = (long[])a.Clone();
			TimeHelper.Measure(() => RadixSortHelper.RadixSort(a1));
			TimeHelper.Measure(() => Array.Sort(e1));
			CollectionAssert.AreEqual(e1, a1);
		}
	}
}
