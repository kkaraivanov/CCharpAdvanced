using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> comparator = (x, y) =>
                x % 2 == 0 && y % 2 != 0 ? -1 :
                y % 2 == 0 && x % 2 != 0 ? 1 : 
                x.CompareTo(y);
            Comparison<int> comparision = new Comparison<int>(comparator);
            Array.Sort(arr, comparision);

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
