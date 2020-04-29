using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minValue = arr =>
            {
                int min = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                        min = arr[i];
                }

                return min;
            };

            Console.WriteLine($"{minValue(numbers)}");
        }
    }
}
