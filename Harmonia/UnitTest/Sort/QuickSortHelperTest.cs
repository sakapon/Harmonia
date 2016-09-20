using System;
using System.Linq;
using Harmonia.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
    [TestClass]
    public class QuickSortHelperTest
    {
        [TestMethod]
        public void QuickSort_1()
        {
            var start = 1;
            var count = 10000;
            var expected = Enumerable.Range(start, count).ToArray();

            for (var i = 0; i < 10; i++)
            {
                var target = RandomHelper.ShuffleRange(start, count).ToArray();
                target.QuickSort();
                CollectionAssert.AreEqual(expected, target);
            }
        }

        [TestMethod]
        public void QuickSort_2()
        {
            var start = 1;
            var count = 10000;
            var expected = Enumerable.Range(start, count).ToArray();
            var target = Enumerable.Range(start, count).ToArray();
            target.QuickSort();
            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void QuickSort_3()
        {
            var start = 1;
            var count = 10000;
            var expected = Enumerable.Range(start, count).ToArray();
            var target = Enumerable.Range(start, count).Reverse().ToArray();
            target.QuickSort();
            CollectionAssert.AreEqual(expected, target);
        }
    }
}
