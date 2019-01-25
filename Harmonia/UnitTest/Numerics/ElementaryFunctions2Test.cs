using System;
using Harmonia.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
    [TestClass]
    public class ElementaryFunctions2Test
    {
        static void AssertNearlyEqual(double expected, double actual) =>
            Assert.AreEqual(0.0, Math.Round(expected - actual, 12));

        [TestMethod]
        public void Exp()
        {
            void Test(double x) => AssertNearlyEqual(Math.Exp(x), ElementaryFunctions2.Exp(x));

            Test(1.0);
            Test(-1.0);
            Test(0.5);
            Test(2.0);
            Test(Math.PI);
        }

        [TestMethod]
        public void Log()
        {
            void Test(double x) => AssertNearlyEqual(Math.Log(x), ElementaryFunctions2.Log(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(0.5);
            Test(Math.E);
        }
    }
}
