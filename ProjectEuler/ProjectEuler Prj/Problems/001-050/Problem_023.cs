using ProjectEuler.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Non-abundant sums",
        @"A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
        For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

        A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant 
        if this sum exceeds n.

        As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
        By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
        However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number 
        that cannot be expressed as the sum of two abundant numbers is less than this limit.

        Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.",
        true,
        23)
    ]
    [ProblemSolutionInfo(516, 4179871)]
    public class Problem023 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int sum = 0;
            const int limit = 28123;            

            BitArray allAbbundant = new BitArray(limit + 1, false);


            var abb = Enumerable.Range(2, limit + 1).Where(x => ProjectEulerHelper.IsAbundant(x)).ToList();

            for (int i = 0; i < abb.Count; i++)
            {              
                for (int j = 0; j < abb.Count; j++)
                {
                    if (abb[i] + abb[j] < limit)
                    {
                        allAbbundant.Set(abb[i] + abb[j], true);
                    }
                    else
                        break;
                }
            }

            for (int n = 0; n < limit; n++)
            {
                sum += !allAbbundant.Get(n) ? n : 0;
            }

            return sum;

        }
    }
}
