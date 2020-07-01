namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        protected override double FuelConsumption
        {
            set { base.DefaultFuelConsumption = 8; }
        }
    }
}
