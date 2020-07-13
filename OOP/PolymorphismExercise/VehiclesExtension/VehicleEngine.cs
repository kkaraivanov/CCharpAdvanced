namespace VehiclesExtension
{
    using System;
    using System.Linq;
    using System.Text;
    using Model;

    public class VehicleEngine
    {
        private Vehicle car = null;
        private Vehicle truck = null;
        private Vehicle bus = null;

        public void MakeVehicleModels()
        {
            var carLine = Console.ReadLine().Split();
            car = new Car(double.Parse(carLine[1]), double.Parse(carLine[2]), double.Parse(carLine[3]));

            var truckLine = Console.ReadLine().Split();
            truck = new Truck(double.Parse(truckLine[1]), double.Parse(truckLine[2]), double.Parse(truckLine[3]));

            var busLine = Console.ReadLine().Split();
            bus = new Bus(double.Parse(busLine[1]), double.Parse(busLine[2]), double.Parse(busLine[3]));
        }

        public void LineOfCommand(string commands)
        {
            var thisLine = commands.Split().ToArray();
            var vehicleInfo = thisLine.Skip(1).ToArray();

            switch (thisLine[0])
            {
                case "Drive":
                    if (vehicleInfo[0] == "Car")
                        Drive(car, double.Parse(vehicleInfo[1]));
                    else if (vehicleInfo[0] == "Truck")
                        Drive(truck, double.Parse(vehicleInfo[1]));
                    else if (vehicleInfo[0] == "Bus")
                        Drive(bus, double.Parse(vehicleInfo[1]));
                    break;
                case "DriveEmpty":
                    Console.WriteLine((bus as Bus)?.DriveEmpty(double.Parse(vehicleInfo[1])));
                    break;
                case "Refuel":
                    if (vehicleInfo[0] == "Car")
                        Refuel(car, double.Parse(vehicleInfo[1]));
                    else if (vehicleInfo[0] == "Truck")
                        Refuel(truck, double.Parse(vehicleInfo[1]));
                    else if (vehicleInfo[0] == "Bus")
                        Refuel(bus, double.Parse(vehicleInfo[1]));
                    break;
            }
        }

        private void Drive(Vehicle vehicle, double distance)
        {
            Console.WriteLine(vehicle.Drive(distance));
        }

        private void Refuel(Vehicle vehicle, double liters)
        {
            try
            {
                vehicle.Refuel(liters);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(car.ToString());
            sb.AppendLine(truck.ToString());
            sb.AppendLine(bus.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}