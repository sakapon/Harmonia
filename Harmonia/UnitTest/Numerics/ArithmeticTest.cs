using System;
using System.Linq;
using Harmonia.Numerics;
using KLibrary.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Numerics
{
	[TestClass]
	public class ArithmeticTest
	{
		// Excepts int.MinValue.
		static readonly int[] ExtremeValues = Enumerable.Range(-50, 101)
			.Concat(Enumerable.Range(int.MaxValue - 9, 10))
			.Concat(Enumerable.Range(int.MinValue + 1, 10))
			.ToArray();

		static int NextInt32() => RandomHelper.Random.Next(int.MinValue, int.MaxValue);

		[TestMethod]
		public void LessThan()
		{
			void Test(int x, int y) => Assert.AreEqual(x < y, Arithmetic.LessThan(x, y));

			foreach (var i in ExtremeValues)
				foreach (var j in ExtremeValues)
					Test(i, j);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Add()
		{
			void Test(int x, int y) => Assert.AreEqual(x + y, Arithmetic.Add(x, y));

			foreach (var i in ExtremeValues)
				foreach (var j in ExtremeValues)
					Test(i, j);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Subtract()
		{
			void Test(int x, int y) => Assert.AreEqual(x - y, Arithmetic.Subtract(x, y));

			foreach (var i in ExtremeValues)
				foreach (var j in ExtremeValues)
					Test(i, j);

			for (int i = 0; i < 1000; i++)
				Test(NextInt32(), NextInt32());
		}

		[TestMethod]
		public void Multiply()
		{
			void Test(int x, int y) => Assert.AreEqual(x * y, Arithmetic.Multiply(x, y));

			foreach (var i in ExtremeValues)
				foreach (var j in ExtremeValues)
					Test(i, j);

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

			foreach (var i in ExtremeValues)
				foreach (var j in ExtremeValues)
					if (j != 0) Test(i, j);

			for (int i = 0; i < 1000; i++)
			{
				var (x, y) = (NextInt32(), NextInt32());
				if (y != 0) Test(x, y);
			}
		}
	}
}
