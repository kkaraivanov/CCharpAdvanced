namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            string pizzaName = Console.ReadLine();
            string dough = Console.ReadLine();
            var newPizza = new PizzaCreator();

            try
            {
                newPizza.CreateNewPizza(pizzaName, dough);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
