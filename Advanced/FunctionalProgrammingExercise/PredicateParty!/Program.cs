using System;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = null;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandSplit = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = commandSplit[0];
                var predicates = commandSplit
                    .Skip(1)
                    .ToArray();
                Predicate < string > predicate = PredicateParty(predicates);
                
                if (action == "Remove")
                {
                    peoples.RemoveAll(predicate);
                }
                else if (action == "Double")
                {
                    for (int i = 0; i < peoples.Count; i++)
                    {
                        string people = peoples[i];
                        if (predicate(people))
                        {
                            peoples.Insert(i + 1, people);
                            i++;
                        }
                    }
                }
            }

            if(peoples.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine($"{string.Join(", ", peoples)} are going to the party!");
        }

        static Predicate<string> PredicateParty(string[] arr)
        {
            string type = arr[0];
            string argument = arr[1];
            Predicate < string > predicate = null;

            if (type == "StartsWith")
            {
                predicate = new Predicate<string>(people => { return people.StartsWith(argument); });
            }
            else if (type == "EndsWith")
            {
                predicate = new Predicate<string>(people => { return people.EndsWith(argument); });
            }
            else if (type == "Length")
            {
                predicate = new Predicate<string>(people => { return people.Length == int.Parse(argument); });
            }

            return predicate;
        }
    }
}
