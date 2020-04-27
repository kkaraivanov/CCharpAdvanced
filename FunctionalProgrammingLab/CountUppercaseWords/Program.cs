using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(
                Environment.NewLine
                , Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => char.IsUpper(x[0]))
                    .ToArray()));
        }
    }
}
