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
        [TestMethod]
        public void GetIndex_Int32()
        {
            var array = Enumerable.Range(0, 1000)
                .Select(i => 2 * i + 3)
                .ToArray();

            Assert.AreEqual(-1, BinarySearch.GetIndex(array, 2));
            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, BinarySearch.GetIndex(array, array[i]));
                Assert.AreEqual(-1, BinarySearch.GetIndex(array, array[i] + 1));
            }
        }
    }
}
