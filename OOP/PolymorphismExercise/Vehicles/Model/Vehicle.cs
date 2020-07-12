namespace Vehicles.Model
{
    public abstract class Vehicle
    {
        protected abstract double AirConditioners { get; }

        protected abstract bool Hole { get;}

        protected double FuelConsumption { get; }

        public double FuelQuantity { get; private set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
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