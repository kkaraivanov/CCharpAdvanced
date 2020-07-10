namespace FoodShortage.Model
{
    using Interface;

    public class Rebel : IBuyer, IAge
    {
        private string group;

        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            this.group = group;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}