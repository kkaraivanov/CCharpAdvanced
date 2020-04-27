using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var peoples = new List<People>();

            for (int i = 0; i < n; i++)
            {
                var people = Console.ReadLine().Split(", ");
                peoples.Add(new People
                {
                    Name = people[0],
                    Age = int.Parse(people[1])
                });
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<People, bool> conditionFilter = condition switch
            {
                "older" => x => x.Age >= age,
                "younger" => x => x.Age < age,
                _ => x => true
            };

            Func<People, string> formater = format switch
            {
                "name" => x => x.Name,
                "age" => x => x.Age.ToString(),
                "name age" => x => $"{x.Name} - {x.Age}",
                _ => x => null
            };

            Console.WriteLine(string.Join(Environment.NewLine
                , peoples
                    .Where(conditionFilter)
                    .Select(formater)
                    .ToList()));
        }
    }

    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
