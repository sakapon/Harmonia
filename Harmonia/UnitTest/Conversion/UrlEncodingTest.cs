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
            var original = " !\"-0Aaあ";
            var encoded = "%20%21%22%2D%30%41%61%E3%81%82";

            Assert.AreEqual(encoded, UrlEncoding.PercentEncode(original));
            Assert.AreEqual(original, UrlEncoding.PercentDecode(encoded));
        }

        [TestMethod]
        public void UrlEncode()
        {
            Assert.AreEqual(UrlEncoding.Alphanumerics, UrlEncoding.UrlEncode(UrlEncoding.Alphanumerics));
            Assert.AreEqual(UrlEncoding.Rfc3986_UnreservedChars, UrlEncoding.UrlEncode(UrlEncoding.Rfc3986_UnreservedChars));
            Assert.AreEqual(UrlEncoding.PercentEncode(UrlEncoding.Rfc3986_ReservedChars), UrlEncoding.UrlEncode(UrlEncoding.Rfc3986_ReservedChars));
            Assert.AreEqual(UrlEncoding.PercentEncode(UrlEncoding.Rfc3986_OtherChars), UrlEncoding.UrlEncode(UrlEncoding.Rfc3986_OtherChars));
            Assert.AreEqual("%20%21%22-0Aa%E3%81%82", UrlEncoding.UrlEncode(" !\"-0Aaあ"));
        }

        [TestMethod]
        public void UrlEncodeForUrl()
        {
            Assert.AreEqual(UrlEncoding.Alphanumerics, UrlEncoding.UrlEncodeForUrl(UrlEncoding.Alphanumerics));
            Assert.AreEqual(UrlEncoding.Rfc3986_UnreservedChars, UrlEncoding.UrlEncodeForUrl(UrlEncoding.Rfc3986_UnreservedChars));
            Assert.AreEqual(UrlEncoding.Rfc3986_ReservedChars, UrlEncoding.UrlEncodeForUrl(UrlEncoding.Rfc3986_ReservedChars));
            Assert.AreEqual(UrlEncoding.PercentEncode(UrlEncoding.Rfc3986_OtherChars), UrlEncoding.UrlEncodeForUrl(UrlEncoding.Rfc3986_OtherChars));
            Assert.AreEqual("https://abc.xyz/%20!%22-0Aa%E3%81%82%2520", UrlEncoding.UrlEncodeForUrl("https://abc.xyz/ !\"-0Aaあ%20"));
        }

        [TestMethod]
        public void UrlDecode()
        {
            Assert.AreEqual(UrlEncoding.Alphanumerics, UrlEncoding.UrlDecode(UrlEncoding.Alphanumerics));
            Assert.AreEqual(UrlEncoding.Rfc3986_UnreservedChars, UrlEncoding.UrlDecode(UrlEncoding.Rfc3986_UnreservedChars));
            Assert.AreEqual(UrlEncoding.Rfc3986_ReservedChars, UrlEncoding.UrlDecode(UrlEncoding.UrlEncode(UrlEncoding.Rfc3986_ReservedChars)));
            Assert.AreEqual(UrlEncoding.Rfc3986_OtherChars, UrlEncoding.UrlDecode(UrlEncoding.UrlEncode(UrlEncoding.Rfc3986_OtherChars)));
            Assert.AreEqual("https://abc.xyz/ !\"-0Aaあ%20", UrlEncoding.UrlDecode("https://abc.xyz/%20!%22-0Aa%E3%81%82%2520"));
        }
    }
}
