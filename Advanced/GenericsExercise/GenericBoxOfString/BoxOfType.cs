namespace GenericBoxOfString
{
    using System.Runtime.InteropServices.ComTypes;

    public class BoxOfType<T>
    {
        private T value;

        public BoxOfType() { }

        public T Value
        {
            get => this.value;
            set => this.value = value;
        }
        public override string ToString() => $"{typeof(T)}: {this.value}";
    }
}
