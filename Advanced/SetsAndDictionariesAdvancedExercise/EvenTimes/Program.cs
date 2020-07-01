using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        counter++;
                }

                if (counter % 2 == 0)
                    result = arr[i];
            }

            Console.WriteLine(result);
        }
    }
}
