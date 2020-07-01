namespace GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericClass<T>
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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.item.Select(x => $"{typeof(T)}: {x}"));
        }
    }
}
