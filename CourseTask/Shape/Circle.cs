using System;

namespace Shape
{
    class Circle : Shape, IShape
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

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetHeight()
        {
            return Diameter;
        }

        public override double GetPerimeter()
        {
            return Math.PI * Diameter;
        }

        public override double GetWidth()
        {
            return Diameter;
        }
    }
}
