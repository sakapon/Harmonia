using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Conversion
{
    public static class Base64Helper
    {
        const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        static readonly Dictionary<char, int> CharIndexMap = Base64Chars.Select((c, i) => new { c, i }).ToDictionary(_ => _.c, _ => _.i);

        public static string ToBase64(this byte[] bytes)
        {
            var q = bytes.Length / 3;
            var m = bytes.Length % 3;

            var resultLength = (m == 0 ? q : (q + 1)) * 4;
            var validLength = q * 4 + (m == 0 ? 0 : (m + 1));

            var ints = new int[resultLength];
            for (var i = 0; i < validLength; i++)
                ints[i] = GetEncodedValue(bytes, i);
            for (var i = validLength; i < resultLength; i++)
                ints[i] = 64;

            return new string(ints.Select(i => Base64Chars[i]).ToArray());
        }

        static int GetEncodedValue(byte[] bytes, int index)
        {
            var i = (index / 4) * 3;
            var type = index % 4;

            switch (type)
            {
                case 0:
                    return bytes[i] >> 2;
                case 1:
                    var r1 = (bytes[i] & 0b00000011) << 4;
                    if (i + 1 < bytes.Length) r1 |= (bytes[i + 1] >> 4);
                    return r1;
                case 2:
                    var r2 = (bytes[i + 1] & 0b00001111) << 2;
                    if (i + 2 < bytes.Length) r2 |= (bytes[i + 2] >> 6);
                    return r2;
                case 3:
                    return bytes[i + 2] & 0b00111111;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static byte[] FromBase64(this string value)
        {
            var ints = value.TrimEnd('=').Select(c => CharIndexMap[c]).ToArray();

            var q = ints.Length / 4;
            var m = ints.Length % 4;

            var resultLength = q * 3 + (m == 0 ? 0 : (m - 1));

            var bytes = new byte[resultLength];
            for (var i = 0; i < resultLength; i++)
                bytes[i] = GetDecodedValue(ints, i);

            return bytes;
        }

        static byte GetDecodedValue(int[] ints, int index)
        {
            var i = (index / 3) * 4;
            var type = index % 3;

            switch (type)
            {
                case 0:
                    var r0 = ints[i] << 2;
                    r0 |= (ints[i + 1] >> 4);
                    return (byte)r0;
                case 1:
                    var r1 = ints[i + 1] << 4;
                    r1 |= (ints[i + 2] >> 2);
                    return (byte)r1;
                case 2:
                    var r2 = ints[i + 2] << 6;
                    r2 |= (ints[i + 3]);
                    return (byte)r2;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
