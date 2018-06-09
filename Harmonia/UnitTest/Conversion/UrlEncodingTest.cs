using System;
using Harmonia.Conversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Conversion
{
    [TestClass]
    public class UrlEncodingTest
    {
        [TestMethod]
        public void PercentEncode()
        {
            var original = " !\"-あ";
            var encoded = "%20%21%22%2D%E3%81%82";

            Assert.AreEqual(encoded, UrlEncoding.PercentEncode(original));
            Assert.AreEqual(original, UrlEncoding.PercentDecode(encoded));
        }
    }
}
