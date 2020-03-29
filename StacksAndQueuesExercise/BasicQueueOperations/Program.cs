using System;

namespace BasicQueueOperations
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
            var queue = new Queue<int>();

            for (int i = 0; i < command[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < command[1]; i++)
            {
                queue.Dequeue();
            }

            int min = int.MaxValue;

            if (queue.Count == 0)
                Console.WriteLine("0");
            else if (queue.Contains(command[2]))
                Console.WriteLine("true");
            else
            {
                while (queue.Any())
                {
                    int current = queue.Dequeue();
                    if (current < min)
                        min = current;
                }

                Console.WriteLine(min);
            }
        }
    }
}
