using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoup = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string query = Console.ReadLine();
            Predicate<int> setQuery = query == "even"
                ? new Predicate<int>(x => x % 2 == 0)
                : new Predicate<int>(x => x % 2 != 0);
            var result = new List<int>();

            for (int i = scoup[0]; i <= scoup[1]; i++)
            {
                if(setQuery(i))
                    result.Add(i);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
