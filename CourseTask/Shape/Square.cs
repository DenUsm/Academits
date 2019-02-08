using System;

namespace Shape
{
    class Square: IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double GetWidth()
        {
            return Side;
        }

        public double GetHeight()
        {
            return Side;
        }

        public double GetArea()
        {
            return Math.Pow(Side, 2);
        }

        public double GetPerimeter()
        {
            return 4 * Side;
        }
    }
}
