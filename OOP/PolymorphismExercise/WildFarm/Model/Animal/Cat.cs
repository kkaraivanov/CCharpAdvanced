namespace WildFarm.Model.Animal
{
    using Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerFood => 0.30;

        protected override void ValidateFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Vegetable" && foodType != "Meat")
                ThrowInvalidFood(food);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}