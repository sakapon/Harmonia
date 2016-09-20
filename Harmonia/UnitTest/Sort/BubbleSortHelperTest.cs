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
            var expectedComparisons = count * (count - 1) / 2;
            var expected = Enumerable.Range(start, count).ToArray();

            for (var i = 0; i < 10; i++)
            {
                var comparisons = 0;
                var target = RandomHelper.ShuffleRange(start, count).ToArray();
                target.BubbleSort((x1, x2) =>
                {
                    comparisons++;
                    return x1.CompareTo(x2);
                });

                Assert.AreEqual(expectedComparisons, comparisons);
                CollectionAssert.AreEqual(expected, target);
            }
        }

        [TestMethod]
        public void BubbleSort_2()
        {
            var start = 1;
            var count = 10000;
            var expectedComparisons = count * (count - 1) / 2;
            var expected = Enumerable.Range(start, count).ToArray();

            var comparisons = 0;
            var target = Enumerable.Range(start, count).ToArray();
            target.BubbleSort((x1, x2) =>
            {
                comparisons++;
                return x1.CompareTo(x2);
            });

            Assert.AreEqual(expectedComparisons, comparisons);
            CollectionAssert.AreEqual(expected, target);
        }

        [TestMethod]
        public void BubbleSort_3()
        {
            var start = 1;
            var count = 10000;
            var expectedComparisons = count * (count - 1) / 2;
            var expected = Enumerable.Range(start, count).ToArray();

            var comparisons = 0;
            var target = Enumerable.Range(start, count).Reverse().ToArray();
            target.BubbleSort((x1, x2) =>
            {
                comparisons++;
                return x1.CompareTo(x2);
            });

            Assert.AreEqual(expectedComparisons, comparisons);
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
