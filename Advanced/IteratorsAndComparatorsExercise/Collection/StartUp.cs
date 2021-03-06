﻿namespace Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = null;
            string command = null;

            while ((command = Console.ReadLine()) != "END")
            {
                var action = command.Split();

                switch (action[0])
                {
                    case "Create":
                        iterator = new ListyIterator<string>(action.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(iterator.PrintAll());
                        break;
                }
            }
        }
    }
}
