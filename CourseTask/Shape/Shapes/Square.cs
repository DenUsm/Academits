using System;

namespace Shape.Shapes
{
    class Square : IShape
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

        public override string ToString()
        {
            return string.Format("Side: {0}", Side);
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
            return Side.GetHashCode();
        }

    }
}
