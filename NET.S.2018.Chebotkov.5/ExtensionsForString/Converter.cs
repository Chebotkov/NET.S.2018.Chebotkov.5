using System;

namespace ExtensionsForString
{
    /// <summary>
    /// This class contains method which converts string value to integer number with specified notation.  
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// This method is extension for string type. It converts string value to integer number with specified notation.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="notation">Notation.</param>
        /// <exception cref="ArgumentException">Throws when wrong number was entered.</exception>
        /// <returns>Returns decimal value of received number.</returns>
        public static uint ConvertTo(this string number, int notation)
        {
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            uint result = (uint)digits.IndexOf(number[number.Length - 1], notation);
            uint power = (uint)notation;
            checked
            {
                for (int i = number.Length - 2; i >= 0; i--, power *= (uint)notation)
                {
                    result += (uint)digits.IndexOf(number[i], notation) * power;
                }
            }

            return result;
        }

        /// <summary>
        /// This method finds index of digit in char array.
        /// </summary>
        /// <param name="digits">Array of digits.</param>
        /// <param name="digit">Wanted digit.</param>
        /// <exception cref="ArgumentException">Throws when wrong number was entered.</exception>
        /// <returns>Returns index of received digit.</returns>
        private static int IndexOf(this char[] digits, char digit, int notation)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                char currentDigit = digits[i];

                if (Char.ToUpper(digit) == currentDigit)
                {
                    if (i > notation)
                    {
                        throw new ArgumentException("Number does not match the Notation!");
                    }

                    return i;
                }
            }

            throw new ArgumentException("Wrong number!");
        }
    }
}
