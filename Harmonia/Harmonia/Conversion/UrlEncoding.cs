using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Harmonia.Conversion
{
    public static class UrlEncoding
    {
        internal const string Alphanumerics = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        internal const string Rfc3986_UnreservedChars = "-._~"; // 4 symbols
        internal const string Rfc3986_ReservedChars = "!#$&'()*+,/:;=?@[]"; // 18 symbols
        internal const string Rfc3986_OtherChars = " \"%<>\\^`{|}"; // 11 symbols

        public static string PercentEncode(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return string.Concat(Encoding.UTF8.GetBytes(value).Select(b => "%" + b.ToString("X2")));
        }

        internal static string PercentDecode(this string value)
        {
            // Suppose the value is well-formed.
            var bytes = Enumerable.Range(0, value.Length / 3)
                .Select(i => value.Substring(3 * i + 1, 2))
                .Select(s => byte.Parse(s, NumberStyles.HexNumber))
                .ToArray();
            return Encoding.UTF8.GetString(bytes);
        }

        public static string UrlEncode(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return Regex.Replace(value, "[^-._~0-9A-Za-z]+", m => m.Value.PercentEncode());
        }

        public static string UrlEncodeForUrl(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return Regex.Replace(value, @"[^-._~!#$&'()*+,/:;=?@[\]0-9A-Za-z]+", m => m.Value.PercentEncode());
        }

        public static string UrlDecode(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return Regex.Replace(value, "(%[0-9A-Fa-f]{2})+", m => m.Value.PercentDecode());
        }

        public static string UrlEncodeForForm(this string value) =>
             value.UrlEncode().Replace("%20", "+");

        public static string UrlDecodeForForm(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return value.Replace("+", "%20").UrlDecode();
        }
    }
}
