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
            char[] fraction = GetBinaryRepresentationOfIntegerPart(integerPart);
            GetBinaryRepresentationOfFraction(number - integerPart, ref fraction);
            char[] result = new char[System.Runtime.InteropServices.Marshal.SizeOf(number)];
            result[0] = number < 0 ? '1' : '0';


            return "da";
        }

        /// <summary>
        /// Method returns binary representation of received number.
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>Array of integer numbers</returns>
        private static char[] GetBinaryRepresentationOfIntegerPart(double number)
        {
            List<char> list = new List<char>();
            while (number >= 1)
            {
                list.Insert(0, number % 2 == 0 ? '0' : '1');
                
                number /= 2;
            }

            return list.ToArray<char>();
        }

        private static void GetBinaryRepresentationOfFraction(double number, ref char [] fraction)
        {
            for (int i=0; i<GetCountOfDigitsInFraction(number); i++)
            {
                fraction[i] = Math.Ceiling(number * 2) == 1 ? '1' : '0';


            }
        }

        public static int GetCountOfDigitsInFraction(double number)
        {
            double temp = number * 10;
            int count = 1;

            while(Math.Ceiling(temp) - number * 10 !=0)
            {
                count++;
                temp *= 10;
                number *= 10;
            }

            return count;
        }

    }
}
