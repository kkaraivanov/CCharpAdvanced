namespace PizzaCalories
{
    using System;
    using Model;

    public class PizzaCreator
    {
        public void CreateNewPizza(string pizza, string dough)
        {
            string input = null;
            string pizzaName = pizza.Split(' ', StringSplitOptions.None)[1];
            string doughType = dough.Split(' ', StringSplitOptions.None)[1];
            string bakingTechnique = dough.Split(' ', StringSplitOptions.None)[2];
            double doughWeight = double.Parse(dough.Split(' ', StringSplitOptions.None)[3]);

            try
            {
                Dough newDough = new Dough(doughType, bakingTechnique, doughWeight);
                var newPizza = new Pizza(pizzaName, newDough);

                while ((input = Console.ReadLine()) != "END")
                {
                    string type = input.Split(' ', StringSplitOptions.None)[1];
                    double weight = double.Parse(input.Split(' ', StringSplitOptions.None)[2]);

                    var topping = new Topping(type, weight);
                    newPizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizzaName} - {newPizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}