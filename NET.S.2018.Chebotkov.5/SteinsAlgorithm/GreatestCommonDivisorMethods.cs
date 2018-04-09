using System;

namespace SteinsAlgorithm
{
    /// <summary>
    /// This class contains Steins algorithm implementation. 
    /// </summary>
    public static class GreatestCommonDivisorMethods
    {
        private static int GetGCDWithDelegate(Func<int, int, int> func, params int [] numbers)
        {
            int result = func(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = func(result, numbers[i]);
                if (result == 1)
                {
                    return result;
                }
            }

            if (result == Int32.MinValue)
            {
                throw new System.ArgumentOutOfRangeException("Result is greater than max possible value.");
            }

            return result;
        }

        #region BinaryGreatestCommonDivisor methods
        /// <summary>
        /// This method implements Steins algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when all arguments are equal to Int32.MinValue.</exception>
        /// <returns>Greatest common divisor</returns>
        public static int GetBGCD(int firstNumber, int secondNumber)
        {
            int result = GetBGCDWithoutExc(firstNumber, secondNumber);
            if (result == Int32.MinValue)
            {
                throw new System.ArgumentOutOfRangeException("Result is greater than max possible value.");
            }

            return result;
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetBGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GetBGCDWithoutExc(GetBGCDWithoutExc(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetBGCD(params int[] numbers)
        {
            return GetGCDWithDelegate(GetBGCDWithoutExc, numbers);
        }

        /// <summary>
        /// This method implements Steins algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetBGCDWithoutExc(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber < 0)
            {
                firstNumber = -firstNumber;
            }

            if (secondNumber < 0)
            {
                secondNumber = -secondNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }

            if (firstNumber % 2 == 0 && secondNumber % 2 == 0)
            {
                return 2 * GetBGCDWithoutExc(firstNumber / 2, secondNumber / 2);
            }

            if (firstNumber % 2 == 0)
            {
                return GetBGCDWithoutExc(firstNumber / 2, secondNumber);
            }

            if (secondNumber % 2 == 0)
            {
                return GetBGCDWithoutExc(firstNumber, secondNumber / 2);
            }

            if (firstNumber > secondNumber)
            {
                return GetBGCDWithoutExc((firstNumber - secondNumber) / 2, secondNumber);
            }
            else
            {
                return GetBGCDWithoutExc((secondNumber - firstNumber) / 2, firstNumber);
            }
        }
        #endregion

        #region GreatestCommonDivisor methods
        /// <summary>
        /// This method implements Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(int firstNumber, int secondNumber)
        {
            int result = GetGCDWithoutExc(firstNumber, secondNumber);
            if (result == Int32.MinValue)
            {
                throw new System.ArgumentOutOfRangeException("Result is greater than max possible value.");
            }

            return result;
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GetGCDWithoutExc(GetGCDWithoutExc(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(params int[] numbers)
        {
            return GetGCDWithDelegate(GetGCDWithoutExc, numbers);
        }
        
        /// <summary>
        /// This method implements Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetGCDWithoutExc(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber < 0)
            {
                firstNumber = -firstNumber;
            }

            if (secondNumber < 0)
            {
                secondNumber = -secondNumber;
            }

            while (firstNumber != 0 && secondNumber != 0)
            {
                if (firstNumber % secondNumber == 0)
                {
                    return secondNumber;
                }

                if (secondNumber % firstNumber == 0)
                {
                    return firstNumber;
                }

                if (secondNumber > firstNumber)
                {
                    secondNumber %= firstNumber;
                }

                if (firstNumber > secondNumber)
                {
                    firstNumber %= secondNumber;
                }
            }

            return firstNumber + secondNumber;
        }
        #endregion
    }
}
