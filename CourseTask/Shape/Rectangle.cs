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
    }
}
