namespace MilitaryElite
{
    using System;
    using System.Linq;

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

            Console.WriteLine(engine);
        }
    }
}
