namespace MilitaryElite.Model
{
    using System.Collections.Generic;
    using System.Text;
    using Interface;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public override string Corp { get; }

        public IReadOnlyCollection<Mission> Missions => missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            this.missions = new List<Mission>();
        }

        public Commando(int id, string firstName, string lastName, decimal salary, string corp, Mission[] missions) 
            : this(id, firstName, lastName, salary, corp)
        {
            AddMission(missions);
        }

        private void AddMission(Mission[] missions)
        {
            foreach (var mission in missions)
            {
                this.missions.Add(mission);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            missions.ForEach(m => sb.AppendLine($"  {m.ToString()}"));

            return sb.ToString().TrimEnd();
        }
    }
}