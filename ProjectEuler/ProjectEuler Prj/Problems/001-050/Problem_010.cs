using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Helper;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Summation of primes",
@"The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
Find the sum of all the primes below two million.",
        false,
        10)]
    [ProblemSolutionInfo(62, 142913828922)]
    public class Problem010 : ProblemBase
    {
        protected override object InternalExecute()
        {
            var upperLimit = 2000000;
            return ProjectEulerHelper.GetPrimes(upperLimit).Aggregate(BigInteger.Zero, (x, y) => x + y);

        }
    }
}
