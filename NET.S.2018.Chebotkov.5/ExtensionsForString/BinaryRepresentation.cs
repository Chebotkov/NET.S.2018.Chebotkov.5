using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsForString
{
    public class BinaryRepresentation
    {
        public static string GetBinaryRepresentationOfNumber(double number)
        {
            double integerPart = Math.Ceiling(number);
            char[] binaryArrayOfIntegers = new char[System.Runtime.InteropServices.Marshal.SizeOf(number)*8-1];
            GetBinaryRepresentationOfIntegerPart(integerPart, ref binaryArrayOfIntegers);
            char[] fraction = new char[System.Runtime.InteropServices.Marshal.SizeOf(number) * 8-1];
            GetBinaryRepresentationOfFraction(number - integerPart, ref fraction);

            return "da";
        }

        /// <summary>
        /// Method returns binary representation of received number.
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Array of integer numbers</returns>
        private static void GetBinaryRepresentationOfIntegerPart(double number, ref char[] binaryArrayOfIntegers)
        {
            int i = binaryArrayOfIntegers.Length - 1;
            while (number >= 1)
            {
                if (number % 2 == 0)
                {
                    binaryArrayOfIntegers[i] = '0';
                }
                else
                {
                    binaryArrayOfIntegers[i] = '1';
                }

                number /= 2;
                i--;
            }
        }

        private static void GetBinaryRepresentationOfFraction(double number, ref char [] fraction)
        {

        }

        private static void GetCountOfDigitsInFraction(double number)
        {

        }

    }
}
