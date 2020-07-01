using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            //bool isValidName(string str, int num)
            //    => str.ToCharArray()
            //        .Select(ch => (int) ch)
            //        .Sum() >= num;

            //string displayIsValidName(string[] arr, int num, Func<string, int, bool> func) 
            //    => arr.FirstOrDefault(str => func(str, num));

            Func<string, int, bool> isValidName = (str, num) 
                => str.ToCharArray()
                .Select(ch => (int)ch).Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string> displayIsValidName = (arr, num, func) 
                => arr
                .FirstOrDefault(str => func(str, num));

            Console.WriteLine(displayIsValidName(names, n, isValidName));
        }
    }
}
