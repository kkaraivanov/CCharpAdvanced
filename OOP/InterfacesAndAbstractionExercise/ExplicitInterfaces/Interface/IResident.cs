namespace ExplicitInterfaces.Interface
{
    public interface IResident
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string GetName();
    }
}