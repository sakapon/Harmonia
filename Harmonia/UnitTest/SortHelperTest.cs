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
            var expected = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, new[] { 1, 2, 3, 4, 5 }.MergeSort());
            CollectionAssert.AreEqual(expected, new[] { 5, 4, 3, 2, 1 }.MergeSort());
            CollectionAssert.AreEqual(expected, new[] { 4, 2, 5, 1, 3 }.MergeSort());
            CollectionAssert.AreEqual(expected, new[] { 3, 1, 5, 4, 2 }.MergeSort());
        }

        [TestMethod]
        public void MergeSort_2()
        {
            var expected = Enumerable.Range(0, 1000000).ToArray();
            var target = expected.Reverse().ToArray();
            CollectionAssert.AreEqual(expected, target.MergeSort());
        }

        [TestMethod]
        public void MergeSort_3()
        {
            var target = Enumerable.Range(1, 20).Select(i => i * i).ToArray();
            var actual = target.MergeSort(i => i.ToString());

            foreach (var i in actual)
                Console.WriteLine(i);
        }
    }
}
