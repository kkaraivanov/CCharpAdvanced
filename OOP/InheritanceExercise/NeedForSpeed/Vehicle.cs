namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel { get => this.fuel; set => this.fuel = value; }

        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }

        public virtual void Drive(double kilometers)
        {
            double fuelAfterDrive = Fuel - kilometers * FuelConsumption;
            if (fuelAfterDrive >= 0)
                Fuel = fuelAfterDrive;
        }
    }
}
