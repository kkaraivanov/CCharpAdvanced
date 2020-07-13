namespace VehiclesExtension.Model
{
    public class Bus : Vehicle
    {
        private const double airConditioners = 1.4;

        protected override double AirConditioners { get; set; }

        protected override bool Hole => false;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            AirConditioners = airConditioners;
        }

        public string DriveEmpty(double distance)
        {
            AirConditioners = 0;
            double expenceFuel = FuelConsumption * distance;

            if (expenceFuel > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= expenceFuel;
            return $"{this.GetType().Name} travelled {distance} km";
            AirConditioners = airConditioners;
        }
    }
}