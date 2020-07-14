namespace WildFarm.Model.Animal
{
    using Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.40;

        protected override void ValidateFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Meat")
                ThrowInvalidFood(food);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}