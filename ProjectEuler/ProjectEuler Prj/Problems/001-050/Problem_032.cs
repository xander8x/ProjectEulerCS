using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Pandigital products",
@"We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.?",
        true,
        32)
    ]
    [ProblemSolutionInfo(52, 45228)]
    public class Problem032 : ProblemBase
    {
        protected override object InternalExecute()
        {
            var list = new List<BigInteger>();

            for (int a = 1; a < 100; a++)
            {
                var begin = (a > 9) ? 123 : 1234;
                var end = 10000 / a + 1;
                for (int b = begin; b < end; b++)
                {
                    var prod = a * b;
                    var combined = ProjectEulerHelper.ConcatNumbers(ProjectEulerHelper.ConcatNumbers(a, b), prod);
                    if (combined >= (int)1e8 && combined <= (int)1e9 && combined.IsPandigital(1))
                    {
                        if (!list.Contains(prod)) list.Add(prod);
                    }
                }
            }
            return list.Aggregate(BigInteger.Zero, (a, b) => a + b);
        }

    }
}
