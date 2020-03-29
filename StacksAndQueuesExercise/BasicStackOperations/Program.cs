namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < command[0]; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < command[1]; i++)
            {
                stack.Pop();
            }

            int min = int.MaxValue;

            if(stack.Count == 0)
                Console.WriteLine("0");
            else if (stack.Contains(command[2]))
                Console.WriteLine("true");
            else
            {
                while (stack.Any())
                {
                    int current = stack.Pop();
                    if (current < min)
                        min = current;
                }

                Console.WriteLine(min);
            }
        }
    }
}
