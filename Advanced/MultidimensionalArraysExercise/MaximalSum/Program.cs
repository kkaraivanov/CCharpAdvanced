using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = IntParce(' ');
            int row = n[0];
            int col = n[1];
            var matrix = Matrix(row, col);
            int bigNum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) -2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var sum = BigMatrixSum(Matrix(matrix, i, j));
                    if (bigNum < sum)
                    {
                        bigNum = sum;
                        row = i;
                        col = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {bigNum}");
            PrintMatrix(Matrix(matrix, row, col));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static int BigMatrixSum(int[,] matrix)
        {
            int result = 0;
            foreach (var element in matrix)
            {
                result += element;
            }

            return result;
        }
        static int[,] Matrix(int row, int col)
        {
            var matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                var readRow = IntParce(' ');
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = readRow[j];
                }
            }

            return matrix;
        }

        static int[,] Matrix(int[,] matrix, int rows, int cols)
        {
            var tempMatrix = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    tempMatrix[row, col] = matrix[rows + row, cols + col];
                }
            }
            return tempMatrix;
        }

        static int[] IntParce(params char[] separator)
            => Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
