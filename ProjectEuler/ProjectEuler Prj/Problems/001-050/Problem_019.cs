using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Helper;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Counting Sundays",
        @"You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?",
        true,
        19)]
    [ProblemSolutionInfo(9, 171)]
    public class Problem019 : ProblemBase
    {
        protected override object InternalExecute()
        {
            var cont = BigInteger.Zero;
            var test = Enumerable.Range(1900, 101).Where(x => x >= 1901 && x < 2001)
                .SelectMany(year => Enumerable.Range(1, 12)
                                              .Select(month => new DateTime(year, month, 1))
                                              .Where(x => x.DayOfWeek == DayOfWeek.Sunday))
                .Select((x, i) => i).Aggregate(BigInteger.Zero, (x, y) => cont++);


            return cont;

        }
    }
}
