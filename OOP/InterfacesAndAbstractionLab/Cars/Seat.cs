namespace Cars
{
    using System.Text;

    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} {this.GetType().Name} {Model}");
            sb.AppendLine($"{Start()}");
            sb.AppendLine($"{Stop()}");

            return sb.ToString().TrimEnd();
        }
    }
}