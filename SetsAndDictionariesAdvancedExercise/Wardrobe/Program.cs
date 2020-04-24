using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                var input = Input(" -> ");
                string color = input[0];
                var clothe = input[1].Split(',');

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, int>();
                }

                foreach (var item in clothe)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color][item] = 0;
                    }

                    clothes[color][item]++;
                }

            }

            var search = Input(" ");
            var searchColor = search[0];
            var searchClothe = search[1];
            ;
            foreach (var (color, clothe) in clothes)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (key, value) in clothe)
                {
                    Console.WriteLine(
                        key == searchClothe && color == searchColor
                            ? $"* {key} - {value} (found!)" 
                            : $"* {key} - {value}");
                }
            }
        }

        static string[] Input(params string[] separator)
            => Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
    }
}
