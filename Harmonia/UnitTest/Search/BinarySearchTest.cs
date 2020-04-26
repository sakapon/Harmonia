using System;
using System.Collections.Generic;
using System.Linq;
using Harmonia.Search;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Search
{
	[TestClass]
	public class BinarySearchTest
	{
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
				var a = RandomHelper.CreateData(n).OrderBy(x => x).ToArray();
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
				var a = RandomHelper.CreateData(n).OrderBy(x => -x).ToArray();
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
			Assert2.AreNearlyEqual(10, BinarySearch.First(0.0, 100, x => x * x >= 100), -9);
			Assert2.AreNearlyEqual(15, BinarySearch.First(15.0, 20, x => x * x >= 100), -9);
			Assert.AreEqual(5, BinarySearch.First(0.0, 5, x => x * x >= 100));

			Assert2.AreNearlyEqual(Math.Sqrt(3), BinarySearch.First(0.0, 10, x => x * x > 3), -9);
		}

		[TestMethod]
		public void Last_Sqrt()
		{
			Assert2.AreNearlyEqual(10, BinarySearch.Last(0.0, 100, x => x * x < 100), -9);
			Assert2.AreNearlyEqual(5, BinarySearch.Last(0.0, 5, x => x * x < 100), -9);
			Assert.AreEqual(15, BinarySearch.Last(15.0, 20, x => x * x < 100));

			Assert2.AreNearlyEqual(Math.Sqrt(3), BinarySearch.Last(0.0, 10, x => x * x <= 3), -9);
		}
	}
}
