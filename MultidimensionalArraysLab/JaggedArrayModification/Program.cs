using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int coordinates = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(coordinates, coordinates);

            while (true)
            {
                var commands = Console.ReadLine().Split().ToArray();

                if (commands.Contains("END"))
                {
                    DisplayMatrix(matrix);
                    break;
                }

                var row = int.Parse(commands[1]);
                var col = int.Parse(commands[2]);
                var value = int.Parse(commands[3]);
                
                if (CoordinateIsValid(coordinates, row, col))
                {
                    if (commands.Contains("Add"))
                    {
                        var temp = matrix[row, col];
                        matrix[row, col] += value;
                    }

                    if (commands.Contains("Subtract"))
                    {
                        matrix[row, col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
        }

        static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }

                Console.WriteLine();
            }
        }

        static bool CoordinateIsValid(int coordinate, int row, int col)
        {
            return ((row <= coordinate - 1 && 0 <= row) && (col <= coordinate - 1 && 0 <= col));
        }

        static int[,] CreateMatrix(int row, int col)
        {
            var matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                var arr = InputArr();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            return matrix;
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
