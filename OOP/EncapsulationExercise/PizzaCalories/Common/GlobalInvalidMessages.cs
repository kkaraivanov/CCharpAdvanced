namespace PizzaCalories.Common
{
    using System;
    using System.Collections.Generic;
    using Model;

    public static class GlobalInvalidMessages
    {
        public static void InvalidDoughTypeMessage(this string value)
        {
            if (!Modifiers.Modifier.ContainsKey(value.ToLower()))
                throw new ArgumentException("Invalid type of dough.");
        }

        public static void InvalidToppingTypeMessage(this string value)
        {
            if (!Modifiers.Modifier.ContainsKey(value.ToLower()))
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        }

        public static void InvalidDoughWeightMessage(this double value, int min, int max)
        {
            if(value < min || max < value)
                throw new ArgumentException("Dough weight should be in the range [1..200].");
        }

        public static void InvalidToppingWeightMessage(this double value, int min, int max, string meatType)
        {
            if (value < min || max < value)
                throw new ArgumentException($"{meatType} weight should be in the range[1..50].");
        }

        public static void InvalidPizzaNameMessage(this string value)
        {
            if(value.Length < 1 || 15 < value.Length)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }

        public static void InvalidPizzaToppingCountMessage(this List<Topping> value)
        {
            if(value.Count > 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}