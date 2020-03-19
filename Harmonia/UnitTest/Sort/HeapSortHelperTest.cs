using System;
using System.Linq;
using Harmonia.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
	[TestClass]
	public class HeapSortHelperTest
	{
		Random random = new Random();

		[TestMethod]
		public void SortTake()
		{
			var values = Enumerable.Range(0, 300000).Select(i => random.Next(300000)).ToArray();
			var actual = TestHelper.MeasureTime(() => values.HeapSort().Take(1000).ToArray());
			var expected = TestHelper.MeasureTime(() => values.OrderBy(x => x).Take(1000).ToArray());
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
