namespace MilitaryElite.Model
{
    using Interface;

    public class Private: Soldier, IPrivate
    {

        public decimal Salary { get; set; }

        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString() => $"{base.ToString()} Salary: {Salary:F2}";
    }
}