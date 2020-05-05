namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Engine engine = null;
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = null;

                if (input.Length == 3)
                {
                    bool inputIsDigit = char.IsDigit(input[2][0]);

                    if (inputIsDigit)
                    {
                        displacement = int.Parse(input[2]);
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        efficiency = input[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Car car = null;
                string model = input[0];
                var engine = engines.Where(x => x.Model == input[1]).FirstOrDefault();
                int weight = 0;
                string color = null;

                if (input.Length == 3)
                {
                    bool inputIsDigit = char.IsDigit(input[2][0]);

                    if (inputIsDigit)
                    {
                        weight = int.Parse(input[2]);
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        color = input[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                    car = new Car(model, engine, weight, color);
                }
                else
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
