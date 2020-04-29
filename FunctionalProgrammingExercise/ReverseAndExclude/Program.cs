using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> divide = new Predicate<int>(x => x % divider != 0);
            var result = new List<int>();
            
            foreach (var n in inputArr)
            {
                if(divide(n))
                    result.Add(n);
            }

            result.Reverse();
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
