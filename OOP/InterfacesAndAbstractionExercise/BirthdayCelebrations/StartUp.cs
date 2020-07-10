namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var datesOfBirth = new List<IBirthable>();
            string input = null;
            while ((input = Console.ReadLine()) != "End")
            {
                var line = input.Split();
                if (line[0] == "Citizen")
                {
                    datesOfBirth.Add(new Citizen(line[1], int.Parse(line[2]), line[3], line[4]));
                }
                
                if (line[0] == "Pet")
                {
                    datesOfBirth.Add(new Pet(line[1], line[2]));
                }
            }

            var dateFind = int.Parse(Console.ReadLine());
            datesOfBirth.Where(c => c.Birthdate.Year == dateFind)
                .Select(x => x.Birthdate)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:dd/mm/yyyy}"));
        }
    }
}
