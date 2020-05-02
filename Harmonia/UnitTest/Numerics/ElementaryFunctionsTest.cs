using System;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
    [TestClass]
    public class ElementaryFunctionsTest
    {
        [TestMethod]
        public void GetPi() => Assert2.AreNearlyEqual(Math.PI, ElementaryFunctions.GetPi());

        [TestMethod]
        public void GetE() => Assert2.AreNearlyEqual(Math.E, ElementaryFunctions.GetE());

        [TestMethod]
        public void Sin()
        {
            void Test(double expected, double x) => Assert2.AreNearlyEqual(expected, ElementaryFunctions.Sin(x));

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
            void Test(double expected, double x) => Assert2.AreNearlyEqual(expected, ElementaryFunctions.Cos(x));

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
        public void Tan()
        {
            void Test(double expected, double x) => Assert2.AreNearlyEqual(expected, ElementaryFunctions.Tan(x));

            Test(Math.Sqrt(3), Math.PI / 3);
            Test(1.0, Math.PI / 4);
            Test(1 / Math.Sqrt(3), Math.PI / 6);
            Test(0.0, 0);
            Test(-1 / Math.Sqrt(3), -Math.PI / 6);
            Test(-1.0, -Math.PI / 4);
            Test(-Math.Sqrt(3), -Math.PI / 3);

            Test(2 - Math.Sqrt(3), Math.PI / 12);
        }

        [TestMethod]
        public void Exp()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Exp(x), ElementaryFunctions.Exp(x));

            Test(1.0);
            Test(-1.0);
            Test(0.5);
            Test(2.0);
            Test(Math.PI);
        }

        [TestMethod]
        public void Log()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Log(x), ElementaryFunctions.Log(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(0.5);
            Test(Math.E);
        }

        [TestMethod]
        public void Log_b()
        {
            void Test(double x, double b) => Assert2.AreNearlyEqual(Math.Log(x, b), ElementaryFunctions.Log(x, b), -9);

            Test(1.0, 2);
            Test(2.0, 2);
            Test(0.5, 2);
            Test(1.0, 10);
            Test(2.0, 10);
            Test(0.5, 10);
            Test(Math.E, Math.E);
        }

        [TestMethod]
        public void Pow()
        {
            void Test(double x, double p) => Assert2.AreNearlyEqual(Math.Pow(x, p), ElementaryFunctions.Pow(x, p));

            Test(2.0, 3.0);
            Test(2.0, 0.5);
            Test(Math.PI, Math.E);
        }

        [TestMethod]
        public void Sqrt()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Sqrt(x), ElementaryFunctions.Sqrt(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(127.0);
        }

        [TestMethod]
        public void Cbrt()
        {
            void Test(double x) => Assert2.AreNearlyEqual(Math.Pow(x, 1.0 / 3), ElementaryFunctions.Cbrt(x));

            Test(1.0);
            Test(2.0);
            Test(3.0);
            Test(127.0);
        }

        [TestMethod]
        public void Inverse()
        {
            void Test(double x) => Assert2.AreNearlyEqual(1 / x, ElementaryFunctions.Inverse(x));

            Test(1.0);
            Test(0.001);
            Test(0.15);
            Test(0.2);
            Test(3.0);
            Test(7.0);
            Test(256.0);
            Test(12345);
        }
    }
}
