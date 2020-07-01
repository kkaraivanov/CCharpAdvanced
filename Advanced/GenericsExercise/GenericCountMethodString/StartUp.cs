namespace GenericCountMethodString
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strings = new GenericClass<string>();

            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }

            var count = strings.Count(Console.ReadLine());
            Console.WriteLine(count);
        }
    }
}
