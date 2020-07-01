using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            var findSymbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == findSymbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{findSymbol} does not occur in the matrix");
        }
    }
}
