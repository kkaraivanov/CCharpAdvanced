namespace BoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        private bool ValidateInputParameters(double value) => value <= 0;

        private string ArgumentMessage => "cannot be zero or negative.";

        private double Length
        {
            set
            {
                if (ValidateInputParameters(value))
                    throw new ArgumentException($"Length {ArgumentMessage}");

                length = value;
            }
        }
        private double Width
        {
            set
            {
                if (ValidateInputParameters(value))
                    throw new ArgumentException($"Width {ArgumentMessage}");

                width = value;
            }
        }

        private double Height
        {
            set
            {
                if (ValidateInputParameters(value))
                    throw new ArgumentException($"Height {ArgumentMessage}");

                height = value;
            }
        }

        public double SurfaceArea => (2 * length * width) + LateralSurfaceArea;

        public double LateralSurfaceArea => (2 * length * height) + (2 * width * height);

        public double Volume => length * width * height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}