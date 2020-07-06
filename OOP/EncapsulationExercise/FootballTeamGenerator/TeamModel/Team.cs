namespace FootballTeamGenerator.TeamModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using PlayerModel;

    public class Team
    {
        private readonly List<Player> players;
        private string name;

        private int AveragePlayersSkill => (int)Math.Round(players.Sum(x => x.Skill) / players.Count);

        public string Name 
        {
            get => name;
            private set
            {
                value.IsNullOrWhiteSpace();
                name = value;
            }
        }

        public int Rating => players.Count == 0 ? 0 : AveragePlayersSkill;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            player.IsValidPlayer(playerName, Name);
            players.Remove(player);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}