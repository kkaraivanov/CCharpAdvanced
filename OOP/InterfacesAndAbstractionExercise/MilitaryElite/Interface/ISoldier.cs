namespace MilitaryElite.Interface
{
    public interface ISoldier
    {
        public abstract int Id { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string LastName { get; set; }
    }
}