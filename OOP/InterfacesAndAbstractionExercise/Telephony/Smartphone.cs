namespace Telephony
{
    using System;

    public class Smartphone : IPhone, IBrows
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browsing(string address)
        {
            Console.WriteLine($"Browsing: {address}!");
        }
    }
}