using System;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
	[TestClass]
	public class ArithmeticTest
	{
		static int NextInt32() => RandomHelper.Random.Next(int.MinValue, int.MaxValue);

		[TestMethod]
		public void Add()
		{
			void Test(int x, int y) => Assert.AreEqual(x + y, Arithmetic.Add(x, y));

			Test(0, 123);
			Test(123, 0);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Subtract()
		{
			void Test(int x, int y) => Assert.AreEqual(x - y, Arithmetic.Subtract(x, y));

			Test(0, 123);
			Test(123, 0);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Multiply_Byte()
		{
			void Test(byte x, byte y) => Assert.AreEqual((byte)(x * y), Arithmetic.Multiply(x, y));

			Test(0, 123);
			Test(1, 123);
			Test(123, 0);
			Test(123, 1);

			for (int i = 0; i < 1000; i++)
				Test((byte)NextInt32(), (byte)NextInt32());
		}

		[TestMethod]
		public void Multiply()
		{
			void Test(int x, int y) => Assert.AreEqual(x * y, Arithmetic.Multiply(x, y));

			Test(0, 123);
			Test(1, 123);
			Test(123, 0);
			Test(123, 1);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Divide()
		{
			void Test(int x, int y)
			{
				var (q, r) = Arithmetic.Divide(x, y);
				Assert.AreEqual(x / y, q);
				Assert.AreEqual(x % y, r);
			}

			Assert.ThrowsException<DivideByZeroException>(() => Arithmetic.Divide(123, 0));

			for (int i = -100; i <= 100; i++)
			{
				Test(i, 30);
				Test(i, 31);
				Test(i, -30);
				Test(i, -31);

				if (i != 0)
				{
					Test(30, i);
					Test(31, i);
					Test(-30, i);
					Test(-31, i);
				}
			}

			for (int i = 0; i < 1000; i++)
			{
				var (x, y) = (NextInt32(), NextInt32());
				if (y != 0) Test(x, y);
			}
		}
	}
}
