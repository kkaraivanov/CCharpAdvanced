namespace Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            var lakes = new Lake(arr);

            Console.WriteLine(string.Join(", ", lakes));
        }
    }
}
