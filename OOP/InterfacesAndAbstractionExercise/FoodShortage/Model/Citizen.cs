namespace FoodShortage.Model
{
    using System;
    using Interface;

    public class Citizen : IIdentifiable, IBirthable, IBuyer, IAge
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }
        
        public string Id { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}