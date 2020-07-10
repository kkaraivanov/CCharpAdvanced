namespace Telephony
{
    using System;

    public class StationaryPhone : IPhone
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}