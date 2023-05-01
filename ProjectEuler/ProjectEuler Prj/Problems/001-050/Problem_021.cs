using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Helper;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Amicable numbers",
        @"Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.",
        true,
        21)]
    [ProblemSolutionInfo(125, 31626)]
    public class Problem021 : ProblemBase
    {

        protected override object InternalExecute()
        {
            BigInteger sumAmicible = 0;
            BigInteger factorsi, factorsj;

            for (BigInteger i = 2; i <= 10000; i++)
            {
                factorsi = sumFactors(i);
                if (factorsi > i && factorsi <= 10000)
                {
                    factorsj = sumFactors(factorsi);
                    if (factorsj == i)
                    {
                        sumAmicible += i + factorsi;
                    }
                }
            }

            return sumAmicible;
        }


        private static BigInteger sumFactors(BigInteger x)
        {
            int sqrtOfNumber = (int)x.Sqrt();
            BigInteger sum = 1;

            if (x == sqrtOfNumber * sqrtOfNumber)
            {
                sum += sqrtOfNumber;
                sqrtOfNumber--;
            }

            for (int i = 2; i <= sqrtOfNumber; i++)
            {
                if (x % i == 0)
                {
                    sum = sum + i + (x / i);
                }
            }

            return sum;
        }
    }
}
