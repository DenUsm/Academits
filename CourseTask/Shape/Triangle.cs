using System;

namespace Shape
{
    class Triangle : Shape, IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }

        public double FirstSlide
        {
            get
            {
                return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            }
        }

        public double SecondSlide
        {
            get
            {
                return Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            }
        }

        public double ThirdSlide
        {
            get
            {
                return Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            }
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

        public override double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public override double GetHeight()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public override double GetArea()
        {
            double halfPerimeter = (FirstSlide + SecondSlide + ThirdSlide) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - FirstSlide) * (halfPerimeter - SecondSlide) * (halfPerimeter - ThirdSlide));
        }

        public override double GetPerimeter()
        {
            return FirstSlide + SecondSlide + ThirdSlide;
        }
    }
}
