using System;

namespace KnightGame
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var board = CreateMatrix(n);
            int counter = CountMoveSteps(board);

            Console.WriteLine(counter);
            //Console.WriteLine();
            //for (int i = 0; i < board.GetLength(0); i++)
            //{
            //    for (int j = 0; j < board.GetLength(1); j++)
            //    {
            //        Console.Write(board[i, j]);
            //    }

            //    Console.WriteLine();
            //}
        }

        static int CountMoveSteps(char[,] arr)
        {
            int tempCounter = 0;
            int maxCountKnight = int.MinValue;
            int row = 0;
            int col = 0;
            int result = 0;
            char symbol = 'K';
            while (true)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j].Equals(symbol))
                        {
                            if (CanMoveRightVerticalDown(arr, i, j))
                                if (arr[i + 2, j + 1].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveRightVerticalUp(arr, i, j))
                                if (arr[i - 2, j + 1].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveLeftVerticalDown(arr, i, j))
                                if (arr[i + 2, j - 1].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveLeftVerticalUp(arr, i, j))
                                if (arr[i - 2, j - 1].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveRightHorisontalDown(arr, i, j))
                                if (arr[i + 1, j + 2].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveRightHorisontalUp(arr, i, j))
                                if (arr[i - 1, j + 2].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveLeftHorisontalDown(arr, i, j))
                                if (arr[i + 1, j - 2].Equals(symbol))
                                    tempCounter++;

                            if (CanMoveLeftHorisontalUp(arr, i, j))
                                if (arr[i - 1, j - 2].Equals(symbol))
                                    tempCounter++;
                        }

                        if (tempCounter > maxCountKnight)
                        {
                            maxCountKnight = tempCounter;
                            row = i;
                            col = j;
                        }

                        tempCounter = 0;
                    }
                }

                if (maxCountKnight != 0)
                {
                    ReplaceSymbol(arr, row, col);
                    result++;
                    maxCountKnight = 0;
                    continue;
                }

                break;
            }

            return result;
        }

        static void ReplaceSymbol(char[,] arr, int row, int col)
        {
            arr[row, col] = 'O';
        }

        static char[,] CreateMatrix(int rowAndCol)
        {
            var temp = new char[rowAndCol, rowAndCol];
            for (int i = 0; i < rowAndCol; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < rowAndCol; j++)
                {
                    temp[i, j] = currentRow[j];
                }
            }

            return temp;
        }

        static bool CanMoveLeftVerticalDown(char[,] arr, int row, int col)
            => (col - 1 >= 0 && arr.GetLength(1) > col && CanMoveDown(arr, row));

        static bool CanMoveLeftVerticalUp(char[,] arr, int row, int col)
            => (col - 1 >= 0 && arr.GetLength(1) > col && CanMoveUp(arr, row));

        static bool CanMoveLeftHorisontalDown(char[,] arr, int row, int col)
            => (col - 2 >= 0 && arr.GetLength(1) > col && CanMoveDown(arr, row, 1));

        static bool CanMoveLeftHorisontalUp(char[,] arr, int row, int col)
            => (col - 2 >= 0 && arr.GetLength(1) > col && CanMoveUp(arr, row, 1));

        static bool CanMoveRightVerticalDown(char[,] arr, int row, int col)
            => (col >= 0 && arr.GetLength(1) > col + 1 && CanMoveDown(arr, row));

        static bool CanMoveRightVerticalUp(char[,] arr, int row, int col)
            => (col >= 0 && arr.GetLength(1) > col + 1 && CanMoveUp(arr, row));

        static bool CanMoveRightHorisontalDown(char[,] arr, int row, int col)
            => (col >= 0 && arr.GetLength(1) > col + 2 && CanMoveDown(arr, row, 1));

        static bool CanMoveRightHorisontalUp(char[,] arr, int row, int col)
            => (col >= 0 && arr.GetLength(1) > col + 2 && CanMoveUp(arr, row, 1));

        static bool CanMoveUp(char[,] arr, int row, int step = 2)
            => (row - step >= 0 && arr.GetLength(0) > row);

        static bool CanMoveDown(char[,] arr, int row, int step = 2)
            => (row >= 0 && arr.GetLength(0) > row + step);
    }
}
