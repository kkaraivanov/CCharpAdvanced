namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private double defaultFuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption
        {
            get => defaultFuelConsumption;
            protected set { defaultFuelConsumption = value; }
        }

        protected virtual double FuelConsumption 
        { 
            get => DefaultFuelConsumption;
            set { DefaultFuelConsumption = value; }
        }

        public double Fuel { get;}

        public int HorsePower { get;}

        protected virtual void Drive(double kilometers)
        {

        }
    }
}
