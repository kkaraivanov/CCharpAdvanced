namespace CollectionHierarchy
{
    using System;
    using Model;

    public class StartUp
    {
        static void Main()
        {
            AddCollection ac = new AddCollection();
            AddRemoveCollection arc = new AddRemoveCollection();
            MyList ml = new MyList();

            var input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                Console.Write($"{ac.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write($"{arc.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write($"{ml.Add(item)} ");
            }
            Console.WriteLine();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{arc.Remove()} ");
            }
            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{ml.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}
