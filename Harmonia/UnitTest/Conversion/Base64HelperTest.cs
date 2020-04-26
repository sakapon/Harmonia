using System;
using Harmonia.Conversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Conversion
{
    [TestClass]
    public class Base64HelperTest
    {
        [TestMethod]
        public void ToBase64()
        {
            void Test(string text, byte[] bytes)
            {
                Assert.AreEqual(text, Convert.ToBase64String(bytes));
                Assert.AreEqual(text, bytes.ToBase64());
                CollectionAssert.AreEqual(bytes, Convert.FromBase64String(text));
                CollectionAssert.AreEqual(bytes, text.FromBase64());
            }

            Test("", new byte[0]);
            Test("AA==", new byte[1]);
            Test("AAA=", new byte[2]);
            Test("AAAA", new byte[3]);
            Test("AAAAAA==", new byte[4]);
            Test("AAAAAAA=", new byte[5]);
            Test("AAAAAAAA", new byte[6]);
            Test("AAAAAAAAAA==", new byte[7]);
            Test("QQ==", new byte[] { 65 });
            Test("QUI=", new byte[] { 65, 66 });
            Test("QUJD", new byte[] { 65, 66, 67 });
            Test("QUJDRA==", new byte[] { 65, 66, 67, 68 });
            Test("QUJDREU=", new byte[] { 65, 66, 67, 68, 69 });
            Test("QUJDREVG", new byte[] { 65, 66, 67, 68, 69, 70 });
            Test("QUJDREVGRw==", new byte[] { 65, 66, 67, 68, 69, 70, 71 });
        }

        [TestMethod]
        public void ToBase64_Random()
        {
            void Test(int bytesLength)
            {
                var bytes = RandomHelper2.GenerateBytes(bytesLength);
                var text = Convert.ToBase64String(bytes);
                Console.WriteLine(text);

                Assert.AreEqual(text, bytes.ToBase64());
                CollectionAssert.AreEqual(bytes, text.FromBase64());
            }

            for (var i = 1; i <= 64; i++)
                Test(i);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromBase64_Format_Length() => "===".FromBase64();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromBase64_Format_Chars() => "===-".FromBase64();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromBase64_Format_Padding() => "A===".FromBase64();
    }
}
