using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //"add", "multiply", "subtract", "print", "end"
            Action<int[]> print = x => Console.WriteLine(string.Join(' ', x));
            Func<int[], string, int[]> inputOperation = (int[] arr, string str) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    var x = str switch
                    {
                        "add" => arr[i] += 1,
                        "subtract" => arr[i] -= 1,
                        "multiply" => arr[i] *= 2,
                    };
                    arr[i] = x;
                }

                return arr;
            };

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                    return;

                if (input == "print")
                {
                    print(number);
                }
                else
                    inputOperation(number, input);
            }
        }
    }
}
