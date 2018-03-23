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
        [TestCase(2, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, 2)]
        public void TestsForGreatestCommonDivisor(int expectedResult, params int[] numbers)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetGCD(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 324423, 324233, 232323)]
        [TestCase(1, 23, 32423343, 325324326)]
        public void TestsForGreatestCommonDivisor(int expectedResult, int firstNum, int secondNum, int thirdNum)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetGCD(firstNum, secondNum, thirdNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(18, 36, 18)]
        [TestCase(3, -3, -6)]
        [TestCase(11, 121, -33)]
        [TestCase(3, 3, 0)]
        [TestCase(3, 0, 3)]
        [TestCase(-1, 0, -1)]
        public void TestsForGreatestCommonDivisor(int expectedResult, int firstNum, int secondNum)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetGCD(firstNum, secondNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(System.Int32.MinValue, System.Int32.MinValue)]
        [TestCase(System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue)]
        public void TestsForGreatestCommonDivisor(params int[] numbers)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => SteinsAlgorithm.GreatestCommonDivisorMethods.GetGCD(numbers));
        }

        [TestCase(5, 0, 5)]
        [TestCase(4, 4, 0)]
        [TestCase(1, 5, 1)]
        [TestCase(1, 1, 5)]
        [TestCase(18, 36, 18)]
        [TestCase(3, -3, -6)]
        [TestCase(11, 121, -33)]
        public void TestsForGreatestCommonDivisorSA(int expectedResult, int firstNum, int secondNum)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetBGCD(firstNum, secondNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 324423, 324233, 232323)]
        [TestCase(1, 23, 32423343, 325324326)]
        public void TestsForGreatestCommonDivisorSA(int expectedResult, int firstNum, int secondNum, int thirdNum)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetBGCD(firstNum, secondNum, thirdNum);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(546, 1092, 546, 2184, 4368)]
        [TestCase(1, 123213, 324234, 24324121, 43683)]
        [TestCase(3, 171, 1233, 45, 111222111)]
        [TestCase(2, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, 2)]
        public void TestsForGreatestCommonDivisorSA(int expectedResult, params int[] numbers)
        {
            int result = SteinsAlgorithm.GreatestCommonDivisorMethods.GetBGCD(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(System.Int32.MinValue, System.Int32.MinValue)]
        [TestCase(System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue, System.Int32.MinValue)]
        public void TestsForGreatestCommonDivisorSA(params int[] numbers)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => SteinsAlgorithm.GreatestCommonDivisorMethods.GetBGCD(numbers));
        }
    }
}
