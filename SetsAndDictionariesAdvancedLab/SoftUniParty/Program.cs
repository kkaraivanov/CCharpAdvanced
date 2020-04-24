using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();
            bool party = false;

            while (input != "END")
            {
                bool checkVip = char.IsDigit(input[0]);
                if (input == "PARTY")
                {
                    party = true;
                }

                if (party)
                {
                    if (checkVip)
                    {
                        vip.Remove(input);
                    }
                    else
                    {
                        regular.Remove(input);
                    }
                }
                else
                {
                    if (checkVip)
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);
            Console.WriteLine(
                vip.Count == 0 ? string.Join(Environment.NewLine, regular) : 
                regular.Count == 0 ? string.Join(Environment.NewLine, vip) : 
                string.Join(Environment.NewLine, vip) +Environment.NewLine + 
                string.Join(Environment.NewLine, regular));
        }
    }
}
