using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        #region Fields

        private static int currentPlayerRow = 0;
        private static int currentPlayerCol = 0;
        private static bool playerWin = false;
        private static bool bunnyWin = false;
        private static char[,] matrix;

        #endregion


        static void Main(string[] args)
        {
            var dimensions = Dimensions;
            matrix = NewMatrix(dimensions);
            var commands = Console.ReadLine();
            PlayerStartPosition();

            for (int i = 0; i < commands.Length; i++)
            {
                var direction = commands[i];
                MovePlayer(direction);

                if (playerWin || bunnyWin)
                {
                    GameOver();
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

        private static int[] Dimensions
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        #endregion

        #region Get ferst position for Player and Bunnyes

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

        private static void MovePlayer(char direction)
        {
            LeavCell(currentPlayerRow, currentPlayerCol);

            if (direction.Equals('U'))
            {
                if (!CellIsInTheMatrix(currentPlayerRow - 1, currentPlayerCol))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(currentPlayerRow - 1, currentPlayerCol))
                    {
                        bunnyWin = true;
                        currentPlayerRow -= 1;
                    }
                    else
                        SetPlayerNewPosition(currentPlayerRow - 1, currentPlayerCol);
                }
            }

            if (direction.Equals('D'))
            {
                if (!CellIsInTheMatrix(currentPlayerRow + 1, currentPlayerCol))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(currentPlayerRow + 1, currentPlayerCol))
                    {
                        bunnyWin = true;
                        currentPlayerRow += 1;
                    }
                    else
                        SetPlayerNewPosition(currentPlayerRow + 1, currentPlayerCol);
                }
            }

            if (direction.Equals('L'))
            {
                if (!CellIsInTheMatrix(currentPlayerRow, currentPlayerCol - 1))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(currentPlayerRow, currentPlayerCol - 1))
                    {
                        bunnyWin = true;
                        currentPlayerCol -= 1;
                    }
                    else
                        SetPlayerNewPosition(currentPlayerRow, currentPlayerCol - 1);
                }
            }

            if (direction.Equals('R'))
            {
                if (!CellIsInTheMatrix(currentPlayerRow, currentPlayerCol + 1))
                {
                    playerWin = true;
                }
                else
                {
                    if (CellWithBunny(currentPlayerRow, currentPlayerCol + 1))
                    {
                        bunnyWin = true;
                        currentPlayerCol += 1;
                    }
                    else
                        SetPlayerNewPosition(currentPlayerRow, currentPlayerCol + 1);
                }
            }

            ReproductionBunny();
        }

        private static void PlayerStartPosition()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        currentPlayerRow = i;
                        currentPlayerCol = j;
                        return;
                    }
                }
            }
        }

        private static void LeavCell(int row, int col) { matrix[row, col] = '.'; }

        private static void SetPlayerNewPosition(int row, int col)
        {
            matrix[row, col] = 'P';
            currentPlayerRow = row;
            currentPlayerCol = col;
        }

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
                if (CellIsInTheMatrix(row - 1, col))
                    ReproductionBunny(row - 1, col);
                // below
                if (CellIsInTheMatrix(row + 1, col))
                    ReproductionBunny(row + 1, col);
                // left
                if (CellIsInTheMatrix(row, col - 1))
                    ReproductionBunny(row, col - 1);
                // right
                if (CellIsInTheMatrix(row, col + 1))
                    ReproductionBunny(row, col + 1);
            }
        }

        private static void ReproductionBunny(int row, int col)
        {
            if (CellWithPlayer(row, col))
            {
                bunnyWin = true;
                currentPlayerRow = row;
                currentPlayerCol = col;
            }

            matrix[row, col] = 'B';
        }

        #endregion

        #region Print matrix on the consol

        private static void GameOver()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

            if (bunnyWin)
            {
                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");
            }

            if (playerWin)
            {
                Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");
            }
        }

        #endregion

        #endregion
    }
}
