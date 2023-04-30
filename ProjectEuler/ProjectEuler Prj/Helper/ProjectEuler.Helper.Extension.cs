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
        public static double Sqrt(this BigInteger value)
        {
            double retValue = 0.0F;

            retValue = Math.Pow(Math.E, BigInteger.Log(value) / 2.0F);

            return retValue;
        }
    }
}
