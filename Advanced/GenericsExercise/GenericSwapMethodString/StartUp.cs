namespace GenericSwapMethodString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strings = new GenericClass<string>();

            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }

            var swap = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            strings.Swap(swap[0], swap[1]);

            Console.WriteLine(strings);
        }
    }
}
