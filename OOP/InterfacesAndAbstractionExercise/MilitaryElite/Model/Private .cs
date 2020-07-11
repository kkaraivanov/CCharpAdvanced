namespace MilitaryElite.Model
{
    using Interface;

    public class Private: Soldier
    {
        public override int Id { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public decimal Salary { get; set; }

        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
        }

        public override string ToString()
        {
            return base.DisplayInfo();
        }
    }
}