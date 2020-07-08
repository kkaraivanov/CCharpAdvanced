namespace PizzaCalories.Model
{
    using Common;

    public class Topping
    {
        private const int MIN_WEIGHT_VALUE = 1;
        private const int MAX_WEIGHT_VALUE = 50;
        private const int BASE_CALORIES = 2;
        private string meatType;
        private int weight;

        private string MeatType
        {
            set
            {
                value.InvalidToppingTypeMessage();

                meatType = value;
            }
        }

        private int Weight
        {
            set
            { 
                value.InvalidToppingWeightMessage(MIN_WEIGHT_VALUE, MAX_WEIGHT_VALUE, meatType);

                weight = value;
            }
        }

        public double Calories => CaloriesCalculate();

        public Topping(string meatType, int weight)
        {
            meatType = char.ToUpper(meatType[0]) + meatType.Substring(1);

            MeatType = meatType;
            Weight = weight;
        }

        private double CaloriesCalculate()
        {
            double meatType = this.meatType switch
            {
                "Meat" => ModifierConstant.Meat,
                "Veggies" => ModifierConstant.Veggies,
                "Cheese" => ModifierConstant.Cheese,
                "Sauce" => ModifierConstant.Sauce
            };

            return (BASE_CALORIES * weight) * meatType;
        }
    }
}