using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numLines = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ferstElements = new HashSet<int>();
            var secondElements = new HashSet<int>();

            for (int i = 0; i < numLines[0] + numLines[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i < numLines[0])
                {
                    ferstElements.Add(num);
                }
                else
                {
                    secondElements.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ",ferstElements
                .Where(x => secondElements.Contains(x))));
        }
    }
}
