namespace ShoppingSpree.Models
{
    using System;
    using Common;

    public class Product
    {
        private const decimal COST_MIN_VALUE = 0M;
        private string name;
        private decimal cost;

        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);

                name = value;
            }
        }

        public decimal Cost
        {
            get => cost;
            private set
            {
                if(value < COST_MIN_VALUE)
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);

                cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}