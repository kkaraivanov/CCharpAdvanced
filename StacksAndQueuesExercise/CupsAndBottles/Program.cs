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

                var cup = cupsCapacity.Peek();
                var bottle = bottleWater.Peek();

                if (bottle >= cup)
                {
                    var temp = bottleWater.Pop() - cupsCapacity.Dequeue();
                    amount += temp;
                }
                else
                {
                    var temp = 0;
                    while (cup > 0)
                    {
                        temp = bottleWater.Peek() - cup;
                        cup -= bottleWater.Pop();
                    }

                    amount += temp;
                    cupsCapacity.Dequeue();
                }
            }

            if(bottleWater.Count > 0)
                Console.WriteLine($"Bottles: {string.Join(" ", bottleWater)}");
            else if(cupsCapacity.Count > 0)
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");

            Console.WriteLine($"Wasted litters of water: {amount}");
        }
    }
}
