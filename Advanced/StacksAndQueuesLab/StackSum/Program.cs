namespace StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var temp = new Stack<int>(input);
            
            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "end")
                {
                    break;
                }

                if (command.Contains("add"))
                {
                    var collect = command
                        .Split(" ", 2)[1]
                        .Split().Select(int.Parse)
                        .ToArray();
                    foreach (var item in collect)
                    {
                        temp.Push(item);
                    }
                }

                if (command.Contains("remove"))
                {
                    int.TryParse(command.Split()[1], out int count);
                    if(count > temp.Count)
                        continue;
                    for (int i = 0; i < count; i++)
                    {
                        temp.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {temp.Sum()}");
        }
    }
}
