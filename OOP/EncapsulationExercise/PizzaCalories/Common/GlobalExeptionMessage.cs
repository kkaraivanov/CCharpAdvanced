namespace PizzaCalories.Common
{
    using System;
    using System.Collections.Generic;
    using Model;

    public static class GlobalExeptionMessage
    {
        public static void InvalidDoughTypeMessage(this string value)
        {
            Modifiers modifiers;
            if (!Enum.TryParse(value, out modifiers))
                throw new ArgumentException("Invalid type of dough.");
        }

        public static void InvalidToppingTypeMessage(this string value)
        {
            Modifiers modifiers;
            if (!Enum.TryParse(value, out modifiers))
                throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
        }

        public static void InvalidDoughWeightMessage(this int value, int min, int max)
        {
            if(value < min || max < value)
                throw new ArgumentException("Dough weight should be in the range [1..200].");
        }

        public static void InvalidToppingWeightMessage(this int value, int min, int max, string meatType)
        {
            if (value < min || max < value)
                throw new ArgumentException(string.Format("{0} weight should be in the range[1..50].", meatType));
        }

        public static void InvalidPizzaNameMessage(this string value)
        {
            bool checkLength = value.Length >= 1 && value.Length <= 15;
            if(string.IsNullOrWhiteSpace(value) || !checkLength)
                throw new ArgumentException(string.Format("Pizza {0} should be between 1 and 15 symbols.", value));
        }

        public static void InvalidPizzaToppingCountMessage(this List<Topping> value)
        {
            if(value.Count > 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}