﻿namespace Shape.Shapes
{
    class Rectangle : IShape
    {
        public double SideWidth { get; set; }
        public double SideHeight { get; set; }

        public Rectangle(double sideWidth, double sideHeight)
        {
            SideWidth = sideWidth;
            SideHeight = sideHeight;
        }

        public double GetWidth()
        {
            return SideWidth;
        }

        public double GetHeight()
        {
            return SideHeight;
        }

        public double GetArea()
        {
            return SideHeight * SideWidth;
        }

        public double GetPerimeter()
        {
            return 2 * (SideWidth + SideHeight);
        }

        public override string ToString()
        {
            return string.Format("Figure: {0}, Width: {1}, Height: {2}", GetType().Name, SideWidth, SideHeight);
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
            hash = prime * hash + SideWidth.GetHashCode();
            hash = prime * hash + SideHeight.GetHashCode();
            return hash;
        }
    }
}
