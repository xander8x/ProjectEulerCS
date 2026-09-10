using ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Problems._001_050
{
    [ProblemAttributes("Coded Triangle Numbers",
        @"
The nth term of the sequence of triangle numbers is given by, tn = n(n + 1)/2
; so the first ten triangle numbers are:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, …

By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 
. If the word value is a triangle number then we shall call the word a triangle word.
Using words.txt (linked file), a 16K text file containing nearly two-thousand common English words, how many are triangle words?",
        true,
        42)
    ]
    [ProblemSolutionInfo(7, 162)]
    public class Problem042 : ProblemBase
    {
        private List<string> words = new List<string>();

        public Problem042()
        {
            var supportPath = Path.Combine(Directory.GetCurrentDirectory(), @"Problems\001-050\Support");

            var path = Path.Combine(supportPath, "Pb42.txt");

            using (var reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                {

                    words.AddRange(line.Split(',').Select(x => { return x.Replace("\"", ""); }));
                }
            }
        }
        protected override object InternalExecute()
        {
            Func<string, BigInteger> _T = (a) =>
            {
                return a.ToArray().Select(x => (BigInteger)(x - 64)).Aggregate(BigInteger.Add);
            };

            var test = new BigInteger(55).IsTriangular();

            return words.Select(x => _T(x)).Count(x => x.IsTriangular());
        }
    }
}