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

        [TestMethod]
        public void Sin()
        {
            void Test(double expected, double x) => AssertNearlyEqual(expected, ElementaryFunctions.Sin(x));

            Test(1.0, Math.PI / 2);
            Test(Math.Sqrt(3) / 2, Math.PI / 3);
            Test(Math.Sqrt(2) / 2, Math.PI / 4);
            Test(0.5, Math.PI / 6);
            Test(0.0, 0);
            Test(-0.5, -Math.PI / 6);
            Test(-Math.Sqrt(2) / 2, -Math.PI / 4);
            Test(-Math.Sqrt(3) / 2, -Math.PI / 3);
            Test(-1.0, -Math.PI / 2);

            Test((Math.Sqrt(6) - Math.Sqrt(2)) / 4, Math.PI / 12);
        }

        [TestMethod]
        public void Cos()
        {
            void Test(double expected, double x) => AssertNearlyEqual(expected, ElementaryFunctions.Cos(x));

            Test(1.0, 0);
            Test(Math.Sqrt(3) / 2, Math.PI / 6);
            Test(Math.Sqrt(2) / 2, Math.PI / 4);
            Test(0.5, Math.PI / 3);
            Test(0.0, Math.PI / 2);
            Test(-0.5, Math.PI * 2 / 3);
            Test(-Math.Sqrt(2) / 2, Math.PI * 3 / 4);
            Test(-Math.Sqrt(3) / 2, Math.PI * 5 / 6);
            Test(-1.0, Math.PI);

            Test((Math.Sqrt(6) + Math.Sqrt(2)) / 4, Math.PI / 12);
        }

        [TestMethod]
        public void Exp()
        {
            void Test(double x) => AssertNearlyEqual(Math.Exp(x), ElementaryFunctions.Exp(x));

            Test(1.0);
            Test(-1.0);
            Test(0.5);
            Test(2.0);
            Test(Math.PI);
        }
    }
}
