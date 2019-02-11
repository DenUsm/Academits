using System;

namespace Shape.Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

        public double Side1
        {
            get
            {
                return GetSideLength(X2, X1, Y2, Y1);
            }
        }

        public double Side2
        {
            get
            {
                return GetSideLength(X3, X2, Y3, Y2);
            }
        }

        public double Side3
        {
            get
            {
                return GetSideLength(X3, X1, Y3, Y1);
            }
        }

        private double GetSideLength(double coordinate1, double coordinate2, double coordinate3, double coordinate4)
        {
            return Math.Sqrt(Math.Pow(coordinate1 - coordinate2, 2) + Math.Pow(coordinate3 - coordinate4, 2));
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3));
        }

        public double GetPerimeter()
        {
            return Side1 + Side2 + Side3;
        }

        public override string ToString()
        {
            return string.Format("Figure: {0}, X1: {1}, Y1: {2}, X2: {3}, Y2: {4}, X3: {5}, Y3: {6}", GetType().Name, X1, Y1, X2, Y2, X3, Y3);
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
            Triangle t = (Triangle)obj;
            return (X1 == t.X1) && (Y1 == t.Y1) && (X2 == t.X2) && (Y2 == t.Y2) && (X3 == t.X3) && (Y3 == t.Y3);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();
            return hash;
        }
    }
}
