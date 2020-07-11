namespace MilitaryElite.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public override int Id { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public override string Corp { get; }

        public IList<Repair> Repairs => repairs.AsReadOnly();

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp, Repair[] repears) 
            : base(id, firstName, lastName, salary, corp)
        {
            Corp = corp;
            this.repairs = new List<Repair>();
            AddRepear(repears);
        }

        private void AddRepear(Repair[] repears)
        {
            foreach (var repear in repears)
            {
                this.repairs.Add(repear);
            }
        }

        protected override string DisplayInfo()
        {
            return $"{base.DisplayInfo()}{Environment.NewLine}" +
                   $"Repairs:";
        }

        public override string ToString()
        {
            string result = DisplayInfo();
            if (repairs.Count > 0)
                result += $"{Environment.NewLine}" +
                          $"{string.Join(Environment.NewLine, repairs.Select(x => $"  {x.ToString()}"))}";

            return result;
        }
    }
}