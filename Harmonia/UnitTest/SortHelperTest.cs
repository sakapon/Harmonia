using System;
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
        public void BubbleSort_1()
        {
            var target = new[] { 3, 1, 5, 4, 2 };
            var expected = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, target.BubbleSort());
        }
    }
}
