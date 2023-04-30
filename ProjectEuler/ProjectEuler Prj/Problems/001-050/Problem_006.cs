using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Sum square difference",
"The sum of the squares of the first ten natural numbers is," +
"\r\n\t\t1² + 2² + ... + 10² = 385"+
"\r\nThe square of the sum of the first ten natural numbers is,"+
"\r\n\t\t(1 + 2 + ... + 10)² = 552 = 3025" +
"\r\nHence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640." +
"\r\nFind the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.",
        true,
        6)]
    [ProblemSolutionInfo(0, 25164150)]
    public class Problem006 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.SquareOfSumOfNthNumbers(100) - ProjectEulerHelper.SumOfSquareOfNthNumber(100);
        }
    }
}