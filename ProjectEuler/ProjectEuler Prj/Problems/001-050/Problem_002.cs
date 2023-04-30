﻿using ProjectEuler.Helper;
using System.Linq;

namespace ProjectEuler.Problems.Pb0001_0050
{
    [ProblemAttributes("Even Fibonacci numbers",
@"Each new term in the Fibonacci sequence is generated by adding the previous two terms.
By starting with 1 and 2, the first 10 terms will be:
    1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
find the sum of the even - valued terms.",
        true,
        2)
    ]
    [ProblemSolutionInfo(10, 4613732)]
    public class Problem_0002 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.GetFibonacciSequenceLimitedOnMaxValue(new System.Numerics.BigInteger(4e6))
                                         .Where(x => x.IsEven)
                                         .Aggregate((a, b) => a + b);
        }
    }
}