namespace Tuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var tuple1 = new MyTuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            var tuple2 = new MyTuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            var tuple3 = new MyTuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(tuple3);
        }
    }
}
