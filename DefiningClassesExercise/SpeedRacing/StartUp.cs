namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                if(cars.Select(x => x.Model).Contains(model))
                    continue;

                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string command = null;
            while ((command = Console.ReadLine()) != "End")
            {
                var split = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = split[0];
                string model = split[1];
                double amountOfKm = double.Parse(split[2]);
                cars.Where(x => x.Model == model).ToList().ForEach(x => x.Drive(amountOfKm));
            }

            cars.ForEach(x => Console.WriteLine($"{x.Model} {x.FuelAmount:f2} {x.TravelledDistance}"));
        }
    }
}
