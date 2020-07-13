namespace VehiclesExtension.Model
{
    public class Bus : Vehicle
    {
        protected override double AirConditioners => 1.4;

        protected override bool Hole => false;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            double expenceFuel = FuelConsumption * distance;

            if (expenceFuel > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= expenceFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}