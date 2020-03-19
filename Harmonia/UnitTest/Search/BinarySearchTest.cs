using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Search
{
	[TestClass]
	public class BinarySearchTest
	{
		static readonly Random random = new Random();

		[TestMethod]
		public void FirstGt_Random()
		{
			for (int k = 0; k < 10; k++)
			{
				for (int n = 0; n < 10; n++) Test(n);
				for (int n = 1000; n < 1010; n++) Test(n);
			}

			void Test(int n)
			{
				var a = Enumerable.Range(0, n).Select(_ => random.Next(0, n)).OrderBy(x => x).ToArray();
				for (int x = -2; x < n + 2; x++)
				{
					var actual = BinarySearch.First(0, n, i => a[i] > x);
					Assert.IsTrue(actual == n || a[actual] > x);
					Assert.IsTrue(actual == 0 || a[actual - 1] <= x);
				}
			}
		}

		[TestMethod]
		public void LastGt_Random()
		{
			for (int k = 0; k < 10; k++)
			{
				for (int n = 0; n < 10; n++) Test(n);
				for (int n = 1000; n < 1010; n++) Test(n);
			}

			void Test(int n)
			{
				var a = Enumerable.Range(0, n).Select(_ => random.Next(0, n)).OrderBy(x => -x).ToArray();
				for (int x = -2; x < n + 2; x++)
				{
					var actual = BinarySearch.Last(-1, n - 1, i => a[i] > x);
					Assert.IsTrue(actual == -1 || a[actual] > x);
					Assert.IsTrue(actual == n - 1 || a[actual + 1] <= x);
				}
			}
		}

		[TestMethod]
		public void First_Sqrt()
		{
			TestHelper.AssertNearlyEqual(10, BinarySearch.First(0.0, 100, x => x * x >= 100));
			TestHelper.AssertNearlyEqual(15, BinarySearch.First(15.0, 20, x => x * x >= 100));
			Assert.AreEqual(5, BinarySearch.First(0.0, 5, x => x * x >= 100));

			TestHelper.AssertNearlyEqual(Math.Sqrt(3), BinarySearch.First(0.0, 10, x => x * x > 3));
		}

		[TestMethod]
		public void Last_Sqrt()
		{
			TestHelper.AssertNearlyEqual(10, BinarySearch.Last(0.0, 100, x => x * x < 100));
			TestHelper.AssertNearlyEqual(5, BinarySearch.Last(0.0, 5, x => x * x < 100));
			Assert.AreEqual(15, BinarySearch.Last(15.0, 20, x => x * x < 100));

			TestHelper.AssertNearlyEqual(Math.Sqrt(3), BinarySearch.Last(0.0, 10, x => x * x <= 3));
		}
	}
}
