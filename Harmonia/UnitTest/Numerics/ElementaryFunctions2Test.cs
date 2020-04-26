using System;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
    [TestClass]
    public class ElementaryFunctions2Test
    {
        [TestMethod]
        public void Exp()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Exp(x), ElementaryFunctions2.Exp(x));

            Test(1.0);
            Test(-1.0);
            Test(0.5);
            Test(2.0);
            Test(Math.PI);
        }

        [TestMethod]
        public void Log()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Log(x), ElementaryFunctions2.Log(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(0.5);
            Test(Math.E);
        }

        [TestMethod]
        public void Sqrt()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Sqrt(x), ElementaryFunctions2.Sqrt(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(127.0);
        }

        [TestMethod]
        public void Cbrt()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Pow(x, 1.0 / 3), ElementaryFunctions2.Cbrt(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(127.0);
        }
    }
}
