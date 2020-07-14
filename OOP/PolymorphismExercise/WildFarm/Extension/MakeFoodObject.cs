namespace WildFarm.Extension
{
    using System;
    using Model.Food;

    public static class MakeFoodObject
    {
        public static Food NewFoodObject(params string[] args)
        {
            int quantity = int.Parse(args[1]);
            switch (args[0])
            {
                case nameof(Fruit):
                    return new Fruit(quantity);
                    break;
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                break;
                case nameof(Seeds):
                    return new Seeds(quantity);
                    break;
                case nameof(Meat):
                    return new Meat(quantity);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}