using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, string> filter = x => $"Sir {x}";
            Action<string> print = x 
                => Console.WriteLine(string.Join(Environment.NewLine
                    , x
                        .Split()
                        .Select(filter)
                        .ToArray()));

            print(input);
        }
    }
}
