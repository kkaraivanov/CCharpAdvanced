namespace MilitaryElite.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interface;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public override string Corp { get; }

        public IReadOnlyCollection<Repair> Repairs => repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp, Repair[] repears) 
            : base(id, firstName, lastName, salary, corp)
        {
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}