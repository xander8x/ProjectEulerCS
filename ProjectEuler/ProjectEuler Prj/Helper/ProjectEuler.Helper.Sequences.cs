using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Helper
{
    public static partial class ProjectEulerHelper
    {
        private static IEnumerable<BigInteger> FibonacciSequence(Func<BigInteger, bool> cancOnValue, Func<BigInteger, bool> cancOnResult)
        {
            BigInteger prev = 0;
            BigInteger next = 1;
            BigInteger sum = 1;
            BigInteger iter = 1;

            bool stop = false;
            for (; !stop;)
            {
                if (cancOnResult != null && cancOnResult(iter))
                {
                    stop = true;
                }
                sum = prev + next;

                if (cancOnValue != null && cancOnValue(sum))
                {
                    stop = true;
                }
                prev = next;
                next = sum;
                iter++;

                yield return sum;
            }
        }

        public static IEnumerable<BigInteger> GetFibonacciSequenceLimitedOnMaxValue(BigInteger limitOn)
        {
            Func<BigInteger, bool> _limit = new Func<BigInteger, bool>((v) => { return v > limitOn; });
            return FibonacciSequence(_limit, null);
        }

        public static IEnumerable<BigInteger> GetFibonacciSequenceLimitedOnValue(Func<BigInteger, bool> limitOn)
        {

            return FibonacciSequence(limitOn, null);
        }

        public static IEnumerable<BigInteger> GetFibonacciSequenceLimitedOnMaxSize(BigInteger limitOn)
        {
            Func<BigInteger, bool> _limit = new Func<BigInteger, bool>((v) => { return v > limitOn; });
            return FibonacciSequence(null, _limit);
        }
    }
}
