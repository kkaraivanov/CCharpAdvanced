using System;
using System.Linq;
using System.Runtime.CompilerServices;

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
                Action(matrix, actions);
                if (gameOver)
                {
                    break;
                }
            }
            
            
        }

        static void Action(char[,] matrix, char actions)
        {
            
            switch (actions)
            {
                case 'U':
                    if (CellIsInTheMatrix(matrix, startRow - 1, startCol))
                    {
                        if (CellWithBunny(matrix, startRow - 1, startCol))
                        {
                            GameOver(matrix, startRow - 1, startCol);
                            return;
                        }
                        else
                        {
                            MovePlayer(startRow - 1, startCol);
                            ReproductionBunny(matrix);
                        }
                    }
                    else
                    {
                        GameOver(matrix, startRow - 1, startCol, false);
                    }
                    break;
                case 'D':
                    if (CellIsInTheMatrix(matrix, startRow + 1, startCol))
                    {
                        if (CellWithBunny(matrix, startRow + 1, startCol))
                        {
                            GameOver(matrix, startRow + 1, startCol);
                            return;
                        }
                        else
                        {
                            MovePlayer(startRow + 1, startCol);
                            ReproductionBunny(matrix);
                        }
                    }
                    else
                    {
                        GameOver(matrix, startRow - 1, startCol, false);
                    }
                    break;
                case 'L':
                    if (CellIsInTheMatrix(matrix, startRow , startCol - 1))
                    {
                        if (CellWithBunny(matrix, startRow, startCol - 1))
                        {
                            GameOver(matrix, startRow, startCol - 1);
                            return;
                        }
                        else
                        {
                            MovePlayer(startRow, startCol - 1);
                            ReproductionBunny(matrix);
                        }
                    }
                    else
                    {
                        GameOver(matrix, startRow, startCol - 1, false);
                    }
                    break;
                case 'R':
                    if (CellIsInTheMatrix(matrix, startRow, startCol + 1))
                    {
                        if (CellWithBunny(matrix, startRow, startCol + 1))
                        {
                            GameOver(matrix, startRow, startCol + 1);
                            return;
                        }
                        else
                        {
                            MovePlayer(startRow, startCol + 1);
                            ReproductionBunny(matrix);
                        }
                    }
                    else
                    {
                        GameOver(matrix, startRow, startCol + 1, false);
                    }
                    break;
            }
        }

        static void DisplayMatrix(char[,] matrix)
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

        static void ReproductionBunny(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (CellWithBunny(matrix, i, j))
                    {
                        // top left
                        if (CellIsInTheMatrix(matrix, i - 1, j - 1) && matrix[i - 1, j - 1] == '.')
                            matrix[i - 1, j - 1] = 'B';
                        // top
                        if (CellIsInTheMatrix(matrix, i - 1, j) && matrix[i - 1, j] == '.')
                            matrix[i - 1, j] = 'B';
                        // top right
                        if (CellIsInTheMatrix(matrix, i - 1, j + 1) && matrix[i - 1, j + 1] == '.')
                            matrix[i - 1, j + 1] = 'B';
                        // left
                        if(CellIsInTheMatrix(matrix, i, j - 1) && matrix[i, j - 1] == '.')
                        matrix[i, j - 1] = 'B';
                        // right
                        if (CellIsInTheMatrix(matrix, i, j + 1) && matrix[i, j + 1] == '.')
                            matrix[i, j + 1] = 'B';
                        // from below left
                        if (CellIsInTheMatrix(matrix, i + 1, j - 1) && matrix[i + 1, j - 1] == '.')
                            matrix[i + 1, j - 1] = 'B';
                        // from below
                        if (CellIsInTheMatrix(matrix, i + 1, j) && matrix[i + 1, j] == '.')
                            matrix[i + 1, j] = 'B';
                        // from below right
                        if (CellIsInTheMatrix(matrix, i + 1, j + 1) && matrix[i + 1, j + 1] == '.')
                            matrix[i + 1, j + 1] = 'B';
                    }
                }
            }
        }

        static void MovePlayer(int row, int col)
        {
            startRow = row;
            startCol = col;
        }

        static void GameOver(char[,] matrix, int row, int col, bool check = true)
        {
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

        static void GetPlayerPosition(char[,] matrix)
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

        private static char[,] NewMatrix(int[] dimensions)
        {
            var matrix = new char[dimensions[0], dimensions[1]];
            for (int i = 0; i < dimensions[0]; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            return matrix;
        }

        static bool CellWithBunny(char[,] matrix, int row, int col)
            => matrix[row, col] == 'B';

        static bool CellIsInTheMatrix(char[,] matrix, int row, int col)
            => row >= 0 && matrix.GetLength(0) > row &&
               col >= 0 && matrix.GetLength(1) > col;
    }
}
