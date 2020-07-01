using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SimpleCalculator
{
    using System;

    class Program
    {
        static void Main()
        {
            var input = new Stack<string>(Console
                .ReadLine()
                .Split()
                .Reverse()
                .ToArray());
            int counter = input.Count;
            int result = 0;
            int temp = 0;
            string separator = null;

            for (int i = 0; i < counter; i++)
            {
                if (i % 2 == 0)
                {
                    if(separator == null)
                        temp = int.Parse(input.Pop());
                    else
                    {
                        int current = int.Parse(input.Pop());
                        if (separator == "+")
                        {
                            result = temp + current;
                        }
                        else if (separator == "-")
                        {
                            result = temp - current;
                        }

                        temp = result;
                    }
                    
                }
                else
                {
                    separator = input.Pop();
                }
            }

            Console.WriteLine(result);
        }
    }
}
