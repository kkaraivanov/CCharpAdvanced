using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = IntParce();
            var matrix = Matrix(n[0], n[1]);

            int counter = ContainsChar(matrix);

            Console.WriteLine(counter);
        }

        static int ContainsChar(char[,] matrix)
        {
            int result = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (Pattern(matrix, row, col))
                        result += 1;
                }
            }

            return result;
        }

        static bool Pattern(char[,] matrix, int row, int col)
            => matrix[row, col] == matrix[row, col + 1] && 
               matrix[row, col] == matrix[row + 1, col] &&
               matrix[row, col] == matrix[row + 1, col + 1];

        static char[,] Matrix(int row, int col)
        {
            var matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                var readRow = Input(' ');
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = readRow[j];
                }
            }

            return matrix;
        }

        static int[] IntParce(params char[] separator)
                    => Console.ReadLine()
                        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

        static char[] Input(params char[] separator)
                    => Console.ReadLine()
                        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(char.Parse)
                        .ToArray();
    }

}
