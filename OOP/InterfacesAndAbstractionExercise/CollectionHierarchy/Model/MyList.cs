namespace CollectionHierarchy.Model
{
    using Interface;

    public class MyList : AddRemoveCollection, IMyList
    {
        public override  string Remove()
        {
            string element = this.Colection[0];
            this.Colection.RemoveAt(0);

            return element;
        }

        public int Used => Colection.Count;

        public MyList()
            : base()
        {
        }
    }
}