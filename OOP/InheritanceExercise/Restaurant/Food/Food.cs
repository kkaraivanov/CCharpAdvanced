﻿namespace Restaurant.Food
{
    public class Food : Product
    {
        public double Grams { get; set; }

        public Food(string name, decimal price, double grams) 
            : base(name, price)
        {
            this.Grams = grams;
        }
    }
}
