using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TDD_Algorithms.Tests.RomanNumeralTests
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(14, "XIV")]
        [TestCase(9, "IX")]
        public void Parse(int expected, string roman)
        {
            Assert.AreEqual(expected, Roman.Parse(roman));
        }
    }

    public class Roman
    {
        private static Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };
        public static int Parse(string roman)
        {
            int total = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubtractive(roman[i], roman[i+1]))
                {
                    total -= map[roman[i]];
                }
                else
                {
                    total += map[roman[i]];
                }
            }
            return total;
        }

        private static bool IsSubtractive(char c1, char c2)
        {
            return map[c1] < map[c2];
        }
    }
}
