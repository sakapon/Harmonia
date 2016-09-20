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
            var start = 1;
            var count = 1000;
            var expected = Enumerable.Range(start, count).ToArray();

            for (var i = 0; i < 10; i++)
            {
                var target = RandomHelper.ShuffleRange(start, count).ToArray();
                target.BubbleSort();
                CollectionAssert.AreEqual(expected, target);
            }
        }

        [TestMethod]
        public void BubbleSort_2()
        {
            var start = 1;
            var count = 10000;
            var expected = Enumerable.Range(start, count).ToArray();
            var target = Enumerable.Range(start, count).ToArray();
            target.BubbleSort();
            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void BubbleSort_3()
        {
            var start = 1;
            var count = 10000;
            var expected = Enumerable.Range(start, count).ToArray();
            var target = Enumerable.Range(start, count).Reverse().ToArray();
            target.BubbleSort();
            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void BubbleSort_4()
        {
            var target = Enumerable.Range(1, 20).Select(i => i * i).ToArray();
            var actual = target.BubbleSort(i => i.ToString());

            foreach (var i in actual)
                Console.WriteLine(i);
        }
    }
}
