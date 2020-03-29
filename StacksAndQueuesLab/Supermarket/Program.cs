using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var queu = new Queue<string>();
            var input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (queu.Any())
                    {
                        Console.WriteLine(queu.Dequeue());
                    }
                }
                else
                {
                    queu.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queu.Count} people remaining.");
        }
    }
}
