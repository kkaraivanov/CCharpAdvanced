using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var nAndM = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int row = nAndM[0];
            int col = nAndM[1];
            var snake = Console.ReadLine();
            char[,] matrix = new char[row, col];
            CreateMatrix(matrix, row, col, snake);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void CreateMatrix(char[,] matrix, int row, int col, string arr)
        {
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if(!IndexIsValid(arr, index))
                            index = 0;

                        matrix[i, j] = arr[index];
                        index++;
                    }
                }
                else
                {
                    for (int j = col - 1; j >= 0; j--)
                    {
                        if (!IndexIsValid(arr, index))
                            index = 0;

                        matrix[i, j] = arr[index];
                        index++;
                    }
                }
            }
        }

        static bool IndexIsValid(string arr, int index)
            => index >= 0 && arr.Length > index;
    }
}