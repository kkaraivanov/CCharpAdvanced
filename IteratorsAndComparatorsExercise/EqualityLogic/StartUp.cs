namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var personSet = new SortedSet<Person>();
            var personHash = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                var person = new Person(name, age);
                personSet.Add(person);
                personHash.Add(person);
            }

            Console.WriteLine(personSet.Count);
            Console.WriteLine(personHash.Count);
        }
    }
}
