using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Input;
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var (continent, countries) in continents)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, cities) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }

        private static string[] Input
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
    }
}
