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
        public static double Sqrt(this BigInteger value)
        {
            return Math.Pow(Math.E, BigInteger.Log(value) / 2.0F);
        }

        /// <summary>
        /// Check whether input value is palindrome or not.
        /// </summary>
        /// <param name="value">Value whose check if palindrome is computed.</param>
        /// <returns>Returns true if the given number is a palindrome, else false.</returns>
        public static bool IsPalindrome(this BigInteger value)
        {
            bool result = false;

            var valueString = value.ToString();
            var length = valueString.Length;
            var endCheck = (int)Math.Truncate(length / 2.0F);

            result = Enumerable.Range(0, endCheck).All(i => valueString[i] == valueString[length - i - 1]);
            return result;
        }
    }
}
