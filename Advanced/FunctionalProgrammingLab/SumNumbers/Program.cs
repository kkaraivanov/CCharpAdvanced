using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(
                arr.Select(x => x).Count() +
                Environment.NewLine +
                arr.Select(x => x).Sum());
        }
    }
}
