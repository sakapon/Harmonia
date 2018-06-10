using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace UnitTest
{
    public static class RandomHelper
    {
        static readonly Random Random = new Random();

        public static IEnumerable<int> ShuffleRange(int start, int count)
        {
            var l = Enumerable.Range(start, count).ToList();

            while (l.Count > 0)
            {
                var index = Random.Next(l.Count);
                yield return l[index];
                l.RemoveAt(index);
            }
        }

        public static byte[] GenerateBytes(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size), size, "The value must be non-negative.");

            var data = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }
            return data;
        }
    }
}
