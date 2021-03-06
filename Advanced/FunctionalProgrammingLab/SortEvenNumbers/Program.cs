﻿using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Result));
        }

        private static int[] Result
            => Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();
    }
}
