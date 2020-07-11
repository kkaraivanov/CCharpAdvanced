namespace MilitaryElite.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public override int Id { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public override string Corp { get; }

        public IList<Mission> Missions { get; }

        public Commando(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            Corp = corp;
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

        protected override string DisplayInfo()
        {
            return $"{base.DisplayInfo()}{Environment.NewLine}" +
                   $"Missions:";
        }

        public override string ToString()
        {
            string result = DisplayInfo();
            if (missions.Count > 0)
                result += $"{Environment.NewLine}" +
                          $"{string.Join(Environment.NewLine, missions.Where(x => x.State.ToLower() == "inprogress").Select(x => $"  {x.ToString()}"))}";

            return result;
        }
    }
}