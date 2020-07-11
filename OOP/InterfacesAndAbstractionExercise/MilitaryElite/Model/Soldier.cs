namespace MilitaryElite.Model
{
    using Interface;

    public abstract class Soldier : ISoldier
    {
        public abstract int Id { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string LastName { get; set; }

        public decimal Salary { get; set; }

        protected Soldier(int id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        protected virtual string DisplayInfo() => $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}