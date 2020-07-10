namespace PizzaCalories.Model
{
    using Common;

    public class Dough
    {
        private const int MIN_WEIGHT_VALUE = 1;
        private const int MAX_WEIGHT_VALUE = 200;
        private const int BASE_CALORIES = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private string FlourType
        {
            set
            {
                value.InvalidDoughTypeMessage();

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                value.InvalidDoughTypeMessage();

                bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                value.InvalidDoughWeightMessage(MIN_WEIGHT_VALUE, MAX_WEIGHT_VALUE);

                weight = value;
            }
        }

        public double Calories => CaloriesCalculate();

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private double CaloriesCalculate()
        {
            double flourType = Modifiers.Modifier[this.flourType.ToLower()];
            double bakingTechnique = Modifiers.Modifier[this.bakingTechnique.ToLower()];

            return (BASE_CALORIES * weight) * bakingTechnique * flourType;
        }
    }
}