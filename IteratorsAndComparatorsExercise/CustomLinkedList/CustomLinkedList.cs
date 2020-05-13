namespace CustomLinkedList
{
    using System;

    public class CustomLinkedList<T> //: IEnumerable<T>
    {
        internal class Node
        {
            public Node(T element)
            {
                this.Element = element;
                this.NextNode = null;
            }

            public Node(T element, Node prevNode)
                : this(element)
            {
                prevNode.NextNode = this;
            }

            public T Element { get; set; }

            public Node NextNode { get; set; }
        }

        private Node head;
        private Node tail;
        private int count;

        public CustomLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count => this.count;

        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                var currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                return currentNode.Element;
            }

            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                var currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.Element = value;
            }
        }

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
                this.tail = this.head;
            }
            else
            {
                var newNode = new Node(item, this.tail);
                this.tail = newNode;
            }

            this.count++;
        }

        public T RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            int currentIndex = 0;
            var currentNode = this.head;
            Node prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            this.RemoveListNode(currentNode, prevNode);

            return currentNode.Element;
        }

        public int Remove(T item)
        {
            int currentIndex = 0;
            var currentNode = this.head;
            Node prevNode = null;
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    break;
                }

                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            if (currentNode != null)
            {
                RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }

            return -1;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    return index;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = index != -1;
            return found;
        }

        private void RemoveListNode(Node node, Node prevNode)
        {
            this.count--;
            if (count == 0)
            {
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                this.head = node.NextNode;
            }
            else
            {
                prevNode.NextNode = node.NextNode;
            }

            if (object.ReferenceEquals(this.tail, node))
            {
                this.tail = prevNode;
            }
        }
    }
}
