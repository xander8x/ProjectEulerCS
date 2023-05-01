﻿using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Longest Collatz sequence",
    @"The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.",
true,
    14)
]
    [ProblemSolutionInfo(500, 837799)]
    public class Problem014 : ProblemBase
    {
        protected override object InternalExecute()
        {
            const int limit = 1000000;
            long lenSequence = 0;
            long startingNumber = 0;

            int[] cache = Enumerable.Repeat(-1, limit + 1).ToArray();

            cache[1] = 1;

            for (int i = 2; i < limit; i++)
            {
                var sequence = ProjectEulerHelper.CollatzNumber(i);
                var iter = 0;

                while( sequence != 1 && sequence >= i )
                {
                    sequence = ProjectEulerHelper.CollatzNumber(sequence);
                    iter++;
                }

                cache[i] = iter + cache[(long)sequence];

                if( cache[i] > lenSequence )
                {
                    startingNumber = i;
                    lenSequence = cache[i];
                }
            }


            return startingNumber;

        }
    }
}
