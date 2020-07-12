namespace ExplicitInterfaces
{
    using System;
    using System.Linq;
    using Interface;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            string input = null;
            while ((input = Console.ReadLine()) != "End")
            {
                var currentLine = input.Split().ToArray();
                var citizen = new Citizen(currentLine[0], int.Parse(currentLine[2]), currentLine[1]);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
