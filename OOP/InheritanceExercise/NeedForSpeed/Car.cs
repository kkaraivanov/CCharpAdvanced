namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double currentDefaultFuelConsumption = 3;

        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => this.currentDefaultFuelConsumption;
    }
}
