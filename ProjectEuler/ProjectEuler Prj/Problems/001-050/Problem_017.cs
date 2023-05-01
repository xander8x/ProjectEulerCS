using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Lattice paths",
        @"If the numbers 1 to 5 are written out in words: one two three four five then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words how many letters would be used?
NOTE: Do not count spaces or hyphens. For example 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. 
The use of 'and' when writing out numbers is in compliance with British usage.",
        true,
        17)
    ]
    [ProblemSolutionInfo(9, 21124)]
    public class Problem017 : ProblemBase
    {
        protected override object InternalExecute()
        {
            var str = Enumerable.Repeat(string.Empty, 1001).ToList();

            str[0] = "";
            str[1] = "one";
            str[2] = "two";
            str[3] = "three";
            str[4] = "four";
            str[5] = "five";
            str[6] = "six";
            str[7] = "seven";
            str[8] = "eight";
            str[9] = "nine";
            str[10] = "ten";
            str[11] = "eleven";
            str[12] = "twelve";
            str[13] = "thirteen";
            str[14] = "fourteen";
            str[15] = "fifteen";
            str[16] = "sixteen";
            str[17] = "seventeen";
            str[18] = "eighteen";
            str[19] = "nineteen";
            str[20] = "twenty";
            str[30] = "thirty";
            str[40] = "forty";
            str[50] = "fifty";
            str[60] = "sixty";
            str[70] = "seventy";
            str[80] = "eighty";
            str[90] = "ninety";
            str[1000] = "onethousand";



            for (int n = 21; n < 100; n += 10)
            {
                int d = ((int)n / 10) * 10;
                for (var k = 0; k < 9; k++)
                {
                    str[n + k] = str[d] + str[k + 1];
                }
            }

            for (int n = 100; n < 1000; n += 100)
            {
                int u = (int)n / 100;
                int h = ((int)n / 100) * 100;
                for (var k = 0; k < 100; k++)
                {
                    if ((n + k) % 100 == 0)
                        str[n + k] = str[u] + "hundred";
                    else
                        str[n + k] = str[u] + "hundredAnd" + str[k];
                }
            }


            return str.Select(x => x.Trim()).Select(x => x.Length).Sum();


        }
    }
}