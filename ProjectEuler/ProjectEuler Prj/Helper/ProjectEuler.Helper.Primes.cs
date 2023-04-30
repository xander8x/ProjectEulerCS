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

        public static bool IsPrime(BigInteger value)
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

    }
}
