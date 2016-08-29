using System;
using System.Linq;
using Harmonia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class SortHelperTest
    {
        [TestMethod]
        public void MergeSort_1()
        {
            var target = new[] { 3, 1, 5, 4, 2 };
            var expected = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, target.MergeSort());
        }

        [TestMethod]
        public void MergeSort_2()
        {
            var expected = Enumerable.Range(0, 1000000).ToArray();
            var target = expected.Reverse().ToArray();
            CollectionAssert.AreEqual(expected, target.MergeSort());
        }

        [TestMethod]
        public void BubbleSort_1()
        {
            var target = new[] { 3, 1, 5, 4, 2 };
            var expected = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, target.BubbleSort());
        }

        [TestMethod]
        public void BubbleSort_2()
        {
            var expected = Enumerable.Range(0, 10000).ToArray();
            var target = expected.Reverse().ToArray();
            CollectionAssert.AreEqual(expected, target.BubbleSort());
        }
    }
}
