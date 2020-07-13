namespace VehiclesExtension.Model
{
    public class Truck : Vehicle
    {
        private const double airConditioners = 1.6;
        private const bool hole = false;

        protected override double AirConditioners => airConditioners;

        protected override bool Hole => hole;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
    }
}