namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }
        protected override double FuelConsumption
        {
            set { base.DefaultFuelConsumption = 10; }
        }
    }
}
