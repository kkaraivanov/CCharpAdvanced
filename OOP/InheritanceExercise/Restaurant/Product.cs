namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }
}
