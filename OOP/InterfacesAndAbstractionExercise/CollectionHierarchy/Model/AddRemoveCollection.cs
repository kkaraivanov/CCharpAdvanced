namespace CollectionHierarchy.Model
{
    using Interface;

    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public override int Add(string element)
        {
            Colection.Insert(0, element);

            return 0;
        }

        public virtual string Remove()
        {
            string element = Colection[Colection.Count - 1];
            Colection.RemoveAt(Colection.Count - 1);

            return element;
        }

        public AddRemoveCollection()
            : base()
        {
        }
    }
}