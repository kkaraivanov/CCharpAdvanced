namespace ShoppingSpree
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
