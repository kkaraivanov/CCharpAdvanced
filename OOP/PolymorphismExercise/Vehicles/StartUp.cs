namespace Vehicles
{
    using System;
    using System.Linq;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            var carLine = Console.ReadLine().Split();
            var car = new Car(double.Parse(carLine[1]), double.Parse(carLine[2]));
            var truckLine = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(truckLine[1]), double.Parse(truckLine[2]));
            int numberOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLine; i++)
            {
                var thisLine = Console.ReadLine().Split().ToArray();
                var vehicleInfo = thisLine.Skip(1).ToArray();
                switch (thisLine[0])
                {
                    case "Drive":
                        if (vehicleInfo[0] == "Car")
                            Drive(car, double.Parse(vehicleInfo[1]));
                        else
                            Drive(truck, double.Parse(vehicleInfo[1]));
                        break;
                    case "Refuel":
                        if (vehicleInfo[0] == "Car")
                            Refuel(car, double.Parse(vehicleInfo[1]));
                        else
                            Refuel(truck, double.Parse(vehicleInfo[1]));
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void Drive(Vehicle vehicle, double distance)
        {
            Console.WriteLine(vehicle.Drive(distance));
        }

        private static void Refuel(Vehicle vehicle, double liters)
        {
            vehicle.Refuel(liters);
        }
    }
}
