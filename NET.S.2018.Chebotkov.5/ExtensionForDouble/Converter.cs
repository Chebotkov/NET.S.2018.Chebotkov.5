using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionForDouble
{
    public static class Converter
    {
        public static string ConvertToString(this double number)
        {
            int exponent = number < 1 ? Normalization(ref number) : GetExponent(number);

            double integerPart = Math.Ceiling(number);
            char[] binaryArrayOfIntegers = GetBinaryRepresentationOfIntegerPart(integerPart);
            char[] fraction = GetBinaryRepresentationOfFraction(number - integerPart);

            char[] mantissa = new char[52];
            GetMantissa(ref mantissa, binaryArrayOfIntegers, fraction);
            return GetResult(mantissa, exponent, number < 0 ? '1' : '0');

        }

        private static string GetResult(char[] mantissa, int exponent, char sign)
        {
            return sign.ToString() + String.Concat(GetBinaryRepresentationOfIntegerPart(1023+exponent-1)) + String.Concat(mantissa);
        }

        public static void GetMantissa(ref char[] mantissa, char[] binaryArrayOfIntegers, char[] fraction)
        {
            if (binaryArrayOfIntegers.Length < mantissa.Length)
            {
                for (int i = 0, j = 0; i < mantissa.Length; i++)
                {
                    if (i < binaryArrayOfIntegers.Length - 1)
                    {
                        mantissa[i] = binaryArrayOfIntegers[i + 1];
                    }
                    else
                    {
                        if (j > fraction.Length-1)
                        {
                            return;
                        }
                        mantissa[i] = fraction[j];
                        j++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < mantissa.Length; i++)
                {
                    mantissa[i] = binaryArrayOfIntegers[i + 1];
                }
            }
        }
        public static int GetExponent(double number)
        {
            int count = 0;
            number = Math.Ceiling(number);

            while(number >= 1)
            {
                number /= 10;
                count++;
            }

            return count;
        }

        public static int Normalization(ref double number)
        {
            int exponent = 0;
            while(number < 1)
            {
                number *= 10;
                exponent--;
            }
            return exponent; 
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

        private static char[] GetBinaryRepresentationOfFraction(double number)
        {
            List<char> list = new List<char>();
            number *= 2;
            for (int i = 0; i < GetCountOfDigitsInFraction(number); i++)
            {
                list.Add(Math.Ceiling(number) == 1 ? '1' : '0');
                number *= 2;
            }

            return list.ToArray<char>();
        }

        public static int GetCountOfDigitsInFraction(double number)
        {
            double temp = number * 10;
            int count = 1;

            while (Math.Ceiling(temp) - number * 10 != 0)
            {
                count++;
                temp *= 10;
                number *= 10;
            }

            return count;
        }
    }
}
