namespace ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool Move()
        {
            if (this.index < this.items.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext() => this.index + 1 < this.items.Count;

        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }
    }
}
