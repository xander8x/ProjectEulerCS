using ProjectEuler.Helper;
using System;
using System.Text;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Champernowne's Constant",
        @"An irrational decimal fraction is created by concatenating the positive integers:
0.123456789101112131415161718192021....

It can be seen that the 12th digit of the fractional part is 1.

If dn represents the nth digit of the fractional part, find the value of the following expression.
    d_1 x d_10 x d_100 x d_1000 x d_10000 x d_100000 x d_1000000
",
        true,
        40)
    ]
    [ProblemSolutionInfo(40, 210)]
    public class Problem040 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int limit = 1000000;
            StringBuilder sb = new StringBuilder();
            int n = 1;
            while(sb.Length < limit)
            {
                sb.Append($"{n++}");
            }

            string s = sb.ToString();
            int prod = 1;
            for (int i = 1; i <= limit; i *= 10)
            {
                char c = s[i - 1];
                int c_value = Int32.Parse(c.ToString());
                prod *= c_value;
            }

            return prod;
        }
    }
}