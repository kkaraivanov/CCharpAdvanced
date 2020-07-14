namespace WildFarm.Model.Animal
{
    using Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.35;

        protected override void ValidateFood(Food food)
        {
            
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}