using ExtensionsForString;
using NUnit.Framework;

namespace ConverTo.Tests
{
    [TestFixture]
    public class ConverToTests
    {        
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("1001", 2, 9)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        public void TestsForConverTo(string number, int notation, int expectedResult)
        {
            int result = number.ConvertTo(new Notation(notation));

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        [TestCase("SA123", 16)]
        [TestCase("1AeF101", 10)]
        public void TestsForConverTo(string number, int notation)
        {
            Assert.Throws<System.ArgumentException>(() => number.ConvertTo(new Notation(notation)));
        }


        [TestCase("0110111101100001100001010111111", 2)]
        [TestCase("111111111111111111111111111111111111111111111111111111", 2)]
        public void TestsForConverToOFE(string number, int notation)
        {
            Assert.Throws<System.OverflowException>(() => number.ConvertTo(new Notation(notation)));
        }
    }
}
