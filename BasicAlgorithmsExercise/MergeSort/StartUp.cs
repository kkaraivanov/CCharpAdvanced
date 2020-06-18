namespace MergeSort
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var testList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Mergesort<int>.Sort(testList);

            Console.WriteLine(string.Join(" ", testList));
        }
    }
}
