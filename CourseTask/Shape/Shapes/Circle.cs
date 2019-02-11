using System;

namespace Shape.Shapes
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public double Diameter => 2 * Radius;

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

        public override string ToString()
        {
            return string.Format("Figure: {0}, Radius: {1}, Diameter: {2}", GetType().Name, Radius, Diameter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }
            Circle c = (Circle)obj;
            return Radius == c.Radius;
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}
