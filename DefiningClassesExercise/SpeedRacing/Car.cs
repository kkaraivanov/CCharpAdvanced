namespace SpeedRacing
{
    using System;

    public class Car
    {
        public string Model { get;}

        public double FuelAmount { get; private set; }

        public double FuelConsumptionPerKilometer { get;}

        public double TravelledDistance { get; private set; }

        private bool CanDrive(double amountOfKm) => FuelAmount >= amountOfKm * FuelConsumptionPerKilometer;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public void Drive(double amountOfKm)
        {
            if (CanDrive(amountOfKm))
            {
                this.TravelledDistance += amountOfKm;
                this.FuelAmount -= amountOfKm * this.FuelConsumptionPerKilometer;
            }
            else
            {
                DisplayError();
            }
        }

        private void DisplayError()
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
