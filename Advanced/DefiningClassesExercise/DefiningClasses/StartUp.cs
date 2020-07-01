namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numPerson = int.Parse(Console.ReadLine());
            var person = new List<Person>();

            for (int i = 0; i < numPerson; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                var newPerson = new Person(name, age);
                person.Add(newPerson);
            }

            person
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}
