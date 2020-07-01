using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool CheckUper(string x) => x[0] == x.ToUpper()[0];
            var result = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(CheckUper)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
