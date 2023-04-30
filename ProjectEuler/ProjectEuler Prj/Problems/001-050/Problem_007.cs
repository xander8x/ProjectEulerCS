using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("10001st prime",
@"By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
What is the 10001st prime number?", false, 7)]

    [ProblemSolutionInfo(19, 104743)]
    public class Problem007 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.GetNthPrime(10000);
        }
    }
}
