using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var countPassed = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            var totalPassed = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "green")
                {
                    for (int i = 0; i < countPassed; i++)
                    {
                        if (cars.Any())
                        {
                            totalPassed++;
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                        }
                    }
                }
                else if (input == "end")
                {
                    break;
                }
                else
                    cars.Enqueue(input);
            }

            Console.WriteLine($"{totalPassed} cars passed the crossroads.");
        }
    }
}
