namespace PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var queu = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var result = queu
                .Where(x => x % 2 == 0);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
