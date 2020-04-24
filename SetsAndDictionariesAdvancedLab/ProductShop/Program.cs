using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var markets = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var commands = consoleRead(',', ' ');
                if (commands.Contains("Revision"))
                {
                    break;
                }

                
                string market = commands[0];
                string product = commands[1];
                double price = double.Parse(commands[2]);
                
                if (!markets.ContainsKey(market))
                {
                    markets[market] = new Dictionary<string, double>();
                    if (!markets[market].ContainsKey(product))
                    {
                        markets[market][product] = 0;
                    }
                }

                markets[market][product] = price;
            }

            foreach (var ( market, products) in markets
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{market}->");
                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }

        static string[] consoleRead(params char[] separator)
            => Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
    }
}
