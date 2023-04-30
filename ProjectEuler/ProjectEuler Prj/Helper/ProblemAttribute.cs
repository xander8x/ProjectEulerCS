using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler_Prj.Helper
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class ProblemAttributes : System.Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsSolved { get; }
        public int ProblemNumber { get; }


        public ProblemAttributes(string name, string description, bool isSolved, int problemNumber)
        {
            Name = name;
            Description = description;
            IsSolved = isSolved;
            ProblemNumber = problemNumber;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class ProblemSolutionInfo : System.Attribute
    {
        public long ElapsedTime { get; }
        public object Solution { get; }
        public ProblemSolutionInfo(long elapsedTime, object solution)
        {
            ElapsedTime = elapsedTime;
            Solution = solution;
        }
    }
}
