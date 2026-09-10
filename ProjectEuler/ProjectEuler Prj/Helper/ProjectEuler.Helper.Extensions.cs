using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Helper
{
    public static partial class ProjectEulerHelper
    {
        public static bool IsTriangular(this BigInteger number)
        {
            BigInteger value = 1 + 8 * number;
        
            int s = (int)Math.Round(value.Sqrt());

            return s * s == 1 + 8 * number && (-1 + s) % 2 == 0;
        }


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


        public static bool IsPandigitalDigit(this BigInteger number, int n = 9)
        {
            if (n < 1 || n > 9) return false;

            string str = number.ToString();
            if (str.Length != n) return false;

            int expectedMask = (1 << n) - 1; // Bits 0 to n-1 set to 1
            int mask = 0;

            foreach (char c in str)
            {
                int digit = c - '0';
                if (digit < 1 || digit > n) return false;

                int bit = 1 << (digit - 1);
                if ((mask & bit) != 0) return false; // Duplicate digit found

                mask |= bit;
            }

            return mask == expectedMask;
        }

        public static int DigitCount(this BigInteger number)
        {
            if (number.IsZero) return 1;
            if (number.IsOne) return 1;

            number = BigInteger.Abs(number);
            return (int)BigInteger.Log10(number) + 1;
        }

        public static BigInteger Abs(this BigInteger value)
        {
            return value >= 0 ? value : -value;
        }

        public static List<BigInteger> GetAllCircualRotations(this BigInteger value)
        {
            List<BigInteger> result = new List<BigInteger>();

            BigInteger n = value.Abs();
            if (n < 10)
            {
                result.Add(value);
                return result;
            }

            int nDigits = value.ToString().ToCharArray().Length;
            int multiply = (int)Math.Pow(10, nDigits - 1);

            BigInteger current = n;
            for (int i = 0; i < nDigits; i++)
            {
                result.Add(value < 0 ? -current : current);
                BigInteger firstDigit = current / multiply;
                BigInteger remainder = current % multiply;

                current = (remainder * 10) + firstDigit;
            }

            return result;
        }

        public static List<BigInteger> GetAllPermutations(this BigInteger value)
        {
            List<BigInteger> result = new List<BigInteger>();
            char[] digits = value.ToString().ToCharArray();

            if (digits.Length == 1) return new List<BigInteger> { value };
            else
            {
                HashSet<BigInteger> res = new HashSet<BigInteger>();

                _generatePermutation(digits, 0, res);

                return  new List<BigInteger>(res);
            }
        }

        public static BigInteger Append(this BigInteger original, int toAppend)
        {
            if (toAppend < 0)
                throw new ArgumentOutOfRangeException(nameof(toAppend));

            if (toAppend == 0)
                return original * 10;

            int multiplier = 1;
            int temp = toAppend;
            while (temp > 0)
            {
                multiplier *= 10;
                temp /= 10;
            }
            return (original * multiplier) + toAppend;
        }

        public static IEnumerable<BigInteger> GetLeftTrucates(this BigInteger value)
        {
            var s = value.ToString();
            List<BigInteger> res = new List<BigInteger>();
            for (int i = 0; i < s.Length; i++)
            {
                res.Add(BigInteger.Parse(string.Join("", s.ToCharArray().Skip(i))));
            }

            return res;
        }

        public static IEnumerable<BigInteger> GetRightTrucates(this BigInteger value)
        {
            var s = value.ToString();
            List<BigInteger> res = new List<BigInteger>();
            for (int i = 0; i < s.Length; i++)
            {
                res.Add(BigInteger.Parse(string.Join("", s.ToCharArray().Take(s.Length - i))));
            }

            return res;
        }

        public static BigInteger ConvertToBase(this BigInteger value, uint targetBase)
        {
            Func<int> _shift = () =>
            {
                if (targetBase == 2) return 1;
                else if (targetBase == 4) return 2;
                else if (targetBase == 8) return 3;
                else return 0;
            };

            if (targetBase < 2 || targetBase > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(targetBase), "The base must be between 2 and 10.");
            }

            if (value.IsZero) return BigInteger.Zero;

            bool isNegative = value < 0;
            BigInteger current = BigInteger.Abs(value);

            BigInteger result = BigInteger.Zero;
            BigInteger multiplier = BigInteger.One;

            uint rem = targetBase - 1;

            int shift = (int)Math.Log(targetBase, 2);

            switch (targetBase)
            {
                case 2:
                case 4:
                case 8:
                    while (current > 0)
                    {
                        int remainder = (int)(current & rem);
                        if (remainder != 0)
                        {
                            result += remainder * multiplier;
                        }
                        current >>= shift;
                        multiplier *= 10;
                    }
                    break;

                case 10:
                    return value;

                default:
                    while (current > 0)
                    {
                        current = BigInteger.DivRem(current, targetBase, out BigInteger remainder);
                        if (!remainder.IsZero)
                        {
                            result += remainder * multiplier;
                        }
                        multiplier *= 10;
                    }
                    break;
            }
            return isNegative ? -result : result;
        }


        // ============================
        // ============================
        // ============================
        private static void _generatePermutation(char[] digits, int index, HashSet<BigInteger> result)
        {
            if(index == digits.Length - 1 )
            {
                result.Add(BigInteger.Parse(new string(digits)));
            }
            else
            {
                for (int i = index; i < digits.Length; i++)
                {
                    _exchange(ref digits[index], ref digits[i]);
                    _generatePermutation(digits, index + 1, result);
                    _exchange(ref digits[index], ref digits[i]);
                }
            }
        }

        private static void _exchange(ref char a, ref char b)
        {
            char c = a;
            a = b;
            b = c;
        }
    }
}
