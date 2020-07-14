namespace WildFarm.Model.Food
{
    public abstract class Food
    {
        public int Quantity { get; set; }

        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}