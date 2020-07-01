using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputArr();
            var rows = input[0];
            var cols = input[1];
            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var row = InputArr();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            var result = 0;
            foreach (var element in matrix)
            {
                result += element;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
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
