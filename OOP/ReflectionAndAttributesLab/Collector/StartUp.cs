namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSeters("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
