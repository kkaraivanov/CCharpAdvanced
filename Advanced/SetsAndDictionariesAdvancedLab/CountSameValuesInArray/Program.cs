using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = consoleReadline;
            var dictionary = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dictionary.ContainsKey(input[i]))
                {
                    dictionary[input[i]] = 0;
                }

                dictionary[input[i]]++;
            }

            foreach (var (currentKey, curentValue) in dictionary)
            {
                Console.WriteLine($"{currentKey} - {curentValue} times");
            }
        }

        static double[] consoleReadline
        => Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToArray();
    }
}
