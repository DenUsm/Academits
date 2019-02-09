using System;

namespace Shape
{
    class Square: Shape, IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double GetWidth()
        {
            return Side;
        }

        public override double GetHeight()
        {
            return Side;
        }

        public override double GetArea()
        {
            return Math.Pow(Side, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
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
            Square s = (Square)obj;
            return Side == s.Side;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (int)Side;
            return hash;
        }
    }
}
