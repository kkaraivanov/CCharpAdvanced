namespace BoxOfT
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
    {
        public Stack<T> Item { get; private set; }

        public int Capacity { get; }

        public int Count => this.Item.Count;

        public Box()
        {
            this.Item = new Stack<T>();
        }

        public void Add(T element)
        {
            this.Item.Push(element);
        }

        public T Remove() => this.Item.Pop();
    }
}
