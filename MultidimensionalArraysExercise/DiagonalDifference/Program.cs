using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = Matrix(n, n);

            int diagonalLeft = 0;
            int diagonalRight = 0;

            for (int i = 0; i < n; i++)
            {
                diagonalLeft += matrix[i, i];
                diagonalRight += matrix[i, n - i - 1];
            }

            Console.WriteLine(Math.Abs(diagonalLeft - diagonalRight));
        }

        static int[,] Matrix(int row, int col)
        {
            var matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                var readRow = Input(' ');
                for (int j = 0; j < col; j++)
                {
                    matrix[i,j] = readRow[j];
                }
            }

            return matrix;
        }
        static int[] Input(params char[] separator)
        {
            return Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
