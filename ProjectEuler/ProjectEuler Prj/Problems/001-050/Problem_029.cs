﻿using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Distinct powers",
@"Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:

    2^2=4,  2^3=8,   2^4=16,  2^5=32
    3^2=9,  3^3=27,  3^4=81,  3^5=243
    4^2=16, 4^3=64,  4^4=256, 4^5=1024
    5^2=25, 5^3=125, 5^4=625, 5^5=3125
If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:

    4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125

How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?",
        true,
        29)
    ]
    [ProblemSolutionInfo(25, 9183)]
    class Problem029 : ProblemBase
    {

        protected override object InternalExecute()
        {
            var items = Enumerable.Range(2, 99).ToList();

            return items.SelectMany(x => items.Select(y => BigInteger.Pow(x, y))).Distinct().Count();
        }
    }
}
