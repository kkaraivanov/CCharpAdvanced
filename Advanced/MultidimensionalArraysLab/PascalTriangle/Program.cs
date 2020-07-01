using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            if (n < 0)
            {
                return;
            }

            var result = new long[n][];
            if (n >= 1)
            {
                result[0] = new long[] {1};
            }

            if (n >= 2)
            {
                result[1] = new long[]{1,1};
            }

            for (long i = 2; i < n; i++)
            {
                result[i] = new long[i + 1];
                result[i][0] = 1;
                for (long j = 1; j < i; j++)
                {
                    result[i][j] = result[i - 1][j] + result[i - 1][j - 1];
                }
                result[i][i] = 1;
            }

            foreach (var row in result)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
