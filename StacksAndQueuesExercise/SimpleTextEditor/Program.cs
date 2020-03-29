using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var commands = new Stack<string>();
            string temp = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split();
                int task = int.Parse(command[0]);

                if (task == 1)
                {
                    commands.Push(temp);
                    temp += command[1];
                }

                if (task == 2)
                {
                    int count = int.Parse(command[1]);
                    commands.Push(temp);
                    temp = temp.Substring(0,temp.Length - count);
                }

                if (task == 3)
                {
                    int index = int.Parse(command[1]) - 1;
                    Console.WriteLine(temp[index]);
                }

                if (task == 4)
                {
                    temp = commands.Pop();
                }
            }
        }
    }
}
