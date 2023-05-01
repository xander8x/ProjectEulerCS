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
    [ProblemAttributes("Factorial digit sum",
        @"n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!",
        true,
        20)]
    [ProblemSolutionInfo(4, 648)]
    public class Problem020 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.GetFactorial(100)
                                     .ToString()
                                     .ToCharArray()
                                     .Select(x => x - 48)
                                     .Aggregate(BigInteger.Zero, (x, y) => x + y);

        }
    }
}
