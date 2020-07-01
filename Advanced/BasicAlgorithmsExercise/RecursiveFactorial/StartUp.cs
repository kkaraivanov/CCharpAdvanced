namespace RecursiveFactorial
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactorial(number));
        }

        static long GetFactorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * GetFactorial(number - 1);
        }
    }
}
