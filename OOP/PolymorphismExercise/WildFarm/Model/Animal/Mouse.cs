namespace WildFarm.Model.Animal
{
    using Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.10;

        protected override void ValidateFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Vegetable" && foodType != "Fruit")
                ThrowInvalidFood(food);
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}