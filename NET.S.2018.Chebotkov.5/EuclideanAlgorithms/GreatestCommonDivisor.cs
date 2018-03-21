namespace EuclideanAlgorithms
{
    /// <summary>
    /// This class contains euclidean algorithm implementation. 
    /// </summary>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// This method implements euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Greatest common divisor</returns>
        public static int GetGCD(int firstNumber, int secondNumber)
        {
            if(firstNumber == 0 || secondNumber == 0)
            {
                throw new System.ArgumentOutOfRangeException("Number can't be equal 0");
            }

            if(firstNumber<0)
            {
                firstNumber = -firstNumber;
            }

            if(secondNumber<0)
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
        public static int GetGCD(params int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = GetGCD(result, numbers[i]);
            }

            return result;
        }
    }
}