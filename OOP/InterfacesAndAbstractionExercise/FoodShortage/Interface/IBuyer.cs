namespace FoodShortage.Interface
{
    public interface IBuyer : INamed
    {
        public int Food { get; set; }

        public void BuyFood();
    }
}