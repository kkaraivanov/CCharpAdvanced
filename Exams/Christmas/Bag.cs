namespace Christmas
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private readonly List<Present> data;

        public string Color { get;}

        public int Capacity { get;}

        public int Count => data.Count;

        public bool Remove(string name) => data.Remove(GetPresent(name));

        public Present GetHeaviestPresent() => data.OrderByDescending(x => x.Weight).FirstOrDefault();

        public Present GetPresent(string name) => data.FirstOrDefault(x => x.Name == name);

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public void Add(Present present)
        {
            if(Count < Capacity)
                data.Add(present);
        }
    }
}
