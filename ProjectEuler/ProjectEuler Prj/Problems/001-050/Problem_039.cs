using ProjectEuler.Helper;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Integer Right Triangles",
        @"If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20, 48,52}, {24,25,51}, {30,40,50} 

For which value of p <= 1000 , is the number of solutions maximised?",
        true,
        39)
    ]
    [ProblemSolutionInfo(56, 840)]
    public class Problem039 : ProblemBase
    {
        protected override object InternalExecute()
        {
            int limit = 1000;
            int max_p = 0;
            int max_count = 0;

            for (int p = 1; p < limit; p++)
            {
                int count = 0;
                for (int a = 0; a < p /2; a++)
                {
                    for (int b = 0; b < p / 2; b++)
                    {
                        int c = p - a - b;
                        int aa = a * a;
                        int bb = b * b;
                        int cc = c * c;
                        if(aa + bb == cc)
                        {
                            count++;
                        }
                    }
                }
                if(count > max_count)
                {
                    max_count = count;
                    max_p = p;
                }
            }
            return max_p;
        }
    }
}