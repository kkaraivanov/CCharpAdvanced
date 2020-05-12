namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SampleStack<T> : IEnumerable<T>
    {
        private T[] data;
        private int count;

        public SampleStack()
        {
            this.data = new T[count];
        }

        public SampleStack(params T[] elements)
            :this()
        {
            this.count = elements.Length;
            this.data = elements;
        }

        public int Count => this.count;

        public void Push(params T[] elements)
        {
            var temp = new List<T>(this.data);
            for (int i = 0; i < elements.Length; i++)
            {
                temp.Add(elements[i]);
            }

            this.count = temp.Count;
            this.data = temp.ToArray();
        }

        public void Pop()
        {
            var temp = new List<T>(this.data);
            if (count > 0)
            {
                temp.RemoveAt(this.count - 1);

                this.count = temp.Count;
                this.data = temp.ToArray();
            }
            else
                throw new InvalidOperationException("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Length - 1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
