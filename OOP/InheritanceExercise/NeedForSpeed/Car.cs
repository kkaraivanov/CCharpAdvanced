namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        protected override double FuelConsumption
        {
            set { base.DefaultFuelConsumption = 3; }
        }
    }
}
