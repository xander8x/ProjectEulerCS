using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Power digit sum",
        @"2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2^1000?",
        true,
        16)
    ]
    [ProblemSolutionInfo(15, 1366)]
    public class Problem016 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return BigInteger.Pow(2, 1000).ToString().Select(x => x - 48).Sum();

        }
    }
}