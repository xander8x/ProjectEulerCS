using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Double-base Palindromes",
        @"The decimal number, 585 = 1001001001  (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base  and base .

(Please note that the palindromic number, in either base, may not include leading zeros.)",
        true,
        36)
    ]
    [ProblemSolutionInfo(148, 872187)]
    public class Problem036 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int limit = 1000000;

            return ProjectEulerHelper.Range(1, limit)
                             .Where(x => x.IsPalindrome())
                             .Where(x => x.ConvertToBase(2).IsPalindrome())
                             .Aggregate(BigInteger.Zero, BigInteger.Add);
        }
    }
}