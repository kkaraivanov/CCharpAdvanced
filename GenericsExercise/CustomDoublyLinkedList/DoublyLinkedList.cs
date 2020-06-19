namespace CustomDoublyLinkedList
{
    using System;
    using System.Runtime.InteropServices;

    class DoublyLinkedList<T>
    {
        private CustomNode<T> head;
        private CustomNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newHead = new CustomNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new CustomNode<T>(element);

            if (this.Count == 0)
            {
                this.tail = this.head = newTail;
            }
            else
            {
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedElement = this.head.Value;
            var newHead = this.head.Next;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;
            return removedElement;
        }

        private T RemovLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var removedElement = this.tail.Value;
            var newTail = this.tail.Previous;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentItem = this.head;
            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentItem = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentItem.Value;
                currentItem = currentItem.Next;
            }

            return array;
        }
    }
}
