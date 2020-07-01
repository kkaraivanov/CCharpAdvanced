using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var symbols = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSypbol = input[i];
                if (!symbols.ContainsKey(currentSypbol))
                    symbols[currentSypbol] = 0;

                symbols[currentSypbol]++;
            }

            foreach (var (symbol, count) in symbols.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
