using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Helper
{
    public static partial class ProjectEulerHelper
    {
        /// <summary>
        /// Returns the square root of a number.
        /// </summary>
        /// <param name="value">Value whose square root is computed.</param>
        /// <returns>Square root of <paramref name="value"/>.</returns>
        public static double Sqrt(this BigInteger number)
        {
            const int limitSQRT = 10;

            if (number < 0) throw new ArgumentException("Input value cannot be a negative value.");


            double[] values = new double[limitSQRT];
            var num = (double)number;
            values[0] = num * 0.5;
            for (int i = 1; i < limitSQRT; i++)
            {
                values[i] = 0.5F * (values[i - 1] + num / values[i - 1]);
            }

            return values[limitSQRT - 1];
        }

        /// <summary>
        /// Check whether input value is palindrome or not.
        /// </summary>
        /// <param name="value">Value whose check if palindrome is evaluted.</param>
        /// <returns>Returns true if the given number is a palindrome; false otherwise.</returns>
        public static bool IsPalindrome(this BigInteger value)
        {
            bool result = false;

            var valueString = value.ToString();
            var length = valueString.Length;
            var endCheck = (int)Math.Truncate(length / 2.0F);

            result = Enumerable.Range(0, endCheck).All(i => valueString[i] == valueString[length - i - 1]);
            return result;
        }

        /// <summary>
        /// Check whether input value is abundant number or not.
        /// </summary>
        /// <param name="value">Value whose check if a abundant number is evaluated.</param>
        /// <returns>Returns true if the input value is abundant; false otherwise.</returns>
        public static bool IsAbundant(this BigInteger value)
        {
            return (ProjectEulerHelper.SumProperDivisors(value) > value);
        }

        /// <summary>
        /// Check whether input value is deficient number or not.
        /// </summary>
        /// <param name="value">Value whose check if a abundant number is evaluated.</param>
        /// <returns>Returns true if the input value is abundant; false otherwise.</returns>
        public static bool IsDeficient(this BigInteger value)
        {
            return (ProjectEulerHelper.SumProperDivisors(value) < value);
        }

        /// <summary>
        /// Check whether input value is a Perfect Number or not.
        /// </summary>
        /// <param name="value">Value whose check if a abundant number is evaluated.</param>
        /// <returns>Returns true if the input value is abundant; false otherwise.</returns>
        public static bool IsPerfectNumber(this BigInteger value)
        {
            return (ProjectEulerHelper.SumProperDivisors(value) == value);
        }

        /// <summary>
        /// Check whether input value is a Narcissistic number.
        /// </summary>
        /// <param name="value">Value whose check if a narcissistic number is evaluted.</param>
        /// <param name="exponent">Exponent.</param>
        /// <returns>Returns true if input value is narcissistic; false otherwise.</returns>
        /// <seealso cref="https://en.wikipedia.org/wiki/Narcissistic_number"/>
        public static bool IsNarcissisticNumber(this BigInteger value, int exponent)
        {
            BigInteger temp = value;
            BigInteger sum = BigInteger.Zero;
            while (temp > 0)
            {
                var d = temp % 10;

                sum += BigInteger.Pow(d, exponent);

                temp /= 10;
            }
            return sum == value;
        }

        /// <summary>
        /// Check whether input value is a Pandigital number.
        /// </summary>
        /// <param name="value">Value whose check if a pandigital number is evaluated.</param>
        /// <returns>Returns true if a pandigital number; false otherwise.</returns>
        public static bool IsPandigital(this BigInteger value, int starting = 0)
        {
            var valueToText = value.ToString();
            return Enumerable.Range(starting, valueToText.Length).Except(valueToText.Select(x => x - 48)).Any() == false;
        }
    }
}
