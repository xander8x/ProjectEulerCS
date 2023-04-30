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
        /// <summary>
        /// Returns the n-th triangular number.
        /// </summary>
        /// <seealso cref="https://en.wikipedia.org/wiki/Triangular_number"/>
        public static Func<BigInteger, BigInteger> TriangularNumber = (n) => (n * (n + 1)) / 2;

        /// <summary>
        /// Returns the n-th pyramidal number.
        /// </summary>
        /// <seealso cref="https://en.wikipedia.org/wiki/Square_pyramidal_number"/>
        public static Func<BigInteger, BigInteger> PyramidalNumber = (n) => (n * (n + 1) * (2 * n + 1)) / (6);

        /// <summary>
        /// Returns the n-th tetrahedral number.
        /// </summary>
        /// <seealso cref="https://en.wikipedia.org/wiki/Tetrahedral_number"/>
        public static Func<BigInteger, BigInteger> TetrahedralNumber = (n) => (n * (n + 1) * (n + 2)) / 6;

        /// <summary>
        /// Returns sum of square of the first n natural numbers.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger SumOfSquareOfNthNumber(BigInteger n)
        {
            return PyramidalNumber(n);
        }

        /// <summary>
        /// Returns the square of the sum of the first n natural numbers.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger SquareOfSumOfNthNumbers(BigInteger n)
        {
            return BigInteger.Pow(TriangularNumber(n), 2);
        }
    }
}
