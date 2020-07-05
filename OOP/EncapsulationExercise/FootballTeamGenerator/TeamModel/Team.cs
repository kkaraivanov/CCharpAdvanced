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

        public string Name 
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException(GlobalConstants.InvalidNameExceptionMessage);

                name = value;
            }
        }

        public int Rating => players.Count == 0 ? 0 : (int)Math.Round(players.Sum(x => x.Skill) / players.Count);

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
            if(player == null)
                throw new InvalidOperationException(string.Format(GlobalConstants.InvalidRemoveMissingPlayerMessage, playerName, Name));

            players.Remove(player);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}