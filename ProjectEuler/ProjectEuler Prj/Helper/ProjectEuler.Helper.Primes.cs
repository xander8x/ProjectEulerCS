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
        /// Get list of primes below a limit.
        /// </summary>
        /// <param name="limit">Limit of prime.</param>
        /// <returns>Primes up to limit.</returns>
        /// <exception cref="Exception">Raise exception </exception>
        public static IEnumerable<BigInteger> GetPrimes(int limit)
        {
            BitArray PrimeBits = new BitArray(limit, true);


            if (limit < 2)
            {
                throw new Exception("Number must be greater than 1");
            }
            else
            {
                PrimeBits.Set(0, false); 
                PrimeBits.Set(1, false); 

                for (int P = 2; P < (int)Math.Sqrt(limit) + 1; P++)
                {
                    if (PrimeBits.Get(P))
                    {
                        for (int PMultiply = P * 2; PMultiply < limit; PMultiply += P)
                            PrimeBits.Set(PMultiply, false);
                    }
                }                    
            }

            return Enumerable.Range(0, limit)
                             .Where(x => PrimeBits[x] == true)
                             .Select(x => new BigInteger(x));

        }

        /// <summary>
        /// Check input value is a prime number.
        /// </summary>
        /// <param name="value">Value whose check if prime is computed.</param>
        /// <returns>True when the input value is a prime number, false otherwise.</returns>
        public static bool IsPrime(this BigInteger value)
        {
            if (value <= 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;


            var boundary = (int)Math.Floor(value.Sqrt());

            for (int i = 3; i <= boundary; i += 2)
            {
                if (value % i == 0)return false;
            }

            return true;
        }

        /// <summary>
        /// Get n-th number prime.
        /// </summary>
        /// <param name="n">Value whose n-th prime is computed.</param>
        /// <returns>N-th prime defined by <paramref name="n"/>.</returns>
        public static BigInteger GetNthPrime(int n)
        {
            var log_n = BigInteger.Log(n);
            var limit = (int)(n * (log_n + Math.Log(log_n) - 0.5));
            return GetPrimes(limit).Skip(n).First();           
        }
    }
}
