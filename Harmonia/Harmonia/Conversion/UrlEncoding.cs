using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Harmonia.Conversion
{
    public static class UrlEncoding
    {
        const string Rfc3986_UnreservedChars = "-._~"; // 4 symbols
        const string Rfc3986_ReservedChars = "!#$&'()*+,/:;=?@[]"; // 18 symbols
        const string Rfc3986_OtherChars = " \"%<>\\^`{|}"; // 11 symbols

        public static string PercentEncode(this string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return string.Concat(Encoding.UTF8.GetBytes(value).Select(b => "%" + b.ToString("X2")));
        }

        static string PercentDecode(this string value)
        {
            // Suppose the value is well-formed.
            var bytes = Enumerable.Range(0, value.Length / 3)
                .Select(i => value.Substring(3 * i + 1, 2))
                .Select(s => byte.Parse(s, NumberStyles.HexNumber))
                .ToArray();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
