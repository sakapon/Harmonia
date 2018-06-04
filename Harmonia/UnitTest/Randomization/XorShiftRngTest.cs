using System;
using Harmonia.Randomization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Randomization
{
    [TestClass]
    public class XorShiftRngTest
    {
        [TestMethod]
        public void GenerateInt32()
        {
            var rng = new XorShiftRng();

            for (var i = 0; i < 100; i++)
                Console.WriteLine(rng.GenerateInt32());
        }

        [TestMethod]
        public void GenerateInt32_Seed()
        {
            var rng = new XorShiftRng(1);

            for (var i = 0; i < 100; i++)
                Console.WriteLine(rng.GenerateInt32());
        }

        [TestMethod]
        public void GenerateInt64()
        {
            var rng = new XorShiftRng();

            for (var i = 0; i < 100; i++)
                Console.WriteLine(rng.GenerateInt64());
        }

        [TestMethod]
        public void GenerateInt64_Seed()
        {
            var rng = new XorShiftRng(1);

            for (var i = 0; i < 100; i++)
                Console.WriteLine(rng.GenerateInt64());
        }

        [TestMethod]
        public void GenerateDouble()
        {
            var rng = new XorShiftRng();

            for (var i = 0; i < 100; i++)
            {
                var x = rng.GenerateDouble();
                Assert.IsTrue(0 <= x && x < 1);
                Console.WriteLine(x);
            }
        }
    }
}
