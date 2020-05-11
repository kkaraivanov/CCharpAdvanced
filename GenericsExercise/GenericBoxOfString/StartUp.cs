namespace GenericBoxOfString
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var inputOfType = new BoxOfType<string>();

            for (int i = 0; i < n; i++)
            {
                inputOfType.Value = Console.ReadLine();
                Console.WriteLine(inputOfType);
            }
        }
    }
}
