namespace CustomLinkedList
{
    using System;

    public class CustomLinkedList<T>
    {
        private CustomNode<T> head;
        private CustomNode<T> tail;
        private int count;

        private bool IndexIsOutOfRange(int index) => this.count <= index || index < 0;

        public int Count => this.count;

        public T this[int index]
        {
            get
            {
                if (this.IndexIsOutOfRange(index))
                {
                    throw new ArgumentOutOfRangeException("Index out of range!");
                }

                var currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Element;
            }
            set
            {
                if (this.IndexIsOutOfRange(index))
                {
                    throw new ArgumentOutOfRangeException("Index out of range!");
                }

                var currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Element = value;
            }
        }

        public CustomLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void AddFirst(T item)
        {
            if (this.head == null)
            {
                this.head = new CustomNode<T>(item);
                this.tail = this.head;
            }
            else
            {
                var newItem = new CustomNode<T>(item, tail);
                this.tail = newItem;
            }

            count++;
        }

        public void AddLast(T item)
        {
            Insert(item, count);
        }

        public void Insert(T item, int index)
        {
            if (index >= ++count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            count++;
            var newItem = new CustomNode<T>(item);
            int currentIndex = 0;
            var currentItem = this.head;
            CustomNode<T> prevItem = null;

            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }

            if (index == 0)
            {
                newItem.Previous = this.head.Previous;
                newItem.Next = this.head;
                this.head.Previous = newItem;
                this.head = newItem;
            }
            else if (index == count - 1)
            {
                newItem.Previous = this.tail;
                this.tail.Next = newItem;
                newItem = this.tail;
            }
            else
            {
                newItem.Next = prevItem.Next;
                prevItem.Next = newItem;
                newItem.Previous = currentItem.Previous;
                currentItem.Previous = newItem;
            }
        }

        public void RemoveFirst(T item)
        {
            int currentIndex = 0;
            var currentItem = this.head;
            CustomNode<T> prevItem = null;

            while (currentItem != null)
            {
                if ((currentItem.Element != null &&
                     currentItem.Element.Equals(item)) ||
                    (currentItem.Element == null) && (item == null))
                {
                    break;
                }

                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }

            if (currentItem != null)
            {
                count--;
                if (count == 0)
                {
                    this.head = null;
                }
                else if (prevItem == null)
                {
                    this.head = currentItem.Next;
                    this.head.Previous = null;
                }
                else if (currentItem == tail)
                {
                    currentItem.Previous.Next = null;
                    this.tail = currentItem.Previous;
                }
                else
                {
                    currentItem.Previous.Next = currentItem.Next;
                    currentItem.Next.Previous = currentItem.Previous;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (this.IndexIsOutOfRange(index))
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            int currentIndex = 0;
            var currentItem = this.head;
            CustomNode<T> prevItem = null;

            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }

            if (this.count == 0)
            {
                this.head = null;
            }
            else if (prevItem == null)
            {
                this.head = currentItem.Next;
                this.head.Previous = null;
            }
            else if (index == count - 1)
            {
                prevItem.Next = currentItem.Next;
                tail = prevItem;
                currentItem = null;
            }
            else
            {
                prevItem.Next = currentItem.Next;
                currentItem.Next.Previous = prevItem;
            }

            count--;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var currentItem = this.head;

            while (currentItem != null)
            {
                if (((currentItem.Element != null) && (object.Equals(item, currentItem.Element))) ||
                    ((currentItem.Element == null) && (item == null)))
                {
                    return index;
                }
                index++;
                currentItem = currentItem.Next;
            }

            return -1;
        }

        public bool Contains(T element)
        {
            int index = IndexOf(element);
            bool contains = (index != -1);

            return contains;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
    }
}
