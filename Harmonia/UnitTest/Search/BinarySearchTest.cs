﻿using System;
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
            var count = 10000;
            var array = Enumerable.Range(0, count)
                .Select(i => 2 * i + 3)
                .ToArray();

            Assert.AreEqual(-1, BinarySearch.GetIndex(array, 2));
            Assert.AreEqual(-1, BinarySearch.GetIndex(array, 2 * count + 3));

            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, BinarySearch.GetIndex(array, array[i]));
                Assert.AreEqual(-1, BinarySearch.GetIndex(array, array[i] + 1));
            }
        }

        [TestMethod]
        public void GetIndexByRange_Int32()
        {
            var count = 10000;
            var array = Enumerable.Range(0, count)
                .Select(i => 2 * i + 3)
                .ToArray();

            Assert.AreEqual(-1, BinarySearch.GetIndexByRange(array, 2));
            Assert.AreEqual(count - 1, BinarySearch.GetIndexByRange(array, 2 * count + 3));

            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, BinarySearch.GetIndexByRange(array, array[i]));
                Assert.AreEqual(i, BinarySearch.GetIndexByRange(array, array[i] + 1));
            }
        }

        [TestMethod]
        public void GetIndex_Double()
        {
            var count = 10000;
            var array = Enumerable.Range(0, count)
                .Select(i => (double)2 * i + 3)
                .ToArray();

            Assert.AreEqual(-1, BinarySearch.GetIndex(array, 2));
            Assert.AreEqual(-1, BinarySearch.GetIndex(array, 2 * count + 3));

            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, BinarySearch.GetIndex(array, array[i]));
                Assert.AreEqual(-1, BinarySearch.GetIndex(array, array[i] + 1.5));
            }
        }

        [TestMethod]
        public void GetIndexByRange_Double()
        {
            var count = 10000;
            var array = Enumerable.Range(0, count)
                .Select(i => (double)2 * i + 3)
                .ToArray();

            Assert.AreEqual(-1, BinarySearch.GetIndexByRange(array, 2));
            Assert.AreEqual(count - 1, BinarySearch.GetIndexByRange(array, 2 * count + 3));

            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, BinarySearch.GetIndexByRange(array, array[i]));
                Assert.AreEqual(i, BinarySearch.GetIndexByRange(array, array[i] + 1.5));
            }
        }
    }
}
