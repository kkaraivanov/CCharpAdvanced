namespace VehiclesExtension
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var engine = new VehicleEngine();
            engine.MakeVehicleModels();

            int numberOfLine = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLine; i++)
            {
                engine.LineOfCommand(Console.ReadLine());
            }

            Console.WriteLine(engine);
        }
    }
}
