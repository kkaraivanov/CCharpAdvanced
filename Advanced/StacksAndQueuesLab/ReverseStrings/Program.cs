namespace ReverseStrings
{
    using System;
    using System.Collections;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var output = new Stack();

            foreach (var c in input)
            {
                output.Push(c);
            }

            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();
        }
    }
}
