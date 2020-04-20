using System;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var board = CreateMatrix(n);
            int counter = CountMoveSteps(board);

            Console.WriteLine(counter);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }

                Console.WriteLine();
            }
        }

        static int CountMoveSteps(char[,] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 'K')
                    {
                        if (CharEqual(arr, i, j, arr[i, j]))
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        static bool CanMoveLeft(char[,] arr, int row, int col)
            => (col >= 2 && arr.GetLength(1) > col);

        static bool CanMoveRight(char[,] arr, int row, int col)
            => (col >= 0 && arr.GetLength(1) - 2 > col);

        static bool CanMoveUp(char[,] arr, int row)
            => (row > 2 && arr.GetLength(0) > row);

        static bool CanMoveDown(char[,] arr, int row)
            => (row >= 0 && arr.GetLength(0) - 2 > row);

        static void ReplaceSimbol(char[,] arr, int row, int col)
        {
            arr[row, col] = 'O';
        }

        static bool CharEqual(char[,] arr, int row, int col, char simbol)
        {
            if (CanMoveUp(arr, row))
            {
                if (CanMoveRight(arr, row, col))
                {
                    if (arr[row - 1, col + 2] == simbol)
                        return true;
                }
                else if (CanMoveLeft(arr, row, col))
                {
                    if (arr[row - 1, col - 2] == simbol)
                        return true;
                }
            }

            if (CanMoveDown(arr, row))
            {
                if (CanMoveRight(arr, row, col))
                {
                    if (arr[row + 1, col + 2] == simbol)
                        return true;
                }
                else if (CanMoveLeft(arr, row, col))
                {
                    if (arr[row + 1, col - 2] == simbol)
                        return true;
                }
            }

            return false;
        }

        static char[,] CreateMatrix(int rowAndCol)
        {
            var temp = new char[rowAndCol, rowAndCol];
            for (int i = 0; i < rowAndCol; i++)
            {
                var currentRow = Console.ReadLine();
                for (int j = 0; j < rowAndCol; j++)
                {
                    temp[i, j] = currentRow[j];
                }
            }

            return temp;
        }
    }
}
