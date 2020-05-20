namespace MergeSort
{
    using System;

    public class Mergesort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort( T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (hi <= lo)
                return;

            int mid = (lo + hi) / 2;
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Marge(arr, lo, mid, hi);
        }

        private static void Marge(T[] arr, int lo, int mid, int hi)
        {
            for (int index = lo; index < hi + 1; index++)
                aux[index] = arr[index];

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i == mid + 1)
                    arr[k] = aux[j++];
                else if (j > hi)
                    arr[k] = aux[i++];
                else if (CompareTo(aux[i], aux[j]) <= 0)
                    arr[k] = aux[i++];
                else
                    arr[k] = aux[j++];
            }
        }

        private static int CompareTo(T x, T y) => x.CompareTo(y);
    }
}
