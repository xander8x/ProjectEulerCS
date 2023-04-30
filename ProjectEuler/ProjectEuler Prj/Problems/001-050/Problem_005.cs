using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Smallest multiple", 
        "\t2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder. " +

"\r\n\r\n\tWhat is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?",
        true,
        5)]
    [ProblemSolutionInfo(11, 232792560)]
    public class Problem005 : ProblemBase
    {
        protected override object InternalExecute()
        {
            BigInteger result = BigInteger.One;

            return ProjectEulerHelper.GetPrimes(20)
                    .Select(x =>
                    {
                        var exp = BigInteger.Log(20) / BigInteger.Log(x);
                        return BigInteger.Pow(x, (int)exp);
                    })
                    .Aggregate(BigInteger.One, (x, y) => (BigInteger)x * (BigInteger)y);
        }


    }
}
