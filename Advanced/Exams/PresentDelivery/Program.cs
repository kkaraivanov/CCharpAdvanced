namespace PresentDelivery
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[,] neighbourhood;
        private static int[] santa = new int[2];
        private static int countOofPresents = 0;
        private static int niceKids = 0;

        static void Main(string[] args)
        {
            countOofPresents = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            bool santaGoes = false;
            MakeNeighbourhood(size);
            santa = neighbourhood.Position('S');

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Christmas morning")
                    break;
                if (countOofPresents <= 0)
                {
                    santaGoes = true;
                    break;
                }

                SantaAction(command);
            }

            int niceKitd = neighbourhood.CheckNiceKid();
            if (santaGoes)
                Console.WriteLine("Santa ran out of presents!");

            PrintNeighbourhood();
            if (niceKitd == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKitd} nice kid/s.");
            }
        }

        private static void SantaAction(string action)
        {
            int[] newPosition = new int[2];
            switch (action)
            {
                case "up":
                    newPosition[0] = santa[0] - 1; newPosition[1] = santa[1];
                    if (newPosition.CanMove(neighbourhood))
                        Move(newPosition);
                    break;
                case "down":
                    newPosition[0] = santa[0] + 1; newPosition[1] = santa[1];
                    if (newPosition.CanMove(neighbourhood))
                        Move(newPosition);
                    break;
                case "right":
                    newPosition[0] = santa[0]; newPosition[1] = santa[1] + 1;
                    if (newPosition.CanMove(neighbourhood))
                        Move(newPosition);
                    break;
                case "left":
                    newPosition[0] = santa[0]; newPosition[1] = santa[1] - 1;
                    if (newPosition.CanMove(neighbourhood))
                        Move(newPosition);
                    break;
            }
        }

        private static void Move(int[] position, bool handOutCookies = false)
        {
            if (!handOutCookies)
            {
                if (neighbourhood.GetKidType(position) == 'X')
                {
                    position.Leav(neighbourhood);
                }
                else if (neighbourhood.GetKidType(position) == 'V')
                {
                    position.Leav(neighbourhood);
                    countOofPresents--;
                    niceKids++;
                }
                else if (neighbourhood.GetKidType(position) == 'C')
                {
                    var up = new int[] { position[0] - 1, position[1] };
                    var down = new int[] { position[0] + 1, position[1] };
                    var left = new int[] { position[0], position[1] - 1 };
                    var right = new int[] { position[0], position[1] + 1 };
                    if (up.CanMove(neighbourhood) && countOofPresents >= 0)
                        Move(up, true);
                    if (down.CanMove(neighbourhood) && countOofPresents >= 0)
                        Move(down, true);
                    if (left.CanMove(neighbourhood) && countOofPresents >= 0)
                        Move(left, true);
                    if (right.CanMove(neighbourhood) && countOofPresents >= 0)
                        Move(right, true);
                }

                santa.Leav(neighbourhood);
                santa = position.ToArray();
                santa.NewPosition(neighbourhood);
            }
            else
            {
                if (neighbourhood.GetKidType(position) == 'X')
                {
                    position.Leav(neighbourhood);
                    countOofPresents--;
                }
                else if (neighbourhood.GetKidType(position) == 'V')
                {
                    position.Leav(neighbourhood);
                    countOofPresents--;
                    niceKids++;
                }
            }
        }

        static void MakeNeighbourhood(int size)
        {
            neighbourhood = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < size; j++)
                {
                    neighbourhood[i, j] = currentRow[j];
                }
            }
        }

        static void PrintNeighbourhood()
        {
            for (int i = 0; i < neighbourhood.GetLength(0); i++)
            {
                for (int j = 0; j < neighbourhood.GetLength(1); j++)
                {
                    Console.Write($"{neighbourhood[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }

    public static class Extension
    {
        public static bool CanMove(this int[] player, char[,] arr) =>
            player[0] >= 0 && arr.GetLength(0) > player[0] &&
            player[1] >= 0 && arr.GetLength(1) > player[1];

        public static int[] Position(this char[,] arr, params char[] p)
        {
            int[] temp = new int[2];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    foreach (var element in p)
                    {
                        if (element == arr[i, j])
                        {
                            temp[0] = i;
                            temp[1] = j;
                        }

                        break;
                    }
                }
            }

            return temp;
        }

        public static void Leav(this int[] player, char[,] arr)
        {
            arr[player[0], player[1]] = '-';
        }

        public static void NewPosition(this int[] player, char[,] arr)
        {
            arr[player[0], player[1]] = 'S';
        }

        public static char GetKidType(this char[,] arr, int[] position)
        {
            char temp = '-';
            switch (arr[position[0], position[1]])
            {
                case 'V':
                    temp = 'V';
                    break;
                case 'X':
                    temp = 'X';
                    break;
                case 'C':
                    temp = 'C';
                    break;
            }

            return temp;
        }

        public static int CheckNiceKid(this char[,] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 'V')
                        result++;
                }
            }

            return result;
        }
    }
}
