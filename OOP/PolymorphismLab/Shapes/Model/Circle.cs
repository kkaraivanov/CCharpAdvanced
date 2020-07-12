namespace Shapes.Model
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get => radius; 
            set => radius = value;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}