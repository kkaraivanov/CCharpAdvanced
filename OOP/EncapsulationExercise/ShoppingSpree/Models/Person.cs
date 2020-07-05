namespace ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0M;
        private string name;
        private decimal money;
        private List<Product> bag;

        private bool CanAffordProduct(Product product) => product.Cost <= money;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);

                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < MONEY_MIN_VALUE)
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);

                money = value;
            }
        }

        private Person()
        {
            bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            Name = name;
            Money = money;
        }

        public IReadOnlyCollection<Product> Bag => bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (!CanAffordProduct(product))
                throw new ArgumentException(string.Format(GlobalConstants.CanotAffordExceptionMessage, name, product.Name));

            bag.Add(product);
            Money -= product.Cost;
        }

        public override string ToString()
        {
            string result = Bag.Count > 0 ? string.Join(", ", Bag) : GlobalConstants.NothingBoughtExceptionMessage;

            return $"{Name} - {result}";
        }
    }
}