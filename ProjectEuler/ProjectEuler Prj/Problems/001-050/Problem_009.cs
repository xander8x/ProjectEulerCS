using System.Numerics;
using ProjectEuler.Helper;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Special Pythagorean triplet",
@"A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.",
        true, 9)
]
    [ProblemSolutionInfo(12, 31875000)]
    public class Problem009 : ProblemBase
    {
        protected override object InternalExecute()
        {
            BigInteger result = new BigInteger();


            for (var c = 0; c < 1000; c++)
            {
                for (var b = 0; b < c; b++)
                {
                    for (var a = 0; a < b; a++)
                    {
                        if (a * a + b * b == c * c && a + b + c == 1000)
                        {
                            result = a * b * c;
                            return result;
                        }
                    }
                }
            }

            return result;
        }
    }
}
