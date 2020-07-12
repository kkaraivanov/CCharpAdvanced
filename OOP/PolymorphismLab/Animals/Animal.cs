namespace Animals
{
    public class Animal
    {
        public string Name { get; set; }

        public string FavouriteFood { get; set; }

        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
    }
}