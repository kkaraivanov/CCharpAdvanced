namespace Shapes.Model
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get => height;
            private set => height = value;
        }

        public double Width
        {
            get => width;
            private set => width = value;
        }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Width + 2 * Height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}