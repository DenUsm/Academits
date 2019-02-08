namespace Shape
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
    }
}
