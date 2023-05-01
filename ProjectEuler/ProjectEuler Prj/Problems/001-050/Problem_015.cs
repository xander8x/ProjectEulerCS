using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Lattice paths",
        @"Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.


How many such routes are there through a 20×20 grid?",
        true,
        15)
    ]
    [ProblemSolutionInfo(15, 137846528820)]
    public class Problem015 : ProblemBase
    {
        protected override object InternalExecute()
        {
            return ProjectEulerHelper.GetFactorial(40) / (ProjectEulerHelper.GetFactorial(20) * ProjectEulerHelper.GetFactorial(20));

        }
    }
}