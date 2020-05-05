namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private int capacity;

        private List<Car> Cars { get;}

        private bool CarExist(string registrationNumber) => this.Cars.Any(x => x.RegistrationNumber == registrationNumber);

        private bool ParkingIsFull => this.capacity >= this.Count;

        public Car GetCar(string registrationNumber) => this.Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

        public int Count => this.Cars.Count;

        public string AddCar(Car car)
        {
            if (this.CarExist(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (!ParkingIsFull)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.CarExist(registrationNumber))
                return "Car with that registration number, doesn't exist!";
            
            this.Cars.Remove(this.GetCar(registrationNumber));
            return $"Successfully removed {registrationNumber}";
        }

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.Cars = new List<Car>();
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                this.Cars.RemoveAll(x => x.RegistrationNumber == number);
            }
        }
    }
}
