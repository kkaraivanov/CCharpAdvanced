using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        private static int startRow = 0;
        private static int startCol = 0;
        private static bool gameOver = false;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = NewMatrix(dimensions);
            var commands = Console.ReadLine(); //'LLRRUUDD'Left, Right, Up, Down
            GetPlayerPosition(matrix);

            for (int i = 0; i < commands.Length; i++)
            {
                var actions = commands[i];
                switch (actions)
                {
                    case 'U':
                        LeavCell(matrix, startRow, startCol);

                        if (!CellIsInTheMatrix(matrix, startRow - 1, startCol))
                            GameOver(matrix, startRow, startCol, false);
                        else
                            MovePlayer(matrix, startRow - 1, startCol);

                        ReproductionBunny(matrix);
                        break;
                    case 'D':
                        LeavCell(matrix, startRow, startCol);

                        if (!CellIsInTheMatrix(matrix, startRow + 1, startCol))
                            GameOver(matrix, startRow, startCol, false);
                        else
                            MovePlayer(matrix, startRow + 1, startCol);

                        ReproductionBunny(matrix);
                        break;
                    case 'L':
                        LeavCell(matrix, startRow, startCol);

                        if (!CellIsInTheMatrix(matrix, startRow, startCol - 1))
                            GameOver(matrix, startRow, startCol, false);
                        else
                            MovePlayer(matrix, startRow, startCol - 1);

                        ReproductionBunny(matrix);
                        break;
                    case 'R':
                        LeavCell(matrix, startRow, startCol);

                        if (!CellIsInTheMatrix(matrix, startRow, startCol + 1))
                            GameOver(matrix, startRow, startCol, false);
                        else
                            MovePlayer(matrix, startRow, startCol + 1);

                        ReproductionBunny(matrix);
                        break;
                }

                if (gameOver)
                {
                    return;
                }
            }
        }

        private static void DisplayMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void ReproductionBunny(char[,] matrix)
        {
            var bunnyPosition = GetBunnyPosition(matrix);

            for (int i = 0; i < bunnyPosition.Length; i += 2)
            {
                int row = bunnyPosition[i];
                int col = bunnyPosition[i + 1];

                // top
                if (CellIsInTheMatrix(matrix, row - 1, col))
                    ReproductionBunny(matrix, row - 1, col);
                // below
                if (CellIsInTheMatrix(matrix, row + 1, col))
                    ReproductionBunny(matrix, row + 1, col);
                // left
                if (CellIsInTheMatrix(matrix, row, col - 1))
                    ReproductionBunny(matrix, row, col - 1);
                // right
                if (CellIsInTheMatrix(matrix, row, col + 1))
                    ReproductionBunny(matrix, row, col + 1);
            }
        }

        private static void MovePlayer(char[,] matrix, int row, int col)
        {
            if (CellWithBunny(matrix, row, col))
            {
                GameOver(matrix, row, col);
                return;
            }

            startRow = row;
            startCol = col;
        }

        private static void GameOver(char[,] matrix, int row, int col, bool check = true)
        {
            ReproductionBunny(matrix);
            DisplayMatrix(matrix);
            gameOver = true;
            if (check)
            {
                Console.WriteLine($"dead: {row} {col}");
            }
            else
            {
                Console.WriteLine($"won: {row} {col}");
            }
        }

        private static void GetPlayerPosition(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        startRow = i;
                        startCol = j;
                        return;
                    }
                }
            }
        }

        private static int[] GetBunnyPosition(char[,] matrix)
        {
            var bunnyPosition = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunnyPosition.Add(i);
                        bunnyPosition.Add(j);
                    }
                }
            }

            return bunnyPosition.ToArray();
        }

        private static char[,] NewMatrix(int[] dimensions)
        {
            var matrix = new char[dimensions[0], dimensions[1]];
            for (int i = 0; i < dimensions[0]; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    if (row != null) matrix[i, j] = row[j];
                }
            }

            return matrix;
        }

        private static void ReproductionBunny(char[,] matrix, int row, int col) { matrix[row, col] = 'B'; }

        private static void LeavCell(char[,] matrix, int row, int col) { matrix[row, col] = '.'; }

        private static bool CellWithBunny(char[,] matrix, int row, int col) 
            => matrix[row, col] == 'B';

        private static bool CellIsInTheMatrix(char[,] matrix, int row, int col)
            => row >= 0 && matrix.GetLength(0) > row &&
               col >= 0 && matrix.GetLength(1) > col;
    }
}
