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
    }
}
