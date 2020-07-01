using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var orderQuantity = new Queue<int>(orders);
            int tempSum = 0;

            Console.WriteLine(orderQuantity.Max());
            while (orderQuantity.Count > 0)
            {
                var order = orderQuantity.Peek();
                tempSum += order;
                if (tempSum <= foodQuantity)
                {
                    orderQuantity.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orderQuantity)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
