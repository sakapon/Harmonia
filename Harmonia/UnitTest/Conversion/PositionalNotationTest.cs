using System;
using Harmonia.Conversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Conversion
{
    [TestClass]
    public class PositionalNotationTest
    {
        [TestMethod]
        public void ToStringInBase()
        {
            void Test(int @base, int n, string s)
            {
                Assert.AreEqual(s, n.ToStringInBase(@base));
                Assert.AreEqual(n, s.FromStringInBase(@base));
            }

            Test(2, 0, "0");
            Test(16, -15, "-F");
            Test(10, 123, "123");

            Test(2, 23, "10111");
            Test(3, 729, "1000000");
            Test(8, 123, "173");
            Test(8, 83, "123");
            Test(12, 123, "A3");
            Test(12, 171, "123");
            Test(16, 65535, "FFFF");
            Test(20, 99, "4J");
        }
    }
}
