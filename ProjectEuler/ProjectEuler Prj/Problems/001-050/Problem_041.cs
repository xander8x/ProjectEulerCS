using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Champernowne's Constant",
        @"
We shall say that an -digit number is pandigital if it makes use of all the digits  to  exactly once. For example, 2143 is a 4-digit pandigital and is also prime.

What is the largest -digit pandigital prime that exists?",
        true,
        41)
    ]
    [ProblemSolutionInfo(73, 7652413)]
    public class Problem041 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.GetAllPermutations(1234567)
                                       .Where(x => x.IsEven == false)
                                       .Where(x => x.IsPrime())
                                       .OrderByDescending(x => x)
                                       .FirstOrDefault();
        }
    }
}