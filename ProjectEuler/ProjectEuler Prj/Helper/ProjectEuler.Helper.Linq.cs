using System;
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
        /// Generates a sequence of BigInteger numbers within a specified range.
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="count">The number of sequential integers to generate.</param>
        /// <returns>An IEnumerable<BigInteger> in C# that contains a range of sequential BigInteger numbers.</returns>
        public static IEnumerable<BigInteger> Range(BigInteger start, BigInteger count)
        {
            return new BigInteger[(int)count].Select((b, i) => (BigInteger)i + start);
        }

        /// <summary>
        /// Generates a sequence of BigInteger numbers within a specified range using a step.
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="end">The value of the first integer in the sequence.</param>
        /// <param name="step">The step value between two consecutives values.</param>
        /// <returns>An IEnumerable<BigInteger> in C# that contains a range of sequential BigInteger numbers.</returns>
        public static IEnumerable<BigInteger> Range(BigInteger start, BigInteger end, BigInteger step)
        {
            return new BigInteger[(int)(end - start + 1)].Select((b, i) => (BigInteger)i + start);
        }
    }
}
