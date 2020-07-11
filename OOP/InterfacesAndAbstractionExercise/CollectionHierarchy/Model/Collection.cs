namespace CollectionHierarchy.Model
{
    using System.Collections.Generic;
    using Interface;

    public abstract class Collection : IAddColection
    {
        private List<string> colection;

        protected IList<string> Colection => colection;

        public abstract int Add(string element);

        public Collection()
        {
            this.colection = new List<string>();
        }
    }
}