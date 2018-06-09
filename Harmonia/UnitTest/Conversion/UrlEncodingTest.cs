using System;
using Harmonia.Conversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Harmonia.Conversion.UrlEncoding;

namespace UnitTest.Conversion
{
    [TestClass]
    public class UrlEncodingTest
    {
        [TestMethod]
        public void PercentEncode()
        {
            var original = " !\"-0Aaあ";
            var encoded = "%20%21%22%2D%30%41%61%E3%81%82";

            Assert.AreEqual(encoded, original.PercentEncode());
            Assert.AreEqual(original, encoded.PercentDecode());
        }

        [TestMethod]
        public void UrlEncode()
        {
            Assert.AreEqual(Alphanumerics, Alphanumerics.UrlEncode());
            Assert.AreEqual(Rfc3986_UnreservedChars, Rfc3986_UnreservedChars.UrlEncode());
            Assert.AreEqual(Rfc3986_ReservedChars.PercentEncode(), Rfc3986_ReservedChars.UrlEncode());
            Assert.AreEqual(Rfc3986_OtherChars.PercentEncode(), Rfc3986_OtherChars.UrlEncode());
            Assert.AreEqual("%20%21%22-0Aa%E3%81%82", " !\"-0Aaあ".UrlEncode());
        }

        [TestMethod]
        public void UrlEncodeForUrl()
        {
            Assert.AreEqual(Alphanumerics, Alphanumerics.UrlEncodeForUrl());
            Assert.AreEqual(Rfc3986_UnreservedChars, Rfc3986_UnreservedChars.UrlEncodeForUrl());
            Assert.AreEqual(Rfc3986_ReservedChars, Rfc3986_ReservedChars.UrlEncodeForUrl());
            Assert.AreEqual(Rfc3986_OtherChars.PercentEncode(), Rfc3986_OtherChars.UrlEncodeForUrl());
            Assert.AreEqual("https://abc.xyz/%20!%22-0Aa%E3%81%82%2520", "https://abc.xyz/ !\"-0Aaあ%20".UrlEncodeForUrl());
        }

        [TestMethod]
        public void UrlDecode()
        {
            Assert.AreEqual(Alphanumerics, Alphanumerics.UrlDecode());
            Assert.AreEqual(Rfc3986_UnreservedChars, Rfc3986_UnreservedChars.UrlDecode());
            Assert.AreEqual(Rfc3986_ReservedChars, Rfc3986_ReservedChars.UrlEncode().UrlDecode());
            Assert.AreEqual(Rfc3986_OtherChars, Rfc3986_OtherChars.UrlEncode().UrlDecode());
            Assert.AreEqual("https://abc.xyz/ !\"-0Aaあ%20", "https://abc.xyz/%20!%22-0Aa%E3%81%82%2520".UrlDecode());
        }
    }
}
