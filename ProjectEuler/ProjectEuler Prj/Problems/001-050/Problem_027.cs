using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Quadratic primes",
        @"Euler discovered the remarkable quadratic formula:

n2+n+41
It turns out that the formula will produce 40 primes for the consecutive integer values 0≤n≤39. However, when n=40,402+40+41=40(40+1)+41 is divisible by 41, and certainly when n=41,412+41+41 is clearly divisible by 41.

The incredible formula n2−79n+1601 was discovered, which produces 80 primes for the consecutive values 0≤n≤79. The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

n2+an+b, where |a|<1000 and |b|≤1000

where |n| is the modulus/absolute value of n
e.g. |11|=11 and |−4|=4
Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0.",
        true,
        27)
    ]
    [ProblemSolutionInfo(222, -59231)]
    public class Problem027 : ProblemBase
    {
        int[] primes = {
              2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,
             43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,
            103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167,
            173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239,
            241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313,
            317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397,
            401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467,
            479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569,
            571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643,
            647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733,
            739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823,
            827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911,
            919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997};

        private int _countPrimes(int a, int b)
        {
            for (int n = 0; ; n++)
            {
                var test = n * n + a * n + b;
                if (ProjectEulerHelper.IsPrime(test) == false) 
                    return n;
            }
        }

        protected override object InternalExecute()
        {
            BigInteger maxValueC = BigInteger.Zero;
            BigInteger maxValueAB = BigInteger.Zero;

            for (int a = -999; a <= 1001; a += 2)
            {
                for (int i = 0; i < primes.Length; i++)
                {
                    var currentB = primes[i];
                    var currentC = _countPrimes(a - (i == 0 ? 1 : 0), currentB);

                    if (currentC > maxValueC)
                    {
                        maxValueC = currentC; ;
                        maxValueAB = currentB * a;
                    }
                }
            }

            return maxValueAB;
        }
    }
}