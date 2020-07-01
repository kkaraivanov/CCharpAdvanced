using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var deviders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (Devider(i, deviders))
                    numbers.Add(i);
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static Func<int, int[], bool> Devider = (n, arr) =>
        {
            foreach (int num in arr)
            {
                if (n % num != 0)
                {
                    return false;
                }
            }

            return true;
        };
    }
}
