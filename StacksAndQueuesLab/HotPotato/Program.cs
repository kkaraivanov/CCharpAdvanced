using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Queue<string>(Console.ReadLine().Split());
            var count = int.Parse(Console.ReadLine());
            var counter = 1;

            while (input.Count > 1)
            {
                var name = input.Dequeue();
                if (counter == count)
                {
                    Console.WriteLine($"Removed {name}");
                    counter = 0;
                }
                else
                {
                    input.Enqueue(name);
                }

                counter++;
            }

            Console.WriteLine($"Last is {input.Dequeue()}");
        }
    }
}
