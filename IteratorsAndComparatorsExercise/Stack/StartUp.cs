namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new SampleStack<int>();
            string command = null;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    var elements = command
                        .Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();
                    stack.Push(elements);
                }

                if (command.Contains("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                    
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
