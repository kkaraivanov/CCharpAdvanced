namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class PizzaCreator
    {
        private List<Topping> toppings;

        public PizzaCreator()
        {
            toppings = new List<Topping>();
        }

        public void CreateNewPizza(string pizza, string dough)
        {
            string input = null;
            string pizzaName = pizza.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    string type = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].ToLower();
                    int weight = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                    var topping = new Topping(type, weight);
                    toppings.Add(topping);
                }

                string doughType = dough.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1].ToLower();
                string bakingTechnique = dough.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2].ToLower();
                int doughWeight = int.Parse(dough.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

                Dough newDough = new Dough(doughType, bakingTechnique, doughWeight);
                var newPizza = new Pizza(pizzaName, newDough, toppings);
                Console.WriteLine(newPizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}