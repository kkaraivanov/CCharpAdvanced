namespace WildFarm.Model.Animal
{
    using Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.25;

        protected override void ValidateFood(Food food)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Meat")
                ThrowInvalidFood(food);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}