namespace Telephony
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split().ToArray();
            var url = Console.ReadLine().Split().ToArray();
            
            foreach (var number in phoneNumbers)
            {
                if (!number.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                IPhone phone = null;
                if (number.Length == 10)
                    phone = new Smartphone();

                if (number.Length == 7)
                    phone = new StationaryPhone();

                phone.Calling(number);
            }

            foreach (var address in url)
            {
                if (address.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                IBrows phone = new Smartphone();

                phone.Browsing(address);
            }
        }
    }
}
