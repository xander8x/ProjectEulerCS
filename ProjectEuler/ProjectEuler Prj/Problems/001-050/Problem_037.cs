using ProjectEuler.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Double-base Palindromes",
        @"
The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, 
and remain prime at each stage:3797,797,97, and 7. Similarly we can work from right to left:3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.",
        true,
        37)
    ]
    [ProblemSolutionInfo(1012, 748317)]
    public class Problem037 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int limit = 1000000;

            var list = ProjectEulerHelper.GetPrimes(limit).ToList();

            List<BigInteger> res = new List<BigInteger>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 10) continue;
                if (list[i].GetLeftTrucates().Any(x => x.IsPrime() == false)) continue;
                if (list[i].GetRightTrucates().Any(x => x.IsPrime() == false)) continue;

                res.Add(list[i]);
                if (res.Count == 11) break;
            }

            return res.Aggregate(BigInteger.Zero, BigInteger.Add);
        }
    }
}