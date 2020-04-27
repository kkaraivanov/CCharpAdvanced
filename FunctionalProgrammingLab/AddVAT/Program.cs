using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double vat = 0.20;
            var numbers = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            string parseVat(double x) => $"{x += (x * vat):f2}";
            var result = numbers.Select(parseVat).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
