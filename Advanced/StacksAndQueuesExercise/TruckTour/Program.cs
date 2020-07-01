using System;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main()
        {
            var petrolPumpsCount = int.Parse(Console.ReadLine());
            var points = 0;
            var temp = 0;

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                var pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var fuel = pump[0];
                var distance = pump[1];

                temp += fuel;
                if (temp >= distance)
                    temp -= distance;
                else
                {
                    points= i + 1;
                    temp = 0;
                }
            }

            Console.WriteLine(points);
        }
    }
}
