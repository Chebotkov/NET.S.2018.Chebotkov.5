namespace SteinsAlgorithm
{
    /// <summary>
    /// This class contains Steins algorithm implementation. 
    /// </summary>
    public class BinaryGreatestCommonDivisor
    {
        /// <summary>
        /// This method implements Steins algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(int firstNumber, int secondNumber)
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
                return 2 * GetGCD(firstNumber / 2, secondNumber / 2);
            }

            if (firstNumber % 2 == 0)
            {
                return GetGCD(firstNumber / 2, secondNumber);
            }

            if (secondNumber % 2 == 0)
            {
                return GetGCD(firstNumber, secondNumber / 2);
            }

            if (firstNumber > secondNumber)
            {
                return GetGCD((firstNumber - secondNumber) / 2, secondNumber);
            }
            else
            {
                return GetGCD((secondNumber - firstNumber) / 2, firstNumber);
            }
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
            return GetGCD(GetGCD(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(params int [] numbers)
        {
            int result = GetGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = GetGCD(result, numbers[i]);
            }

            return result;
        }
    }
}
