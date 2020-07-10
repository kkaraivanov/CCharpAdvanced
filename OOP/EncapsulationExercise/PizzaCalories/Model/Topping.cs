namespace PizzaCalories.Model
{
    using Common;

    public class Topping
    {
        private const int MIN_WEIGHT_VALUE = 1;
        private const int MAX_WEIGHT_VALUE = 50;
        private const int BASE_CALORIES = 2;
        private string meatType;
        private double weight;

        private string MeatType
        {
            set
            {
                value.InvalidToppingTypeMessage();

                meatType = value;
            }
        }

        private double Weight
        {
            set
            { 
                value.InvalidToppingWeightMessage(MIN_WEIGHT_VALUE, MAX_WEIGHT_VALUE, meatType);

                weight = value;
            }
        }

        public double Calories => CaloriesCalculate();

        public Topping(string meatType, double weight)
        {
            MeatType = meatType;
            Weight = weight;
        }

        private double CaloriesCalculate()
        {
            double meatType = Modifiers.Modifier[this.meatType.ToLower()];

            return (BASE_CALORIES * weight) * meatType;
        }
    }
}