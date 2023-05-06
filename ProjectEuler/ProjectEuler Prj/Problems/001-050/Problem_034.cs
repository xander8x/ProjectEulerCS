using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Digit factorials",
        @"145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

Find the sum of all numbers which are equal to the sum of the factorial of their digits.

Note: as 1! = 1 and 2! = 2 are not sums they are not included.",
        true,
        34)
    ]
    [ProblemSolutionInfo(520, 40730)]
    public class Problem034 : ProblemBase
    {
        protected override object InternalExecute()
        {
            /// {0!,1!,2!,3!,4!,5!,6!,7!,8!,9!}
            long[] factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

            long allsum = 0;

            // 7*9!
            long limit = 2540160;
            for (long i = 10; i < limit; i++)
            {
                long sum = 0;

                long n = i;
                while (n > 0)
                {
                    var d = n % 10;
                    sum += factorials[d];
                    n /= 10;                   
                }

                if ( i == sum )
                {
                    allsum += i;
                }
            }

            return allsum;
        }
    }
}
