namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = null;
            var cars = new List<Car>();
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                var split = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var tire = new List<Tire>();

                for (int i = 0; i < split.Length; i += 2)
                {
                    var year = int.Parse(split[i]);
                    var pressure = double.Parse(split[i + 1]);
                    var newTire = new Tire(year, pressure);
                    tire.Add(newTire);
                }

                tires.Add(tire.ToArray());
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var split = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < split.Length; i += 2)
                {
                    var horsePower = int.Parse(split[i]);
                    var cubicCapacity = double.Parse(split[i + 1]);
                    var engine = new Engine(horsePower, cubicCapacity);
                    engines.Add(engine);
                }
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                var split = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var make = split[0];
                var model = split[1];
                var year = int.Parse(split[2]);
                var fuelQuantity = double.Parse(split[3]);
                var fuelConsumption = double.Parse(split[4]);
                var engine = engines[int.Parse(split[5])];
                var tire = tires[int.Parse(split[5])];
                var car = new Car(make,model,year,fuelQuantity,fuelConsumption,engine,tire);
                cars.Add(car);
            }

            cars = cars
                .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();
            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
