using System;
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
            var snake = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[row, col];
            Matrix(matrix, row, col, snake);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void Matrix(char[,] matrix, int row, int col, char[] arr)
        {
            int temp = 0;
            for (int i = 0; i < row; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (IndexIsValid(arr, temp))
                        {
                            matrix[i, j] = arr[temp];
                        }
                        else
                        {
                            temp = 0;
                            matrix[i, j] = arr[temp];
                        }
                        temp++;
                    }

                    temp -= 1;
                }
                else
                {
                    temp -= 1;
                    for (int j = 0; j < col; j++)
                    {
                        if (IndexIsValid(arr, temp))
                        {
                            matrix[i, j] = arr[temp];
                        }
                        else
                        {
                            temp = arr.Length - 1;
                            matrix[i, j] = arr[temp];
                        }
                        temp--;
                    }
                }
            }
        }

        static bool IndexIsValid(char[] arr, int index)
            => index >= 0 && arr.Length > index;
    }
}