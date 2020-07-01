using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main()
        {
            var input = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var capacity = int.Parse(Console.ReadLine());
            var bag = new Queue<int>();
            var temp = 0;

            while (input.Count > 0)
            {
                var current = input.Peek();
                temp += current;
                if (temp <= capacity)
                {
                    input.Pop();
                    if(input.Count > 0 && temp + input.Peek() > capacity)
                    {
                        bag.Enqueue(temp);
                        temp = 0;
                    }
                }
                if (input.Count == 0 && temp != 0)
                {
                    bag.Enqueue(temp);
                    temp = 0;
                }
            }

            Console.WriteLine(bag.Count);
        }
    }
}
