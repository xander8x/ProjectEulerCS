using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Digit fifth powers",
@"Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

    1634 = 1^4 + 6^4 + 3^4 + 4^4
    8208 = 8^4 + 2^4 + 0^4 + 8^4
    9474 = 9^4 + 4^4 + 7^4 + 4^4
As 1 = 1^4 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.",
        true,
        30)
    ]
    [ProblemSolutionInfo(483, 443839)]
    class Problem030 : ProblemBase
    {

        protected override object InternalExecute()
        {
            int exp = 5;
            var limit = (int) (6*Math.Pow(9,exp));

            return  Enumerable.Range(10, limit)
                              .Where(x => ProjectEulerHelper.IsNarcissisticNumber(x, exp))
                              .Aggregate(BigInteger.Zero, (a, b) => a + b);

        }
    }
}
