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
        /// Returns factorial of input value.
        /// </summary>
        /// <param name="value">Value whose factorial is computed.</param>
        /// <returns>Factorial of <paramref name="value"/>.</returns>
        public static BigInteger GetFactorial(BigInteger value)
        {
            BigInteger result = BigInteger.One;
            if (value > 1)
            {
                result = value * GetFactorial(value - 1);
            }

            return result;
        }

        /// <summary>
        /// Concat two integer numbers.
        /// </summary>
        public static Func<BigInteger, BigInteger, BigInteger> ConcatNumbers = (a, b) =>
        {
            BigInteger c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }

            return a + b;
        };

        /// <summary>
        /// Evalute Greatest Common Divisors (GCD).
        /// </summary>
        /// <param name="values">Array of values to evalute GCD.</param>
        /// <returns>GCD of input values</returns>
        public static BigInteger GreatestCommonDivisor(BigInteger[] values)
        {
            return values.Aggregate(GreatestCommonDivisor);
        }

        /// <summary>
        /// Evalute Greatest Common Divisors (GCD).
        /// </summary>
        /// <param name="a">First value whose the GDC is computed.</param>
        /// <param name="b">Second value whose the GDC is computed.</param>
        /// <returns>GCD of the input values.</returns>
        public static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }           
    }
}
