using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var countLines = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < countLines; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                }
                if (input[0] == 2)
                {
                    if(stack.Count > 0)
                        stack.Pop();
                }
                if (input[0] == 3)
                {
                    if (stack.Count > 0)
                        Console.WriteLine(stack.Max());
                }
                if (input[0] == 4)
                {
                    if (stack.Count > 0)
                        Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ",stack.ToList()));
        }
    }
}
