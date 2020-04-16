using System;
using System.Linq;

namespace SumMatrixColumns
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

            for (int i = 0; i < cols; i++)
            {
                var result = 0;
                for (int j = 0; j < rows; j++)
                {
                    result += matrix[j, i];
                }

                Console.WriteLine(result);
            }
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
