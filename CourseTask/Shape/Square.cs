namespace Shape
{
    class Square: IShape
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

        public double GetHeigth()
        {
            return Side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public double GetPerimeter()
        {
            return 4 * Side;
        }
    }
}
