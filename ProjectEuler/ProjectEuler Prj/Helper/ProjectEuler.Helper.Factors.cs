﻿using System;
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
        public static BigInteger LargestPrimeFactor(this BigInteger value)
        {
            BigInteger result = BigInteger.MinusOne;

            while (value % 2 == 0)
            {
                result = 2;
                value >>= 1;
            }

            for (int i = 3; i <= value.Sqrt(); i += 2)
            {
                while (value % i == 0)
                {
                    result = i;
                    value = value / i;
                }
            }

            result = (value > 2) ? value : result;

            return result;
        }
    }
}
