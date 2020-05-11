namespace GenericArrayCreator
{
    using System;

    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var element = new T[length];
            for (int i = 0; i < length; i++)
            {
                element[i] = item;
            }

            return element;
        }
    }
}
