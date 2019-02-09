namespace Shape
{
    class Rectangle : Shape, IShape
    {
        public double SideWidth { get; set; }
        public double SideHeight { get; set; }

        public Rectangle(double sideWidth, double sideHeight)
        {
            SideWidth = sideWidth;
            SideHeight = sideHeight;
        }

        public override double GetWidth()
        {
            return SideWidth;
        }

        public override double GetHeight()
        {
            return SideHeight;
        }

        public override double GetArea()
        {
            return SideHeight * SideWidth;
        }

        public override double GetPerimeter()
        {
            return 2 * (SideWidth + SideHeight);
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
            Rectangle r = (Rectangle)obj;
            return (SideHeight == r.SideHeight) && (SideWidth == r.SideWidth);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (int)SideWidth;
            hash = prime * hash + (int)SideHeight;
            return hash;
        }
    }
}
