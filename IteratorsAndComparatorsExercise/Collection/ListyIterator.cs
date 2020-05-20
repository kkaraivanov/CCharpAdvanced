namespace Collection
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(params T[] items)
        {
            this.items = items.ToList();
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public string Print() => this.items.Count == 0 ? "Invalid Operation!" : $"{this.items[this.index]}";

        public string PrintAll() => string.Join(" ", this.items);

        public bool HasNext() => this.index + 1 < this.items.Count;

        public IEnumerator<T> GetEnumerator() => this.items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
