namespace GenericScale
{
    using System;

    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T AreEqual() => 
            this.left.CompareTo(this.right) > 0 ? this.left :
            this.right.CompareTo(this.left) > 0 ? this.right : 
            default(T);
    }
}
