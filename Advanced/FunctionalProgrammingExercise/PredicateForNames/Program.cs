using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Func<string[], int, string[]> filterName = (str, x) 
                => str.Where(n => n.Length <= x).ToArray();
            names = filterName(names, n);

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
