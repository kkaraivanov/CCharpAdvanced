namespace CarSalesman
{
    using System.Text;

    public class Car
    {
        public string Model { get;}

        public Engine Engine { get;}

        public int Weight { get; private set; }

        public string Color { get; private set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            bool weight = this.Weight == 0;

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine(weight ? $"  Weight: n/a" : $"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
