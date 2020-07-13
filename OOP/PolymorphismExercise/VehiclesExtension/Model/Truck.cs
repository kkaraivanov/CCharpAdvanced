namespace VehiclesExtension.Model
{
    public class Truck : Vehicle
    {
        private const double airConditioners = 1.6;
        private const bool hole = false;

        protected override double AirConditioners { get; set; }

        protected override bool Hole => hole;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            AirConditioners = airConditioners;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= (1 - 0.95) * liters;
        }
    }
}