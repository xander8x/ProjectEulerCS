using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Digit cancelling fractions",
@"The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

If the product of these four fractions is given in its lowest common terms, find the value of the denominator.",
        true,
        33)
    ]
    [ProblemSolutionInfo(5, 100)]
    public class Problem_033 : ProblemBase
    {
        protected override object InternalExecute()
        {
            /// 
            /// Solve these four equation:
            /// 1)  (10n + c)/(10m + c) = n/m
            /// 2)  (10c + n)/(10c + m) = n/m
            /// 3)  (10c + n)/(10m + c) = n/m
            /// 4)  (10n + c)/(10c + m) = n/m
            /// 
            /// The solution of the first two equation is a trivial solution that is n = m.
            /// The third one not have any solution.
            /// The last one have these solutions:
            /// c = 6 ; n = 1 ; m = 4
            /// c = 6 ; n = 2 ; m = 5
            /// c = 9 ; n = 1 ; m = 5
            /// c = 6 ; n = 1 ; m = 4
            /// So we have these fractions:
            /// a. 16/64 => 1/4
            /// b. 26/65 => 2/5
            /// c. 19/95 => 1/5
            /// d. 49/98 => 4/8
            /// 
            /// Define:
            /// num = (1*2*1*4)
            /// den = (4*5*5*8)
            /// The solution of this problem is:
            /// ans = den / GCD(num,den
            /// 


            BigInteger numerator = 1 * 2 * 1 * 4;
            BigInteger denominator = 4 * 5 * 5 * 8;


            return denominator / ProjectEulerHelper.GreatestCommonDivisor(numerator, denominator);
        }
    }
}
