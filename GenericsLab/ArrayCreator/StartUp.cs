namespace GenericArrayCreator
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] ints = ArrayCreator.Create(10, 33);
        }
    }
}
