using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var bottleWater = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            var amount = 0;

            while (true)
            {
                if (cupsCapacity.Count == 0 || bottleWater.Count == 0)
                    break;

                var cup = cupsCapacity.Dequeue();
                var bottle = bottleWater.Pop();

                amount += bottle - cup;
            }

            if(bottleWater.Count > 0)
                Console.WriteLine($"Bottles: {bottleWater.Count}");
            else if(cupsCapacity.Count > 0)
                Console.WriteLine($"Cups: {cupsCapacity.Count}");

            Console.WriteLine($"Wasted litters of water: {amount}");
        }
    }
}
