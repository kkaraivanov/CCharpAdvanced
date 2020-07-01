using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var userName = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string user = Console.ReadLine();
                userName.Add(user);
            }

            Console.WriteLine(string.Join(Environment.NewLine, userName));
        }
    }
}
