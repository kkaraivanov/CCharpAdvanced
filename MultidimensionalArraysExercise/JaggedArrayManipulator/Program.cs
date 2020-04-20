using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            // this is Ok with double type
            var arr = new double[rows][];

            CreateJaggedArr(arr, rows);
            AnalyzingJaggedArr(arr);

            while (true)
            {
                var commands = Commands();
                if (commands.Contains("End"))
                {
                    DsiplayJaggedArr(arr);
                    break;
                }

                if (commands.Length == 4)
                {
                    var row = int.Parse(commands[1]);
                    var col = int.Parse(commands[2]);
                    var value = int.Parse(commands[3]);

                    if (IndexIsValid(arr, row, col))
                    {
                        if (commands.Contains("Add"))
                        {
                            AddValue(arr, row, col, value);
                        }

                        if (commands.Contains("Subtract"))
                        {
                            SubtractValue(arr, row, col, value);
                        }
                    }
                }
            }
        }

        static void AddValue(double[][] arr, int row, int col, int value)
        {
            arr[row][col] += value;
        }

        static void SubtractValue(double[][] arr, int row, int col, int value)
        {
            arr[row][col] -= value;
        }

        static void DsiplayJaggedArr(double[][] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }

        static void AnalyzingJaggedArr(double[][] arr)
        {
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                var rowOne = arr[i].Length;
                var rowTwo = arr[i + 1].Length;
                var ferstRow = arr[i];
                var secondRow = arr[i + 1];

                if (RowIsWqual(rowOne, rowTwo))
                {
                    arr[i] = MultiplyArr(ferstRow);
                    arr[i + 1] = MultiplyArr(secondRow);
                }
                else
                {
                    arr[i] = DivideArr(ferstRow);
                    arr[i + 1] = DivideArr(secondRow);
                }
                ;
            }
        }

        static double[] MultiplyArr(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= 2;
            }

            return arr;
        }

        static double[] DivideArr(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] /= 2;
            }

            return arr;
        }

        static void CreateJaggedArr(double[][] arr, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                arr[i] = ReadRow();
            }
        }

        static bool IndexIsValid(double[][] arr, int row, int col)
            => (row >= 0 && arr.GetLength(0) > row) &&
               (col >= 0 && arr[row].Length > col);

        static bool RowIsWqual(int rowOne, int rowTwo)
            => rowOne == rowTwo;

        static string[] Commands()
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        static double[] ReadRow()
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
    }
}
