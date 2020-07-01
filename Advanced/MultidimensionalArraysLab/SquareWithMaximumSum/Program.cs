using System;
using System.Data;
using System.Linq;

namespace SquareWithMaximumSum
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

            var bigNum = int.MinValue;
            var result = new int[2, 2];
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    var temp = GetPattern(matrix, i, j);
                    var sum = GetSum(temp);

                    if (sum > bigNum)
                    {
                        bigNum = sum;
                        result = temp;
                    }
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write($"{result[i,j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(GetSum(result));
        }

        private static int GetSum(int[,] matrix)
        {
            int sum = 0;

            foreach (var element in matrix)
            {
                sum += element;
            }

            return sum;
        }
        private static int[,] GetPattern(int[,] matrix, int row, int col)
        {
            var tempMatrix = new int[2, 2];
            for (int i = 0; i < tempMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < tempMatrix.GetLength(1); j++)
                {
                    tempMatrix[i, j] = matrix[row + i, col + j];
                }
            }

            return tempMatrix;
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
