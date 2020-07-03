﻿namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private double currentDefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => this.currentDefaultFuelConsumption;
    }
}
