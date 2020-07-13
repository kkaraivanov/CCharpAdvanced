namespace VehiclesExtension.Model
{
    public class Car : Vehicle
    {
        private const double airConditioners = 0.9;
        private const bool hole = false;

        protected override double AirConditioners { get; set; }

        protected override bool Hole => hole;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            AirConditioners = airConditioners;
        }

    }
}