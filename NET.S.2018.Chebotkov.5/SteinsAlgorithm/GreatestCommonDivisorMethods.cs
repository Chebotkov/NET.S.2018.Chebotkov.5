namespace SteinsAlgorithm
{
    /// <summary>
    /// This class contains Steins algorithm implementation. 
    /// </summary>
    public static class GreatestCommonDivisorMethods
    {
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
            if (firstNumber == System.Int32.MinValue && secondNumber == System.Int32.MinValue)
            {
                throw new System.ArgumentOutOfRangeException("Result is greater then max possible value.");
            }

            return GetBGCDWithoutExc(firstNumber, secondNumber);
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
            AreAllEqualToInt32MinValue(firstNumber, secondNumber, thirdNumber);
            return GetBGCDWithoutExc(GetBGCDWithoutExc(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetBGCD(params int[] numbers)
        {
            AreAllEqualToInt32MinValue(numbers);
            int result = GetBGCDWithoutExc(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = GetBGCDWithoutExc(result, numbers[i]);
            }

            return result;
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
            if (firstNumber == System.Int32.MinValue && secondNumber == System.Int32.MinValue)
            {
                throw new System.ArgumentOutOfRangeException("Result is greater then max possible value.");
            }

            return GetGCDWithoutExc(firstNumber, secondNumber);
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
            AreAllEqualToInt32MinValue(numbers);
            int result = GetGCDWithoutExc(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = GetGCDWithoutExc(result, numbers[i]);
            }

            return result;
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

        #region Checker
        /// <summary>
        /// Checks if all elements in array are equal to Int32.MinValue.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws when all arguments are equal to Int32.MinValue.</exception>
        /// <returns>False if there is one element doesn't equal to Int32.MinValue in array.</returns>
        private static bool AreAllEqualToInt32MinValue(params int [] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != System.Int32.MinValue)
                {
                    return false;
                }
            }

            throw new System.ArgumentOutOfRangeException("Result is greater then max possible value.");
        }
        #endregion
    }
}
