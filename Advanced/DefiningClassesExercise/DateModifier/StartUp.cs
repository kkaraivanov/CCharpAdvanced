namespace DateModifier
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string ferstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            var dm = new DateModifier();

            Console.WriteLine(dm.Calculate(ferstDate,secondDate));
        }
    }
}
