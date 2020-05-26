namespace Lootbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Queue<int> firstBox;
        private static Stack<int> secondBox;
        private static List<int> items;

        static void Main(string[] args)
        {
            firstBox = new Queue<int>(ReadLine());
            secondBox = new Stack<int>(ReadLine());
            items = new List<int>();

            while (GenericIsEmpty)
            {
                int firstElement = firstBox.Peek();
                int secondElement = secondBox.Peek();
                bool isEven = (firstElement + secondElement) % 2 == 0;

                if (isEven)
                {
                    AddElements(firstElement, secondElement);
                }
                else
                {
                    MoveElsements();
                }
            }

            Console.WriteLine(DisplayBox());
            Console.WriteLine(DisplayLoot());
        }

        private static void MoveElsements()
        {
            firstBox.Enqueue(secondBox.Pop());
        }

        private static void AddElements(int firstElement, int secondElement)
        {
            items.Add(firstElement + secondElement);
            firstBox.Dequeue();
            secondBox.Pop();
        }

        private static string DisplayLoot() => items.Sum() >= 100 ? $"Your loot was epic! Value: {items.Sum()}" : $"Your loot was poor... Value: {items.Sum()}";

        private static string DisplayBox() => firstBox.Count == 0 ? "First lootbox is empty" : "Second lootbox is empty";

        private static bool GenericIsEmpty => firstBox.Count > 0 && secondBox.Count > 0;

        private static int[] ReadLine() => Console
            .ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
