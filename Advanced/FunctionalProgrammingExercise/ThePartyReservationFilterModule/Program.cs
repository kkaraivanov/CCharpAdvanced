using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var filters = new List<string>();
            string command = null;

            while ((command = Console.ReadLine()) != "Print")
            {
                var commandSplit = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = commandSplit[0];
                var arguments = commandSplit
                    .Skip(1)
                    .ToArray();
                var filter = $"{arguments[0]} {arguments[1]}";

                if (action == "Add filter")
                {
                    filters.Add(filter);
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(filter);
                }
            }

            foreach (var filter in filters)
            {
                peoples = Filter(peoples, filter);
            }
            
            if (peoples.Any())
                Console.WriteLine(string.Join(" ", peoples));
        }

        private static Func<List<string>, string, List<string>> Filter = (peoples, filter) =>
        {
            var arguments = filter.Split(' ');
            var temp = new List<string>();

            if (arguments[0] == "Starts")
            {
                temp = peoples.Where(n => !n.StartsWith(arguments[2])).ToList();
            }
            else if (arguments[0] == "Ends")
            {
                temp = peoples.Where(n => !n.EndsWith(arguments[2])).ToList();
            }
            else if (arguments[0] == "Length")
            {
                temp = peoples.Where(n => n.Length != int.Parse(arguments[1])).ToList();
            }
            else if (arguments[0] == "Contains")
            {
                temp = peoples.Where(n => !n.Contains(arguments[1])).ToList();
            }

            return temp;
        };
    }
}