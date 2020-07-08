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
        private int weight;

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

        private int Weight
        {
            set
            {
                value.InvalidDoughWeightMessage(MIN_WEIGHT_VALUE, MAX_WEIGHT_VALUE);

                weight = value;
            }
        }

        public double Calories => CaloriesCalculate();

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            flourType = char.ToUpper(flourType[0]) + flourType.Substring(1);
            bakingTechnique = char.ToUpper(bakingTechnique[0]) + bakingTechnique.Substring(1);

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private double CaloriesCalculate()
        {
            double flourType = this.flourType switch
            {
                "White" => ModifierConstant.White,
                "Wholegrain" => ModifierConstant.Wholegrain
            };
            double bakingTechnique = this.bakingTechnique switch
            {
                "Crispy" => ModifierConstant.Crispy,
                "Chewy" => ModifierConstant.Chewy,
                "Homemade" => ModifierConstant.Homemade
            };

            return (BASE_CALORIES * weight) * bakingTechnique * flourType;
        }
    }
}