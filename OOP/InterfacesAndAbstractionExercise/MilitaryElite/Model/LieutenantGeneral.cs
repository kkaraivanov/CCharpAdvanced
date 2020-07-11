namespace MilitaryElite.Model
{
    using System.Collections.Generic;
    using System.Text;
    using Interface;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> solgers;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public IReadOnlyCollection<Private> Solgers => solgers;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Private[] solgers) 
            : base(id, firstName, lastName, salary)
        {
            this.solgers = new List<Private>();
            AddSolger(solgers);
        }

        private void AddSolger(Private[] solgers)
        {
            foreach (var soldier in solgers)
            {
                this.solgers.Add(soldier);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var current in solgers)
            {
                sb.AppendLine("  " + current.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}