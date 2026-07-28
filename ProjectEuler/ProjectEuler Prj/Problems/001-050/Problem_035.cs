using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Circular Primes",
        @"The number, 197 , is called a circular prime because all rotations of the digits: 197 , 971, and 719, are themselves prime.

There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79 and 97.

How many circular primes are there below one million?",
        true,
        35)
    ]
    [ProblemSolutionInfo(195, 55)]
    public class Problem035 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int limit = 1000000;

            return ProjectEulerHelper.GetPrimes(limit)
                                     .ToDictionary(x => x, x => x.GetAllCircualRotations())
                                     .Count(x => x.Value.Any(y => y.IsEven && y != 2) == false && x.Value.All(y => y.IsPrime()));
        }
    }
}