namespace Shapes
{
    using System;

    public class Circle : IDrawable
    {
        private int radius; 
        private double thickness = 0.4;
        private char symbol = '*';

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            while (radius <= 0) ;

            Console.WriteLine();
            double rIn = radius - thickness;
            double rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}