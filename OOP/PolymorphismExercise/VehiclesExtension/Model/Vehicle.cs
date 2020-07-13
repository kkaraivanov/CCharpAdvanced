namespace VehiclesExtension.Model
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected abstract double AirConditioners { get; }

        protected abstract bool Hole { get;}

        protected double FuelConsumption { get; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if(value > TankCapacity)
                    throw new ArgumentException($"Cannot fit {value - fuelQuantity} fuel in the tank");

                fuelQuantity = value;
            }
        }

        public double TankCapacity { get;}

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
                fuelQuantity = 0;


            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public string Drive(double distance)
        {
            double expenceFuel = ((FuelConsumption + AirConditioners) * distance);
            
            if (expenceFuel > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= expenceFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
                throw new ArgumentException($"Fuel must be a positive number");
                
            if (Hole)
                FuelQuantity += liters * 0.95;
            else
                FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}