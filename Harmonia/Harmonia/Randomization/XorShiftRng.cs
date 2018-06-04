using System;

namespace Harmonia.Randomization
{
    public class XorShiftRng
    {
        int i;
        long j;

        public XorShiftRng()
        {
            InitializeSeeds();
        }

        public void InitializeSeeds()
        {
            InitializeSeeds(DateTime.Now.Ticks);
        }

        public void InitializeSeeds(long seed)
        {
            i = (int)seed;
            j = seed;
        }

        public int GenerateInt32()
        {
            i = i ^ (i << 13);
            i = i ^ (i >> 17);
            i = i ^ (i << 15);
            return i;
        }

        public long GenerateInt64()
        {
            j = j ^ (j << 13);
            j = j ^ (j >> 7);
            j = j ^ (j << 17);
            return j;
        }

        // 0 <= x < 1
        public double GenerateDouble() => Normalize(GenerateInt32());
        // 0 < x < 1
        public double GenerateDoubleExceptZero() => NormalizeExceptZero(GenerateInt32());

        static readonly double Power_2_32 = Math.Pow(2, 32);
        static double Normalize(int x) => x / Power_2_32 + 0.5;
        static double NormalizeExceptZero(int x) => (x + 0.5) / (Power_2_32 + 1.0) + 0.5;
    }
}
