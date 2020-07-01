namespace GenericSwapMethodInteger
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var ints = new GenericClass<int>();

            for (int i = 0; i < n; i++)
            {
                ints.Add(int.Parse(Console.ReadLine()));
            }

            var swap = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            ints.Swap(swap[0], swap[1]);

            Console.WriteLine(ints);
        }
    }
}
