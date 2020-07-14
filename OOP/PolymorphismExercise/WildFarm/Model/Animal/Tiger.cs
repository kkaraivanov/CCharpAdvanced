namespace WildFarm.Model.Animal
{
    using Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerFood => 1.00;

        protected override void ValidateFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Meat")
                ThrowInvalidFood(food);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}