namespace SantasPresentFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<int>> toys = new Dictionary<string, List<int>>();
        static void Main(string[] args)
        {
            var materials = new Stack<int>(Input);
            var magicLevel = new Queue<int>(Input);

            while (materials.Count > 0 && magicLevel.Count > 0)
            {
                int currentMaterial = materials.Peek();
                int currentMagic = magicLevel.Peek();

                if (currentMaterial == 0 || currentMagic == 0)
                {
                    if (currentMaterial == 0)
                    {
                        materials.Pop();
                    }

                    if (currentMagic == 0)
                    {
                        magicLevel.Dequeue();
                    }

                    continue;
                }

                int craftToy = currentMaterial * currentMagic;

                if (craftToy < 0)
                {
                    int newMaterial = currentMaterial + currentMagic;
                    materials.Pop();
                    magicLevel.Dequeue();
                    materials.Push(newMaterial);
                }
                else if (ToyPattern(craftToy))
                {
                    materials.Pop();
                    magicLevel.Dequeue();
                    MakeToys(craftToy);
                }
                else if (!ToyPattern(craftToy) && craftToy > 0)
                {
                    int newMaterial = currentMaterial + 15;
                    materials.Pop();
                    magicLevel.Dequeue();
                    materials.Push(newMaterial);
                }
            }

            toys.AlertChristmas();
            materials.PrintMaterials();
            magicLevel.PrintMagics();
            toys.PrintToys();
        }

        static void MakeToys(int element)
        {
            switch (element)
            {
                case 150:
                    AddToy("Doll", element);
                    break;
                case 250:
                    AddToy("Wooden train", element);
                    break;
                case 300:
                    AddToy("Teddy bear", element);
                    break;
                case 400:
                    AddToy("Bicycle", element);
                    break;
            }
        }

        private static void AddToy(string toy, int element)
        {
            if (!toys.ContainsKey(toy))
                toys[toy] = new List<int>();

            toys[toy].Add(element);
        }

        private static Func<int, bool> ToyPattern = element => element switch
        {
            150 => true,
            250 => true,
            300 => true,
            400 => true,
            _ => false
        };

        private static int[] Input => Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

    public static class Extension
    {
        public static void AlertChristmas(this Dictionary<string, List<int>> colection)
        {
            var toysCraft = new List<string>();
            if (colection.Count > 0)
            {
                bool temp = false;
                foreach (var (toy, valu) in colection)
                {
                    toysCraft.Add(toy);
                }
            }

            if ((toysCraft.Contains("Doll") && toysCraft.Contains("Train")) ||
                (toysCraft.Contains("Teddy bear") && toysCraft.Contains("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
        }

        public static void PrintToys(this Dictionary<string, List<int>> colection)
        {
            foreach (var (toy, valu) in colection
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{toy}: {valu.Count}");
            }
        }

        public static void PrintMaterials(this Stack<int> colection)
        {
            if (colection.Count != 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", colection)}");
            }
        }
        
        public static void PrintMagics(this Queue<int> colection)
        {
            if (colection.Count != 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", colection)}");
            }
        }
    }
}
