using System;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
    [TestClass]
    public class NumbersTest
    {
        [TestMethod]
        public void Gcd()
        {
            Assert.AreEqual(1, Numbers.Gcd(1, 1));
            Assert.AreEqual(2, Numbers.Gcd(2, 2));
            Assert.AreEqual(6, Numbers.Gcd(6, 6));
            Assert.AreEqual(1, Numbers.Gcd(2, 3));
            Assert.AreEqual(2, Numbers.Gcd(2, 4));
            Assert.AreEqual(2, Numbers.Gcd(4, 6));
            Assert.AreEqual(2, Numbers.Gcd(8, 10));
            Assert.AreEqual(3, Numbers.Gcd(15, 21));
        }

        [TestMethod]
        public void Lcm()
        {
            Assert.AreEqual(1, Numbers.Lcm(1, 1));
            Assert.AreEqual(2, Numbers.Lcm(2, 2));
            Assert.AreEqual(6, Numbers.Lcm(6, 6));
            Assert.AreEqual(6, Numbers.Lcm(2, 3));
            Assert.AreEqual(4, Numbers.Lcm(2, 4));
            Assert.AreEqual(12, Numbers.Lcm(4, 6));
            Assert.AreEqual(40, Numbers.Lcm(8, 10));
            Assert.AreEqual(105, Numbers.Lcm(15, 21));
        }

        [TestMethod]
        public void IsSquareNumber()
        {
            Assert.AreEqual(true, Numbers.IsSquareNumber(1));
            Assert.AreEqual(false, Numbers.IsSquareNumber(2));
            Assert.AreEqual(false, Numbers.IsSquareNumber(3));
            Assert.AreEqual(true, Numbers.IsSquareNumber(4));
            Assert.AreEqual(false, Numbers.IsSquareNumber(5));
        }

        [TestMethod]
        public void Pow_Long()
        {
            Assert.AreEqual(1L << 62, Numbers.Pow(2, 62));
            Assert.AreEqual((long)Math.Pow(3, 31), Numbers.Pow(3, 31));
        }

        [TestMethod]
        public void Pow_Double()
        {
            Assert.AreEqual(Math.Pow(1.1, 7), Numbers.Pow(1.1, 7));
            Assert2.AreNearlyEqual(Math.Pow(1.08, 20), Numbers.Pow(1.08, 20));
            // e
            Assert2.AreNearlyEqual(Math.Pow(1.000001, 1000000), Numbers.Pow(1.000001, 1000000), -10);
        }

        [TestMethod]
        public void Pow_Decimal()
        {
            Assert.AreEqual(Math.Pow(1.2, 4), (double)Numbers.Pow(1.2m, 4));
            Assert2.AreNearlyEqual(Math.Pow(1.1, 7), (double)Numbers.Pow(1.1m, 7));
            Assert2.AreNearlyEqual(Math.Pow(1.08, 20), (double)Numbers.Pow(1.08m, 20));
            // e
            Assert2.AreNearlyEqual(Math.Pow(1.000001, 1000000), (double)Numbers.Pow(1.000001m, 1000000), -9);
        }
    }
}
