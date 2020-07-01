namespace CarManufacturer
{
    using System;
    using System.Text;

    public class Car
    {
        private Tire[] tires;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }
        
        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires
        {
            get => tires;
            set
            {
                if (value.Length >= 0 && value.Length <= 4)
                    tires = value;
            }
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025; 
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double distanceConsumption = distance * (this.FuelConsumption / 100);
            bool canContinue = this.FuelQuantity - distanceConsumption >= 0;

            if (canContinue)
                this.FuelQuantity -= distanceConsumption;
            else
                throw new Exception("Not enough fuel to perform this trip!");
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");
            return sb.ToString();
        }
    }
}
