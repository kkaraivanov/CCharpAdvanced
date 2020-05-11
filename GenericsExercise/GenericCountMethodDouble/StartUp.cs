namespace GenericCountMethodDouble
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strings = new GenericClass<double>();

            for (int i = 0; i < n; i++)
            {
                strings.Add(double.Parse(Console.ReadLine()));
            }

            var count = strings.Count(double.Parse(Console.ReadLine()));
            Console.WriteLine(count);
        }
    }
}
