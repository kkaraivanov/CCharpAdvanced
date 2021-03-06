﻿namespace Vehicles.Model
{
    public class Car : Vehicle
    {
        private const double airConditioners = 0.9;
        private const bool hole = false;

        protected override double AirConditioners => airConditioners;

        protected override bool Hole => hole;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

    }
}