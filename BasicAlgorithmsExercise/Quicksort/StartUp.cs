namespace Quicksort
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var testList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            QuickSort<int>(testList, 0, testList.Length - 1);

            Console.WriteLine(string.Join(" ", testList));
        }

        private static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int i = left;
                int j = right;
                T pivot = arr[(i + j) / 2];

                do
                {
                    while (arr[i].CompareTo(pivot) < 0) i++;
                    while (pivot.CompareTo(arr[j]) < 0) j--;

                    if (i <= j)
                        Swap(ref arr[i++], ref arr[j--]);

                } while (i <= j);

                QuickSort<T>(arr, left, j);
                QuickSort<T>(arr, i, right);
            }
        }
        private static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
