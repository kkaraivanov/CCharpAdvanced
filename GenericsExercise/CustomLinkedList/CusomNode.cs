namespace CustomLinkedList
{
    class CustomNode<T>
    {
        private T element;
        private CustomNode<T> next;
        private CustomNode<T> previous;

        public CustomNode(T element)
        {
            this.element = element;
            this.next = null;
            this.previous = null;
        }

        public CustomNode(T element, CustomNode<T> prevNode)
        {
            this.element = element;
            this.previous = prevNode;
            prevNode.next = this;
        }

        public T Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public CustomNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public CustomNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}
