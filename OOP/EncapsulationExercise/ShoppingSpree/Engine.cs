namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Models;

    public class Engine
    {
        private List<Product> products;
        private List<Person> persons;

        public Engine()
        {
            products = new List<Product>();
            persons = new List<Person>();
        }

        public void Run()
        {
            AddPeople();
            AddProduct();
            string commandInput = null;
            while ((commandInput = Console.ReadLine()) != "END")
            {
                var personName = commandInput.Split()[0];
                var productName = commandInput.Split()[1];
                
                try
                {
                    var person = persons.First(x => x.Name == personName);
                    var product = products.First(x => x.Name == productName);
                    person.BuyProduct(product);

                    Console.WriteLine(string.Format(GlobalConstants.CanBoughtExceptionMessage, personName, productName));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            persons.ForEach(Console.WriteLine);
        }

        private void AddPeople()
        {
            var personLine = ReadLine;
            for (int i = 0; i < personLine.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var person = new Person(personLine[i], decimal.Parse(personLine[i + 1]));
                    persons.Add(person);

                    i++;
                }
            }
        }

        private void AddProduct()
        {
            var productLine = ReadLine;
            for (int i = 0; i < productLine.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var product = new Product(productLine[i], decimal.Parse(productLine[i + 1]));
                    products.Add(product);

                    i++;
                }
            }
        }

        private static string[] ReadLine => Console.ReadLine()
            .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}