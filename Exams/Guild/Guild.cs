namespace Guild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Guild
    {
        private List<Player> roster;

        private Player player(string name) => roster.FirstOrDefault(x => x.Name == name);

        public string Name { get;}

        public int Capacity { get;}

        public int Count => this.roster.Count;

        public bool RemovePlayer(string name)
        {
            if (this.roster.Contains(this.player(name)))
            {
                this.roster.Remove(this.player(name));
                return true;
            }

            return false;
        }

        public Player[] KickPlayersByClass(string clases)
        {
            Player[] player;
            player = this.roster.Where(x => x.Class == clases).ToArray();
            this.roster = this.roster.Where(x => x.Class != clases).ToList();
            return player;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            if (this.Count != 0)
                sb.Append(string.Join(Environment.NewLine, roster));

            return sb.ToString().TrimEnd();
        }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if(roster.All(x => x.Name != player.Name))
                this.roster.Add(player);
        }

        public void PromotePlayer(string name)
        {
            if (this.player(name).Rank != "Member")
            {
                this.player(name).Rank = "Member";
            }
        }
        
        public void DemotePlayer(string name)
        {
            if (this.player(name).Rank != "Trial")
            {
                this.player(name).Rank = "Trial";
            }
        }
    }
}
