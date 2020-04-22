using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        private static int endRow = 0;
        private static int endCol = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var field = CreateField(n);
            GetEndPosition(field);
            var getPosition = GetMinerPosition(field);
            var minerPosition = new int[2];
            minerPosition[0] = getPosition[0];
            minerPosition[1] = getPosition[1];
            int getCoalCount = GetCoalcCount(field);
            int coalCount = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                int row = minerPosition[0];
                int col = minerPosition[1];
                
                switch (command)
                {
                    case "up":
                        if (PositionIsValid(field, row - 1, col))
                        {
                            if (GameOver(row - 1, col))
                                return;

                            if (GetCoalsPosition(field, row - 1, col))
                                coalCount++;

                            MoveMiner(minerPosition, row - 1, col);
                            field[row, col] = '*';
                        }
                        break;
                    case "down":
                        if (PositionIsValid(field, row + 1, col))
                        {
                            if (GameOver(row + 1, col))
                                return;

                            if (GetCoalsPosition(field, row + 1, col))
                                coalCount++;

                            MoveMiner(minerPosition, row + 1, col);
                            field[row, col] = '*';
                        }
                        break;
                    case "left":
                        if (PositionIsValid(field, row, col - 1))
                        {
                            if (GameOver(row, col - 1))
                                return;

                            if (GetCoalsPosition(field, row, col - 1))
                                coalCount++;

                            MoveMiner(minerPosition, row, col - 1);
                            field[row, col] = '*';
                        }
                        break;
                    case "right":
                        if (PositionIsValid(field, row, col + 1))
                        {
                            if (GameOver(row, col + 1))
                                return;

                            if (GetCoalsPosition(field, row, col + 1))
                                coalCount++;

                            MoveMiner(minerPosition, row, col + 1);
                            field[row, col] = '*';
                        }
                        break;
                }
            }

            if (getCoalCount == coalCount)
            {
                Console.WriteLine($"You collected all coals! ({minerPosition[0]}, {minerPosition[1]})");
            }
            else
            {
                Console.WriteLine($"{getCoalCount - coalCount} coals left. ({minerPosition[0]}, {minerPosition[1]})");
            }

            //DisplayMatrix(field);
        }

        static int[] GetMinerPosition(char[,] matrix)
        {
            var position = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }

            return position;
        }

        static int GetCoalcCount(char[,] matrix)
        {
            int count = 0;
            foreach (var element in matrix)
            {
                if (element == 'c')
                    count++;
            }

            return count;
        }

        static char[,] CreateField(int num)
        {
            var field = new char[num, num];
            for (int i = 0; i < num; i++)
            {
                var row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < num; j++)
                {
                    var element = row[j].ToCharArray()[0];
                    field[i, j] = element;
                }
            }

            return field;
        }

        static void GetEndPosition(char[,] matrix)
        {
            var position = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'e')
                    {
                        endRow = i;
                        endCol = j;
                        return;
                    }
                }
            }
        }

        static void MoveMiner(int[] arr, int row, int col)
        {
            arr[0] = row;
            arr[1] = col;
        }

        static bool GameOver(int row, int col)
        {
            if (endRow == row && endCol == col)
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                return true;
            }

            return false;
        }

        static bool GetCoalsPosition(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 'c')
            {
                matrix[row, col] = '*';
                return true;
            }

            return false;
        }

        static bool PositionIsValid(char[,] matrix, int row, int col)
            => row >= 0 && matrix.GetLength(0) > row &&
               col >= 0 && matrix.GetLength(1) > col;

        //static void DisplayMatrix(char[,] matrix)
        //{
        //    Console.WriteLine();
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write($"{matrix[i, j]} ");
        //        }

        //        Console.WriteLine();
        //    }
        //}
    }
}
