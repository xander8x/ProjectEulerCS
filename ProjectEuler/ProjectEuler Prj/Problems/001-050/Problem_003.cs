using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Largest prime factor",
        "The prime factors of 13195 are 5, 7, 13 and 29." +
        "\r\n \r\nWhat is the largest prime factor of the number 600851475143 ?",
        true,
        3)
    ]
    [ProblemSolutionInfo(4, 6857)]
    public class Problem003 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.LargestPrimeFactor(600851475143);
        }
    }
}
