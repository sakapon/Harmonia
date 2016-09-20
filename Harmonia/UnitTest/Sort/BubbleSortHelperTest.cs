using System;
using System.Linq;
using Harmonia.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Sort
{
    [TestClass]
    public class BubbleSortHelperTest
    {
        [TestMethod]
        public void BubbleSort_1()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, new[] { 1, 2, 3, 4, 5 }.BubbleSort());
            CollectionAssert.AreEqual(expected, new[] { 5, 4, 3, 2, 1 }.BubbleSort());
            CollectionAssert.AreEqual(expected, new[] { 4, 2, 5, 1, 3 }.BubbleSort());
            CollectionAssert.AreEqual(expected, new[] { 3, 1, 5, 4, 2 }.BubbleSort());
        }

        [TestMethod]
        public void BubbleSort_2()
        {
            var expected = Enumerable.Range(0, 10000).ToArray();
            var target = expected.Reverse().ToArray();
            CollectionAssert.AreEqual(expected, target.BubbleSort());
        }

        [TestMethod]
        public void BubbleSort_3()
        {
            var target = Enumerable.Range(1, 20).Select(i => i * i).ToArray();
            var actual = target.BubbleSort(i => i.ToString());

            foreach (var i in actual)
                Console.WriteLine(i);
        }
    }
}
