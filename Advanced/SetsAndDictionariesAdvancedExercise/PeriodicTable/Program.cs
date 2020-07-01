using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int line = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();

            for (int i = 0; i < line; i++)
            {
                var input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
