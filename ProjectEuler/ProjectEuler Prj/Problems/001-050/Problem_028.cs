using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Quadratic primes",
@"Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

    21 22 23 24 25
    20  7  8  9 10
    19  6  1  2 11
    18  5  4  3 12
    17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?",
        true,
        28)
    ]
    [ProblemSolutionInfo(1, 669171001)]
    public class Problem028 : ProblemBase
    {
        protected override object InternalExecute()
        {

            var limit = (int)Math.Floor(1001 / 2.0);

            // res = 1 + sum_1^k(16n^2 + 4n^2 + 4)
            var sum = BigInteger.One +
                16 * ProjectEulerHelper.PyramidalNumber(limit) +
                 4 * ProjectEulerHelper.TriangularNumber(limit) +
                 4 * limit;


            return sum;


        }
    }
}
