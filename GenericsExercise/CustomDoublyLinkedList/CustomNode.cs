namespace CustomDoublyLinkedList
{
    class CustomNode<T>
    {
        public CustomNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public CustomNode<T> Next { get; set; }

        public CustomNode<T> Previous { get; set; }
    }
}
