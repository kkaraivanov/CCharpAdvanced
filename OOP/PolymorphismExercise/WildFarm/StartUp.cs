namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using Extension;
    using Model.Animal;

    public class StartUp
    {
        static void Main()
        {
            var animals = new List<Animal>();
            string command = null;

            while ((command = Console.ReadLine()) != "End")
            {
                var animal = MakeAnimalObject.NewAnimalObject(command
                    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                animals.Add(animal);
                var foodCommand = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var food = MakeFoodObject.NewFoodObject(foodCommand);
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.EatFood(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
