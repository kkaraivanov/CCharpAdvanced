namespace Parking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;

    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public void Add(Car car)
        {
            if(Capacity > Count)
                data.Add(car);
        }

        public bool Remove(string manufacturer, string model) =>  data.Remove(GetCar(manufacturer, model));

        public Car GetCar(string manufacturer, string model) =>
            data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public Car GetLatestCar() => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine($"{string.Join(Environment.NewLine, data)}");

            return sb.ToString().TrimEnd();
        }
    }
}
