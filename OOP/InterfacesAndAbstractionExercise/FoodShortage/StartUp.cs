namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            var buyers = new HashSet<IBuyer>();
            int countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var currentLine = Console.ReadLine().Split();

                if (currentLine.Length == 4)
                {
                    buyers.Add(new Citizen(currentLine[0], int.Parse(currentLine[1]), currentLine[2], currentLine[3]));
                }
                else if (currentLine.Length == 3)
                {
                    buyers.Add(new Rebel(currentLine[0], int.Parse(currentLine[1]), currentLine[2]));
                }
            }

            string command = null;
            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(x => x.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
