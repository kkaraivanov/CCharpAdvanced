namespace VehiclesExtension.Model
{
    using System;

    public abstract class Vehicle
    {
        private const string POSITIVE_NUMBER_MESSAGE = "Fuel must be a positive number";
        private double fuelQuantity;

        protected abstract double AirConditioners { get; set; }

        protected abstract bool Hole { get;}

        protected double FuelConsumption { get; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if(value < 0)
                    throw new ArgumentException(POSITIVE_NUMBER_MESSAGE);

                fuelQuantity = value;
            }
        }

        public double TankCapacity { get; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
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

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                throw new ArgumentException(POSITIVE_NUMBER_MESSAGE);

            if (liters + FuelQuantity > TankCapacity)
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}