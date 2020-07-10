namespace PizzaCalories
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            string pizzaName = Console.ReadLine();
            string dough = Console.ReadLine();
            var newPizza = new PizzaCreator();
            newPizza.CreateNewPizza(pizzaName, dough);
        }
    }
}
