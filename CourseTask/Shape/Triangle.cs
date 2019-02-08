using System;

namespace Shape
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

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

        public double GetHeigth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        private double [] GetSlideTriangle()
        {
            double firstSide = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double secondSide = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double thirdSide = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            return new double[] { firstSide, secondSide, thirdSide };
        }

        public double GetArea()
        {
            double[] slides = GetSlideTriangle();
            double halfPerimeter = (slides[0] + slides[1] + slides[2]) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - slides[0]) * (halfPerimeter - slides[1]) * (halfPerimeter - slides[2]));
        }

        public double GetPerimeter()
        {
            double[] slides = GetSlideTriangle();
            return slides[0] + slides[1] + slides[2];
        }
    }
}
