namespace FootballTeamGenerator.PlayerModel
{
    using System;
    using Common;

    public class Player
    {
        private string name;
        private Stats stats;

        public string Name
        {
            get => name;
            private set
            {
                value.IsNullOrWhiteSpace();

                name = value;
            }
        }

        public Stats Stats { get; }

        public double Skill => Stats.AverageStat;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }
    }
}