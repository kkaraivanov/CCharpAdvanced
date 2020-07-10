namespace PizzaCalories.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name
        {
            get => name;
            private set
            {
                value.InvalidPizzaNameMessage();

                name = value;
            }
        }

        public double TotalCalories => dough.Calories + toppings.Sum(x => x.Calories);

        private Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            Name = name;
            this.dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            toppings.InvalidPizzaToppingCountMessage();

            toppings.Add(topping);
        }
    }
}