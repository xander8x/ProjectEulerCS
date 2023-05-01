using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Helper;

namespace ProjectEuler.Problems
{
    [ProblemAttributes("Maximum path sum I",
        @"TBy starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
        [...]
That is, 3 + 7 + 4 + 9 = 23.
Find the maximum total from top to bottom of the triangle below:
        [...]",
        true,
        18)]
    [ProblemSolutionInfo(0, 1074)]
    public class Problem018 : ProblemBase
    {
        private int[,] _triangle = new int[15, 15];
        public Problem018()
        {
            var supportPath = Path.Combine(Directory.GetCurrentDirectory(), @"Problems\001-050\Support");

            var path = Path.Combine(supportPath, "Pb18.txt");

            using (var file = new StreamReader(path))
            {
                string line = string.Empty;
                int j = 0;
                while ((line = file.ReadLine()) != null)
                {
                    var pieces = line.Split(' ');

                    int i = 0;
                    foreach (var item in pieces)
                    {
                        _triangle[j, i++] = int.Parse(item);
                    }
                    j++;
                }
            }


        }

        protected override object InternalExecute()
        {
            for (int r = 14 - 1; r >= 0; r--)
            {
                for (int c = 0; c <= r; c++)
                {
                    var a = _triangle[r, c];
                    var x = _triangle[r + 1, c];
                    var y = _triangle[r + 1, c + 1];

                    _triangle[r, c] = a + Math.Max(x, y);
                }
            }
            return _triangle[0, 0];

        }
    }
}
