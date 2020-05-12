namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command = null;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();
                persons.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person person = persons[index];
            int matches = 0;
            int noMatches = 0;

            foreach (var currentPerson in persons)
            {
                if (currentPerson.CompareTo(person) == 0)
                {
                    matches++;
                }
                else
                {
                    noMatches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {noMatches} {matches + noMatches}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
