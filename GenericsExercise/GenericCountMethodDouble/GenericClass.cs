namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericClass<T>
        where T : IComparable<T>
    {
        private List<T> item;

        public GenericClass()
        {
            this.item = new List<T>();
        }

        public void Add(T item)
        {
            this.item.Add(item);
        }

        public void Swap(int ferstIndex, int secondIndex)
        {
            var temp = this.item[ferstIndex];
            this.item[ferstIndex] = this.item[secondIndex];
            this.item[secondIndex] = temp;
        }

        public int Count(T item)
        {
            return this.item.Where(x => x.CompareTo(item) > 0).Count();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.item.Select(x => $"{typeof(T)}: {x}"));
        }
    }
}
