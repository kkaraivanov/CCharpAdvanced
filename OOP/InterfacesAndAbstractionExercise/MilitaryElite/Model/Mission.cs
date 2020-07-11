namespace MilitaryElite.Model
{
    public class Mission
    {
        public string Name { get; }

        public string State { get; set; }

        public Mission(string name, string state)
        {
            Name = name;
            State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}