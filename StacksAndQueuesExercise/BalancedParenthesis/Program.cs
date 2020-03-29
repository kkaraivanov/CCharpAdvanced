namespace BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var left = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var item in input)
            {
                if (item.Equals('(') || item.Equals('{') || item.Equals('['))
                {
                    left.Push(item);
                }
                else if (item.Equals(')') || item.Equals('}') || item.Equals(']') && left.Count > 0)
                {
                    if (ValidSide(left.Peek(), item))
                    {
                        left.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }

        static bool ValidSide(char left, char right)
        {
            bool result = false;

            if (left == '(' && right == ')')
                result = true;
            else if (left == '{' && right == '}')
                result = true;
            else if (left == '[' && right == ']')
                result = true;

            return result;
        }
    }
}
