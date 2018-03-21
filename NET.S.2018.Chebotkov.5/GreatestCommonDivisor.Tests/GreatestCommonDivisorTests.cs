using NUnit.Framework;

namespace GreatestCommonDivisor.Tests
{
    /// <summary>
    /// Test class for GreatestCommonDivisor
    /// </summary>
    [TestFixture]
    public class GreatestCommonDivisorTests
    {
        [TestCase(546, 1092, 546, 2184, 4368)]
        [TestCase(1, 123213, 324234, 24324121, 43683)]
        [TestCase(3, 171, 1233, 45, 111222111)]
        public void TestsForGreatestCommonDivisor(int expectedResult, params int[] numbers)
        {
            int result = EuclideanAlgorithms.GreatestCommonDivisor.GetGCD(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 324423, 324233, 232323)]
        [TestCase(1, 23, 32423343, 325324326)]
        public void TestsForGreatestCommonDivisor(int expectedResult, int firstNum, int secondNum, int thirdNum)
        {
            int result = EuclideanAlgorithms.GreatestCommonDivisor.GetGCD(firstNum, secondNum, thirdNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(18, 36, 18)]
        [TestCase(3, -3, -6)]
        [TestCase(11, 121, -33)]
        public void TestsForGreatestCommonDivisor(int expectedResult, int firstNum, int secondNum)
        {
            int result = EuclideanAlgorithms.GreatestCommonDivisor.GetGCD(firstNum, secondNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0,0)]
        [TestCase(0,1)]
        [TestCase(-1,0)]
        public void TestsForGreatestCommonDivisor(int firstNum, int secondNum)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>( () => EuclideanAlgorithms.GreatestCommonDivisor.GetGCD(firstNum, secondNum));
        }

        [TestCase]
        public void TestsForGreatestCommonDivisor()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => EuclideanAlgorithms.GreatestCommonDivisor.GetGCD(1, 3, 3, 3, 0, 4));
        }
    }
}
