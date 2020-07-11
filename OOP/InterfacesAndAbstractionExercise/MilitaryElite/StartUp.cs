namespace MilitaryElite
{
    using System;
    using System.Linq;
    using Enumerator;
    using Interface;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            var engine = new Engine();
            string input = null;

            while ((input = Console.ReadLine()) != "End")
            {
                engine.AddNewLine(input.Split().ToArray());
            }

            foreach (var engineSolger in engine.Solgers)
            {
                Console.WriteLine(engineSolger);
            }
        }
    }
}
