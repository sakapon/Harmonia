using System;
using Harmonia.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
    [TestClass]
    public class ElementaryFunctionsTest
    {
        static void AssertNearlyEqual(double expected, double actual) =>
            Assert.AreEqual(0.0, Math.Round(expected - actual, 12));

        [TestMethod]
        public void GetPi() => AssertNearlyEqual(Math.PI, ElementaryFunctions.GetPi());

        [TestMethod]
        public void GetE() => AssertNearlyEqual(Math.E, ElementaryFunctions.GetE());
    }
}
