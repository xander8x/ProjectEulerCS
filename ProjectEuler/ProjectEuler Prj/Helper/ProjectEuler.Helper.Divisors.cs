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
        /// Returns all factors of input value.
        /// </summary>
        /// <param name="x">Value whose extract list of factors is coputed.</param>
        /// <returns>List of factors belong to <paramref name="x"/>.</returns>
        public static IEnumerable<BigInteger> Divisors(this BigInteger x)
        {
            for (BigInteger i = 1; i * i <= x; i++)
            {
                if ((x % i) == 0)
                {
                    yield return i;
                    if (i != (x / i))
                    {
                        yield return x / i;
                    }
                }
            }
        }

        /// <summary>
        /// Returns sum of factors of input value.
        /// </summary>
        /// <param name="x">Value whose sum of factors is computed.</param>
        /// <returns>Sum of factors of <paramref name="x"/>.</returns>
        public static BigInteger SumOfAllDivisors(this BigInteger x)
        {
            return x.Divisors().Aggregate(BigInteger.Zero, (a, b) => a + b);
        }

        /// <summary>
        /// Returns sum of proper factors.
        /// </summary>
        /// <param name="value">Value whose sum of proper factor is computed.</param>
        /// <returns>Sum of proper factor.</returns>
        public static BigInteger SumProperDivisors(this BigInteger value)
        {
            return SumOfAllDivisors(value) - value;
        }
    }
}
