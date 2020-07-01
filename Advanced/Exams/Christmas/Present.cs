namespace Christmas
{
    public class Present
    {
        public string Name { get;}

        public double Weight { get;}

        public string Gender { get;}

        public Present(string name, double weight, string gender)
        {
            Name = name;
            Weight = weight;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Present {Name} ({Weight}) for a {Gender}";
        }
    }
}
