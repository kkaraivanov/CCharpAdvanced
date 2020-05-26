namespace Quicksort
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private void QuickSort<T>(T[] arr, int lo, int hi) where T : IComparable
        {
            int i = lo;
            int j = hi;
            IComparable pivot = arr[lo];

            while (i <= j)
            {
                for (; (arr[i].CompareTo(pivot) < 0) && (i.CompareTo(hi) < 0); i++) ;
                for (; (pivot.CompareTo(arr[j]) < 0) && (j.CompareTo(lo) > 0); j--) ;

                if (i <= j)
                    Swap(ref arr[i++], ref arr[j--]);

            }
            if (lo < j) QuickSort<T>(arr, lo, j);
            if (i < hi) QuickSort<T>(arr, i, hi);
        }
        static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
