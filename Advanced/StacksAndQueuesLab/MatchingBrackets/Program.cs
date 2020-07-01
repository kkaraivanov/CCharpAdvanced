using System.Security.Permissions;

namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var temp = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c == '(')
                    temp.Push(i);
                else if (c == ')')
                {
                    int start = temp.Pop();
                    string result = input.Substring(start, i - start + 1);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
