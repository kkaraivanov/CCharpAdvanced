namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var passingThrough = new List<IIdentifiable>();
            string input = null;
            while ((input = Console.ReadLine()) != "End")
            {
                IIdentifiable currentPassingThrough;
                var line = input.Split();
                if (line.Length == 3)
                {
                    currentPassingThrough = new Citizen(line[0],int.Parse(line[1]), line[2]);
                    passingThrough.Add(currentPassingThrough);
                }
                else if (line.Length == 2)
                {
                    currentPassingThrough = new Robot(line[0], line[1]);
                    passingThrough.Add(currentPassingThrough);
                }
            }

            var uniqueNumber = Console.ReadLine();
            foreach (var passing in passingThrough)
            {
                var ident = passing.Id.Substring(passing.Id.Length - uniqueNumber.Length);
                if(ident == uniqueNumber)
                    Console.WriteLine(passing.Id);
            }
        }
    }
}
