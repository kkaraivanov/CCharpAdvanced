using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLength = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            int passes = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    int green = greenLength;
                    while (green > 0 && cars.Count > 0)
                    {
                        string car = cars.Dequeue();
                        green -= car.Length;

                        if (green < 0)
                        {
                            window += green;
                            if (window < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + window]}.");
                                return;
                            }
                        }
                        passes++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passes} total cars passed the crossroads.");
        }
    }
}