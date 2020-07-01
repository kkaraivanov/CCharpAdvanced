namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int IndexOf(this int[] arr, int key)
        {
            int min = 0;
            int max = arr.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (key == arr[mid])
                    return mid;
                else if (key < arr[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            return -1;
        }
    }
}
