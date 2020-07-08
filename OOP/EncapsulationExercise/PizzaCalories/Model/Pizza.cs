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

        private List<Topping> Toppings
        {
            set
            {
                value.InvalidPizzaToppingCountMessage();
                toppings = value;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                value.InvalidPizzaNameMessage();

                name = value;
            }
        }

        public double Calories => CaloriesCalculate();

        private Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough, List<Topping> toppings)
        {
            Name = name;
            this.dough = dough;
            Toppings = toppings;
        }

        private double CaloriesCalculate()
        {
            var doughCalorie = dough.Calories;
            var toppingCalorie = toppings.Sum(x => x.Calories);

            return doughCalorie + toppingCalorie;
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }
    }
}