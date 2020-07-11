namespace MilitaryElite.Model
{
    using Interface;

    public class Repair : IRepair
    {
        public string Name { get;}

        public int HoursWorked { get;}

        public Repair(string name, int hours)
        {
            Name = name;
            HoursWorked = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {HoursWorked}";
        }
    }
}