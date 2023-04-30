using ProjectEuler.Helper;
using ProjectEuler.Problems;
using System;
using System.Linq;
using System.Reflection;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .Where(t => t.GetCustomAttributes(typeof(ProblemAttributes), false).Any())
                                .Where(t => ((ProblemAttributes)t.GetCustomAttributes(typeof(ProblemAttributes), false).First()).IsSolved == false);


            foreach (var type in types)
            {
                var a = type.GetCustomAttributes().First();
                var pb = (ProblemBase)Activator.CreateInstance(type);

                pb.Execute();

                ShowResult((ProblemAttributes)a, pb);
            }

            Console.ReadKey();

        }

        private static void ShowResult(ProblemAttributes attribute, ProblemBase pb)
        {
            var defaultColor = Console.ForegroundColor;

            Console.WriteLine("############################################");
            Console.WriteLine("");

            Console.WriteLine("++++++++++++++++++++ PROBLEM DESCRIPTION +++++++++++++++++++++");

            Console.Write($"Problem Number:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\t{attribute.ProblemNumber}");
            Console.ForegroundColor = defaultColor;

            Console.Write($"Problem Title:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\t{attribute.Name}");
            Console.ForegroundColor = defaultColor;

            Console.WriteLine("Description:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{attribute.Description}");

            if (pb.IsCancelled == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+++++++++++++++++++++++ PROBLEM RESULT ++++++++++++++++++++++");
                Console.WriteLine($"Result: \t{pb.Result}");
                Console.WriteLine($"Elapsed Time \t{pb.ElapsedTime}[ms]");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+++++++++++++++++++++++ PROBLEM RESULT ++++++++++++++++++++++");
                Console.WriteLine("Problem has been cancelled due to timeout of two seconds.");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
            Console.ForegroundColor = defaultColor;

            Console.WriteLine("");
            Console.WriteLine("############################################");
        }
    }
}
