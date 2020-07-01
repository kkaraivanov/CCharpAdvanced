namespace BinarySearch
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(arr.IndexOf(key));
        }
    }
}
