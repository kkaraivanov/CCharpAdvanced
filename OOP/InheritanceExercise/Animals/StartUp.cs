namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cat;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            string input = null;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string typeAnymal = input;
                var info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Animal animal = null;
                try
                {
                    switch (typeAnymal)
                    {
                        case "":
                            animal = new Animal(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Cat":
                            animal = new Cat.Cat(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Dog":
                            animal = new Dog.Dog(info[0], int.Parse(info[1]), info[2]);
                            break;
                        case "Frog":
                            animal = new Frog.Frog(info[0], int.Parse(info[1]), info[2]);
                            break;
                            case "Kitten":
                            animals.Add(new Kitten(info[0], int.Parse(info[1]))); break;
                        case "Tomcat":
                            animals.Add(new Tomcat(info[0], int.Parse(info[1]))); break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
