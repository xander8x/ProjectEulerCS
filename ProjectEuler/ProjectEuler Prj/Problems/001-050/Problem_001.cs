﻿using ProjectEuler.Helper;
using System.Linq;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Multiples of 3 and 5",
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9." +
            "\r\nThe sum of these multiples is 23." +
            "\r\nFind the sum of all the multiples of 3 or 5 below 1000.",
            true,
            1)
    ]
    [ProblemSolutionInfo(3, 233168)]
    public class Problem_0001 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return Enumerable.Range(0, 1000).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
        }
    }
}