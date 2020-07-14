namespace WildFarm.Model.Animal
{
    using System;
    using Food;

    public abstract class Animal
    {
        private double weight;

        protected string Name { get; } 

        protected double Weight
        {
            get => (FoodEaten * WeightPerFood) + weight;
            set => weight = value;
        } 

        protected int FoodEaten { get; set; }

        protected abstract double WeightPerFood { get; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        protected abstract void ValidateFood(Food food);

        protected void ThrowInvalidFood(Food food)
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public virtual void EatFood(Food food)
        {
            ValidateFood(food);

            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }
    }
}