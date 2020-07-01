namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }

        public Engine(int horsrPower, double cubicCapacity)
        {
            this.HorsePower = horsrPower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
