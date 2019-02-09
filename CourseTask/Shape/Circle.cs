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

        public override string ToString()
        {
            return string.Format("Shape: {0}, Width: {1}, Height: {2}, Area: {3}, Perimeter: {4}", GetType().Name, GetWidth(), GetHeight(), GetArea(), GetPerimeter());
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
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (int)Radius;
            return hash;
        }
    }
}
