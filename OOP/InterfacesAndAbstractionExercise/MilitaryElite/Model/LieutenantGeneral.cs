namespace MilitaryElite.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Interface;

    public class LieutenantGeneral : Soldier, ILieutenantGeneral
    {
        private List<Private> solgers;
        public override int Id { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public decimal Salary { get; set; }

        public IReadOnlyCollection<Private> Solgers => solgers.AsReadOnly();

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

        protected override string DisplayInfo()
        {
            return $"{base.DisplayInfo()}{Environment.NewLine}" +
                   $"Privates:";
        }

        public override string ToString()
        {
            string result = DisplayInfo();
            if(solgers.Count > 0)
                result += $"{Environment.NewLine}" +
                          $"{string.Join(Environment.NewLine, Solgers.Select(x => $"   {x.ToString()}"))}";

            return result;
        }
    }
}