using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TDD_Algorithms.Tests.FibonacciTests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]

        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected, GetFibonacci(index));
        }

        private int GetFibonacci(int index)
        {
            switch (index)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return GetFibonacci(index - 1) + GetFibonacci(index - 2);
            }
        }
    }
}
