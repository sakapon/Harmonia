using System;
using Harmonia.Numerics;
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
        public void Pow_Double()
        {
            Assert.AreEqual(Math.Pow(1.1, 7), Numbers.Pow(1.1, 7));
            TestHelper.AssertNearlyEqual(Math.Pow(1.08, 20), Numbers.Pow(1.08, 20));
        }
    }
}
