namespace Guild
{
    using System.Text;

    class Player
    {
        public string Name { get; private set; }

        public string Class { get; private set; }

        public string Rank { get; set; } = "Trial";

        public string Description { get; set; } = "n/a";

        public Player(string name, string clases)
        {
            this.Name = name;
            this.Class = clases;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
