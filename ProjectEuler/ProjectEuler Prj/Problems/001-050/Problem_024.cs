using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Lexicographic permutations",
@"A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
The lexicographic permutations of 0, 1 and 2 are:
    012   021   102   120   201   210
What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9 ?",
            true,
            24)
    ]
    [ProblemSolutionInfo(15, 2783915460)]
    public class Problem024 : ProblemBase
    {

        int[] values = Enumerable.Range(0, 10).ToArray();
        protected override object InternalExecute()
        {
            int count = 1;
            int numPerm = 1000000;
            while (count < numPerm)
            {
                _nextPermutation();
                count++;
            }

            return string.Join(String.Empty, values);
        }

        private void _swap(int a, int b)
        {
            int temp = values[a];
            values[a] = values[b];
            values[b] = temp;
        }


        private void _nextPermutation()
        {
            int N = values.Length;
            int i = N - 1;
            while (values[i - 1] >= values[i])
            {
                i = i - 1;

            }
            int j = N;
            while (values[j - 1] <= values[i - 1])
            {
                j = j - 1;
            }
            _swap(i - 1, j - 1);

            i++;
            j = N;
            while (i < j)
            {
                _swap(i - 1, j - 1);
                i++;
                j--;
            }

        }

    }
}
