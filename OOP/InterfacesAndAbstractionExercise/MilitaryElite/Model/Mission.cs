namespace MilitaryElite.Model
{
    using System;
    using Enumerator;
    using Interface;

    public class Mission : IMission
    {
        private Missions state;

        public string Name { get; }

        public string State
        {
            get => state.ToString();
            set
            {
                Missions state;

                if (!Enum.TryParse<Missions>(value, out state))
                {
                    throw new ArgumentException();
                }

                this.state = state;
            }
        }

        public Mission(string name, string state)
        {
            Name = name;
            State = state;
        }

        public void CompleteMission()
        {
            state = Missions.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}