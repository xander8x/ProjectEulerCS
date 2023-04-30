using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Largest palindrome product",
"A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99." +
"\r\nFind the largest palindrome made from the product of two 3-digit numbers.",
        true,
        4)]
    [ProblemSolutionInfo(15, 906609)]
    class Problem004 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.Range(900, 99)
                .SelectMany(b => ProjectEulerHelper.Range(900, 99).Select(a => (a * b)))
                .Where(x => x.IsPalindrome())
                .Max();
        }
    }
}
