namespace CollectionHierarchy.Model
{
    public class AddCollection : Collection
    {
        public override int Add(string element)
        {
            this.Colection.Add(element);

            return this.Colection.Count - 1;
        }

        public AddCollection()
            : base()
        {

        }
    }
}