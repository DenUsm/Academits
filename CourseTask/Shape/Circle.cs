using System;

namespace Shape
{
    class Circle : IShape
    {
        public double Radius { get; set; }
        
        public double Diameter
        {
            get
            {
                return 2 * Radius;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetHeight()
        {
            return Diameter;
        }

        public double GetPerimeter()
        {
            return Math.PI * Diameter;
        }

        public double GetWidth()
        {
            return Diameter;
        }
    }
}
