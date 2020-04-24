using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var parking = new HashSet<string>();

            while (input != "END")
            {
                var split = Regex.Split(input, ", ");
                if (split[0] == "IN")
                {
                    parking.Add(split[1]);
                }
                else
                {
                    parking.Remove(split[1]);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(
                parking.Count == 0 
                ? "Parking Lot is Empty" 
                : string.Join(Environment.NewLine, parking));
        }
    }
}
