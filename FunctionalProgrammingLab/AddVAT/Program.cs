using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, Result));
        }

        static string[] Result =>
            Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => $"{x += x * 0.20:f2}")
                .ToArray();
    }
}
