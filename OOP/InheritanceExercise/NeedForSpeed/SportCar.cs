namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private double currentDefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => this.currentDefaultFuelConsumption;
    }
}
