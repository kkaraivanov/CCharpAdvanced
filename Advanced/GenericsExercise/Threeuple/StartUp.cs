namespace Threeuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', 4);
            var threuple1 = new Threeuple<string,string,string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(threuple1);
            
            input = Console.ReadLine().Split();
            bool isDrunk = input[2] == "drunk" ? true : false;
            var threuple2 = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine(threuple2);

            input = Console.ReadLine().Split();
            var threuple3 = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(threuple3);
        }
    }
}
