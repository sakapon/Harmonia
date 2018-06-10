using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Harmonia.Conversion
{
    public static class PositionalNotation
    {
        const string NumberChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static readonly Dictionary<char, int> CharIndexMap = NumberChars.Select((c, i) => new { c, i }).ToDictionary(_ => _.c, _ => _.i);

        public static string ToStringInBase(this int value, int toBase)
        {
            if (toBase < 2 || NumberChars.Length < toBase) throw new ArgumentOutOfRangeException(nameof(toBase), toBase, $"The value must be x that satisfies 2 <= x <= {NumberChars.Length}.");

            if (value == 0) return "0";
            if (value < 0) return "-" + ToStringInBase(-value, toBase);

            var result = "";
            var current = value;
            while (current > 0)
            {
                result = NumberChars[current % toBase].ToString() + result;
                current /= toBase;
            }
            return result;
        }

        public static int FromStringInBase(this string value, int fromBase)
        {
            if (fromBase < 2 || NumberChars.Length < fromBase) throw new ArgumentOutOfRangeException(nameof(fromBase), fromBase, $"The value must be x that satisfies 2 <= x <= {NumberChars.Length}.");

            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.StartsWith("-")) return -FromStringInBase(value.Substring(1), fromBase);
            if (!Regex.IsMatch(value, $"^[{NumberChars.Substring(0, fromBase)}]+$")) throw new FormatException();

            var result = 0;
            for (var i = 0; i < value.Length; i++)
            {
                result *= fromBase;
                result += CharIndexMap[value[i]];
            }
            return result;
        }
    }
}
