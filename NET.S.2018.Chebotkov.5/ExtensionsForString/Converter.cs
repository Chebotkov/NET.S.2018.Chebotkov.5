using System;

namespace ExtensionsForString
{
    /// <summary>
    /// This class is about Notation.
    /// </summary>
    public class Notation
    {
        private int systemBase;
        private char[] symbols;
        private int minBoarder = 2, maxBoarder = 16;

        /// <summary>
        /// Initialization of notation.
        /// </summary>
        /// <param name="systemBase">Base of Notation.</param>
        /// <param name="symbols">Available symbols for notation.</param>
        public Notation(int systemBase)
        {
            if (systemBase < minBoarder || systemBase > maxBoarder)
            {
                throw new ArgumentException("Wrong notation. Notation must be: 2<=Notation<=16");
            }

            this.systemBase = systemBase;
            GetSymbols();
        }

        private void GetSymbols()
        {
            char[] digits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            symbols = new char[systemBase - 1];
            for (int i = 0; i < systemBase; i++)
            {
                symbols[i] = digits[i];
            }
        }

        public int SystemBase { get; }
        public char[] Symbols { get; }
    }

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
        public static int ConvertTo(this string number, Notation notation)
        {
            if (String.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("Number can't be null or empty!");
            }
            int result = notation.Symbols.IndexOf(number[number.Length - 1], notation.SystemBase);
            int power = notation.SystemBase;
            checked
            {
                for (int i = number.Length - 2; i >= 0; i--, power *= notation.SystemBase)
                {
                    result += notation.Symbols.IndexOf(number[i], notation.SystemBase) * power;
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
                if (Char.ToUpper(digit) == digits[i])
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
