using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(n);
            var bomos = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bomos.Length; i++)
            {
                int row = int.Parse(bomos[i].Split(',')[0]);
                int col = int.Parse(bomos[i].Split(',')[1]);

                if (CoordinateIsValid(matrix, row, col))
                {
                    BombExplode(matrix, row, col);
                }
            }

            long sum = 0;
            Console.WriteLine($"Alive cells: {GetCountLiveCells(matrix, ref sum)}");
            Console.WriteLine($"Sum: {sum}");
            DisplayMatrix(matrix);
        }

        static int GetCountLiveCells(long[,] matrix, ref long sum)
        {
            int counter = 0;
            foreach (var value in matrix)
            {
                if (value > 0)
                {
                    sum += value;
                    counter++;
                }
            }

            return counter;
        }

        static void DisplayMatrix(long[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void BombExplode(long[,] matrix, int row, int col)
        {
            var bombValue = matrix[row, col];
            if(bombValue <= 0)
                return;

            // left above the bomb
            if (CoordinateIsValid(matrix, row - 1, col - 1))
                if(matrix[row - 1, col - 1] > 0) matrix[row - 1, col - 1]  -= bombValue;
            // above the bomb
            if (CoordinateIsValid(matrix, row - 1, col))
                if(matrix[row - 1, col] > 0) matrix[row - 1, col] -= bombValue;
            // right above the bomb
            if (CoordinateIsValid(matrix, row - 1, col + 1))
                if(matrix[row - 1, col + 1] > 0) matrix[row - 1, col + 1] -= bombValue;
            // on the left of the bomb
            if (CoordinateIsValid(matrix, row, col - 1))
                if(matrix[row, col - 1] > 0) matrix[row, col - 1] -= bombValue;
            // on the bomb
            matrix[row, col] = 0;
            // on the right of the bomb
            if (CoordinateIsValid(matrix, row, col + 1))
                if(matrix[row, col + 1] > 0) matrix[row, col + 1] -= bombValue;
            // on the left under the bomb
            if (CoordinateIsValid(matrix, row + 1, col - 1))
                if(matrix[row + 1, col - 1] > 0) matrix[row + 1, col - 1] -= bombValue;
            // under the bomb
            if (CoordinateIsValid(matrix, row + 1, col))
                if(matrix[row + 1, col] > 0) matrix[row + 1, col] -= bombValue;
            // on the right under the bomb
            if (CoordinateIsValid(matrix, row + 1, col + 1))
                if(matrix[row + 1, col + 1] > 0) matrix[row + 1, col + 1] -= bombValue;
        }

        static long[,] CreateMatrix(int num)
        {
            var temp = new long[num, num];
            for (int i = 0; i < num; i++)
            {
                var row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < num; j++)
                {
                    temp[i, j] = row[j];
                }
            }

            return temp;
        }

        static bool CoordinateIsValid(long[,] matrix, int row, int col)
            => row >= 0 && matrix.GetLength(0) > row &&
               col >= 0 && matrix.GetLength(1) > col;
    }
}
