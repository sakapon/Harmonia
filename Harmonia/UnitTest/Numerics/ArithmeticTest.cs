using System;
using System.Collections.Generic;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
	[TestClass]
	public class ArithmeticTest
	{
		[TestMethod]
		public void Add_Int32()
		{
			void Test(int x, int y) => Assert.AreEqual(x + y, Arithmetic.Add(x, y));

			Test(6, 9);
			Test(15, 17);
			Test(-3, 5);
			Test(3, -5);
			Test(-3, -5);
			Test(0xFFFF, 1);
			Test(8, int.MaxValue);
		}

		[TestMethod]
		public void Subtract_Int32()
		{
			void Test(int x, int y) => Assert.AreEqual(x - y, Arithmetic.Subtract(x, y));

			Test(6, 9);
			Test(5, 3);
			Test(-3, 5);
			Test(3, -5);
			Test(-3, -5);
			Test(0xFFFF, -1);
			Test(8, int.MaxValue);
		}

		[TestMethod]
		public void Multiply_Byte()
		{
			void Test(byte x, byte y) => Assert.AreEqual((byte)(x * y), Arithmetic.Multiply(x, y));

			Test(6, 5);
			Test(15, 17);
			Test(8, 32);
			Test(51, 53);
		}

		[TestMethod]
		public void Multiply_Int32()
		{
			void Test(int x, int y) => Assert.AreEqual(x * y, Arithmetic.Multiply(x, y));

			Test(6, 5);
			Test(15, 17);
			Test(-3, 5);
			Test(3, -5);
			Test(-3, -5);
			Test(8, int.MaxValue);
			Test(0x10000000, -4);
		}

		[TestMethod]
		public void Quotient()
		{
			void Test(int x, int y) => Assert.AreEqual(x / y, Arithmetic.Quotient(x, y));

			Assert.ThrowsException<DivideByZeroException>(() => Arithmetic.Quotient(123, 0));
			Test(0, 123);

			var xs = RandomHelper.CreateData(1000, -1000, 1000);
			var ys = RandomHelper.CreateData(1000, -1000, 1000);
			for (int i = 0; i < xs.Length; i++)
				if (ys[i] != 0) Test(xs[i], ys[i]);

			xs = RandomHelper.CreateData(1000, int.MinValue, int.MaxValue);
			ys = RandomHelper.CreateData(1000, int.MinValue, int.MaxValue);
			for (int i = 0; i < xs.Length; i++)
				if (ys[i] != 0) Test(xs[i], ys[i]);
		}

		[TestMethod]
		public void Remainder()
		{
			void Test(int x, int y) => Assert.AreEqual(x % y, Arithmetic.Remainder(x, y));

			Assert.ThrowsException<DivideByZeroException>(() => Arithmetic.Remainder(123, 0));
			Test(0, 123);

			var xs = RandomHelper.CreateData(1000, -1000, 1000);
			var ys = RandomHelper.CreateData(1000, -1000, 1000);
			for (int i = 0; i < xs.Length; i++)
				if (ys[i] != 0) Test(xs[i], ys[i]);

			xs = RandomHelper.CreateData(1000, int.MinValue, int.MaxValue);
			ys = RandomHelper.CreateData(1000, int.MinValue, int.MaxValue);
			for (int i = 0; i < xs.Length; i++)
				if (ys[i] != 0) Test(xs[i], ys[i]);
		}
	}
}
