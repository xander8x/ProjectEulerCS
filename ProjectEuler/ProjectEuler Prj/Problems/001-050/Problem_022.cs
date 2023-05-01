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
    [ProblemAttributes("Names scores",
        @"Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?",
        true,
        22)]
    [ProblemSolutionInfo(42, 871198282)]
    public class Problem022 : ProblemBase
    {
        private List<string> names = new List<string>();

        public Problem022()
        {
            var supportPath = Path.Combine(Directory.GetCurrentDirectory(), @"Problems\001-050\Support");

            var path = Path.Combine(supportPath, "Pb22.txt");

            using (var reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                {

                    names.AddRange(line.Split(',').Select(x => { return x.Replace("\"", ""); }));
                }
            }
        }

        protected override object InternalExecute()
        {
            var scores = names.OrderBy(x => x)
                              .Select(x => x.ToCharArray().Sum(y => y - 64))
                              .Select((x, i) => x * (i + 1))
                              .Aggregate(BigInteger.Zero, (a, b) => a + b);


            return scores;
        }
    }
}
