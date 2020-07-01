using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = input => { Console.WriteLine($"{input}"); };

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printName);
        }
    }
}
