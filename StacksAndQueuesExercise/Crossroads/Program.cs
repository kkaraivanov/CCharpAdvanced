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
                    var temp = new Queue<string>();
                    
                    while (green > 0 && cars.Count != 0)
                    {
                        string car = cars.Dequeue();
                        temp.Enqueue(car);
                        green -= car.Length;
                        
                        if(green < 0)
                            break;

                        temp.Dequeue();
                        passes++;
                    }
                    while (window >= 0 && temp.Count != 0)
                    {
                        string car = temp.Dequeue();
                        window += green;
                        if (window < 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[car.Length + window]}.");
                            return;
                        }

                        window -= car.Length;
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
