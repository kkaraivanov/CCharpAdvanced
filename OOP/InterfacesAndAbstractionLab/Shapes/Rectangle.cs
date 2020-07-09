namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            string s = "";
            string space = "";

            for (int i = 1; i <= width; i++)
            {
                if(i % 2 != 0)
                    space += " ";
                s += "*";
            }

            s += "\n";
            for (int i = 2; i < height; i++)
                s += "*" + space + "*" + "\n";

            for (int i = 0; i < width; i++)
                s += "*";

            Console.Write(s);
            Console.ResetColor();
        }
    }
}