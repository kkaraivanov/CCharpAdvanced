namespace ExplicitInterfaces.Model
{
    using System.Security;
    using Interface;

    public class Citizen : IPerson, IResident
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string GetName()
        {
            return $"{Name}";
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

    }
}