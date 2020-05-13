namespace RecursiveArraySum
{
    using System;

    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(Sum(input, input.Length));
        }

        static int Sum(int[] arr, int index)
        {
            if (index <= 0)
                return  0;

            return Sum(arr, index - 1) + arr[index - 1];
        }
    }
}
