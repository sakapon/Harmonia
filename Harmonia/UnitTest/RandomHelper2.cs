using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace UnitTest
{
    public static class RandomHelper2
    {
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
