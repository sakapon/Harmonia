using System;
using System.Linq;
using Harmonia.Sort;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
	[TestClass]
	public class HeapSortHelperTest
	{
		[TestMethod]
		public void HeapSort_Asc()
		{
			var values = RandomHelper.CreateData(300000);
			var actual = TimeHelper.Measure(() => values.HeapSort().Take(1000).ToArray());
			var expected = TimeHelper.Measure(() => values.OrderBy(x => x).Take(1000).ToArray());
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void HeapSort_Desc()
		{
			var values = RandomHelper.CreateData(300000);
			var actual = TimeHelper.Measure(() => values.HeapSort(true).Take(1000).ToArray());
			var expected = TimeHelper.Measure(() => values.OrderBy(x => -x).Take(1000).ToArray());
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void HeapSort_Key_Asc()
		{
			var values = RandomHelper.CreateData(300000);
			var actual = TimeHelper.Measure(() => values.HeapSort(x => x.ToString()).Take(1000).ToArray());
			var expected = TimeHelper.Measure(() => values.OrderBy(x => x.ToString()).Take(1000).ToArray());
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void HeapSort_Key_Desc()
		{
			var values = RandomHelper.CreateData(300000);
			var actual = TimeHelper.Measure(() => values.HeapSort(x => x.ToString(), true).Take(1000).ToArray());
			var expected = TimeHelper.Measure(() => values.OrderByDescending(x => x.ToString()).Take(1000).ToArray());
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
