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
        /// Returns factorial of input value.
        /// </summary>
        /// <param name="value">Value whose factorial is computed.</param>
        /// <returns>Factorial of <paramref name="value"/>.</returns>
        public static BigInteger GetFactorial(BigInteger value)
        {
            BigInteger result = BigInteger.One;
            if (value > 1)
            {
                result = value * GetFactorial(value - 1);
            }

            return result;

        }
    }
}
