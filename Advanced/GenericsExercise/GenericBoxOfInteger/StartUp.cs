namespace GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var inputOfType = new BoxOfType<int>();

            for (int i = 0; i < n; i++)
            {
                inputOfType.Value = int.Parse(Console.ReadLine());
                Console.WriteLine(inputOfType);
            }
        }
    }
}
