using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var row = InputArr();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int step = 0;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                result += matrix[i, step];
                step++;
            }

            Console.WriteLine(result);
        }

        private static int[] InputArr()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
