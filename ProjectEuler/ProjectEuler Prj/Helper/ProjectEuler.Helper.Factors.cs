using System;
using System.Collections;
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
        /// Returns the largest prime factor o a number.
        /// </summary>
        /// <param name="value">Value whose largest prime factor is computed.</param>
        /// <returns>Largest prime factor of <paramref name="value"/></returns>
        public static BigInteger LargestPrimeFactor(this BigInteger value)
        {
            BigInteger result = BigInteger.MinusOne;

            while (value % 2 == 0)
            {
                result = 2;
                value >>= 1;
            }

            for (int i = 3; i <= value.Sqrt(); i += 2)
            {
                while (value % i == 0)
                {
                    result = i;
                    value = value / i;
                }
            }

            result = (value > 2) ? value : result;

            return result;
        }


        /// <summary>
        /// Given a list of prime numbers, evaluate the number of factors of the input value.
        /// </summary>
        /// <param name="value">Value whose number of factors is computed.</param>
        /// <param name="primelist">List of prime numbers used to evalute number of factors.</param>
        /// <returns>Number of factors of <paramref name="value"/>.</returns>
        public static BigInteger GetNumberOfFactorsByPrimes(BigInteger value, IEnumerable<BigInteger> primelist)
        {
            BigInteger nod = BigInteger.One;
            BigInteger exponent = BigInteger.One;
            BigInteger remain = value;


            foreach (var prime in primelist)
            {
                if (prime * prime > value) return nod * 2;

                exponent = BigInteger.One;
                while (remain % prime == 0)
                {
                    exponent++;
                    remain = remain / prime;
                }
                nod *= exponent;

                if (remain == 1)
                {
                    return nod;
                }
            }

            return nod;

        }


        /// <summary>
        /// Returns all factors of input value.
        /// </summary>
        /// <param name="x">Value whose extract list of factors is coputed.</param>
        /// <returns>List of factors belong to <paramref name="x"/>.</returns>
        public static IEnumerable<BigInteger> Factors(this BigInteger x)
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
    }
}
