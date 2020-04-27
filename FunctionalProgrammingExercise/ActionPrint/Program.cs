using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Action<string> print = x 
                => Console.WriteLine(string.Join(Environment.NewLine, x.Split().ToArray()));

            print(input);
        }
    }
}
