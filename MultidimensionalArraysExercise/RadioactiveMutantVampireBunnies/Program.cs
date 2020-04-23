using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        #region Fields

        private static int startRow = 0;
        private static int startCol = 0;
        private static bool playerWin = false;
        private static bool gameOver = false;
        private static char[,] matrix;

        #endregion


        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            matrix = NewMatrix(dimensions);
            var commands = Console.ReadLine(); //'LLRRUUDD'Left, Right, Up, Down
            
            for (int i = 0; i < commands.Length; i++)
            {
                var direction = commands[i];
                int[] position = GetPlayerPosition();
                startRow = position[0];
                startCol = position[1];
                MovePlayer(direction);

                if (playerWin)
                {
                    GameOver(startRow, startCol);
                    break;
                }

                if (gameOver)
                {
                    ReproductionBunny();
                    GameOver(startRow, startCol);
                    break;
                }
            }
        }

        #region Properties

        #region Filling the matrix

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

        #endregion

        #region Get ferst position for Player and Bunnyes

        private static int[] GetPlayerPosition()
        {
            var position = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }

            return position;
        }

        private static int[] GetBunnyPosition()
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

        #endregion

        #region Get cell symbol and borders at the matrix

        private static bool FreeCell(int row, int col)
            => matrix[row, col] == '.';

        private static bool CellWithPlayer(int row, int col)
            => matrix[row, col] == 'P';

        private static bool CellWithBunny(int row, int col)
            => matrix[row, col] == 'B';

        private static bool CellIsInTheMatrix(int row, int col)
            => row >= 0 && matrix.GetLength(0) > row &&
               col >= 0 && matrix.GetLength(1) > col;

        #endregion

        #endregion

        #region Methods

        #region Player actions

        private static void MovePlayer(params char[] direction)
        {
            LeavCell(startRow, startCol);

            if (direction.Contains('U'))
            {
                if (!CellIsInTheMatrix(startRow - 1, startCol))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(startRow - 1, startCol))
                    {
                        gameOver = true;
                        startRow = startRow - 1;
                        return;
                    }

                    SetPlayerNewPosition(startRow - 1, startCol);
                }
            }

            if (direction.Contains('D'))
            {
                if (!CellIsInTheMatrix(startRow + 1, startCol))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(startRow + 1, startCol))
                    {
                        gameOver = true;
                        startRow = startRow + 1;
                        return;
                    }

                    SetPlayerNewPosition(startRow + 1, startCol);
                }
            }

            if (direction.Contains('L'))
            {
                if (!CellIsInTheMatrix(startRow, startCol - 1))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(startRow, startCol - 1))
                    {
                        gameOver = true;
                        startCol = startCol - 1;
                        return;
                    }

                    SetPlayerNewPosition(startRow, startCol - 1);
                }
            }

            if (direction.Contains('R'))
            {
                if (!CellIsInTheMatrix(startRow, startCol + 1))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(startRow, startCol + 1))
                    {
                        gameOver = true;
                        startCol = startCol + 1;
                        return;
                    }

                    SetPlayerNewPosition(startRow, startCol + 1);
                }
            }

            ReproductionBunny();
        }

        private static void LeavCell(int row, int col) { matrix[row, col] = '.'; }

        private static void SetPlayerNewPosition(int row, int col) { matrix[row, col] = 'P'; }

        #endregion

        #region Bunny actions

        private static void ReproductionBunny()
        {
            var bunnyPosition = GetBunnyPosition();

            for (int i = 0; i < bunnyPosition.Length; i += 2)
            {
                int row = bunnyPosition[i];
                int col = bunnyPosition[i + 1];

                // top
                if (CellIsInTheMatrix(row - 1, col) && FreeCell(row - 1, col))
                    ReproductionBunny(row - 1, col);
                // below
                if (CellIsInTheMatrix(row + 1, col) && FreeCell(row + 1, col))
                    ReproductionBunny(row + 1, col);
                // left
                if (CellIsInTheMatrix(row, col - 1) && FreeCell(row, col - 1))
                    ReproductionBunny(row, col - 1);
                // right
                if (CellIsInTheMatrix(row, col + 1) && FreeCell(row, col + 1))
                    ReproductionBunny(row, col + 1);
            }
        }

        private static void ReproductionBunny(int row, int col)
        {
            if (CellWithPlayer(row, col))
            {
                gameOver = true;
                startRow = row;
                startCol = col;
                return;
            }

            matrix[row, col] = 'B';
        }

        #endregion

        #region Print matrix on the consol

        private static void GameOver(int row, int col)
        {
            DisplayMatrix();
            if (gameOver)
            {
                Console.WriteLine($"dead: {row} {col}");
            }

            if (playerWin)
            {
                Console.WriteLine($"won: {row} {col}");
            }
        }

        private static void DisplayMatrix()
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

        #endregion

        #endregion
    }
}
