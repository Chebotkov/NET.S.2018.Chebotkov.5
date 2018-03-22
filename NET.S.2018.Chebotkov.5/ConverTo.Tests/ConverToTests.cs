using System;
using NUnit.Framework;
using ExtensionsForString;

namespace ConverTo.Tests
{
    [TestFixture]
    public class ConverToTests
    {
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("11101101111011001100001010111111", 2, 3991716543)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        public void TestsForConverTo(string number, int notation, uint expectedResult)
        {
            uint result = number.ConvertTo(notation);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        [TestCase("SA123", 16)]
        [TestCase("1AeF101", 10)]
        public void TestsForGreatestCommonDivisor(string number, int notation)
        {
            Assert.Throws<System.ArgumentException>(() => number.ConvertTo(notation));
        }
    }
}
