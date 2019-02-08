using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Square res = new Square(6.25);
            Triangle res1 = new Triangle(1, 2, 5, 4, 5.5, 1.5);
            Rectangle res2 = new Rectangle(5, 10);
            Circle res3 = new Circle(3);

            Console.WriteLine(res1.FirstSlide + " " + res1.SecondSlide + " "  + res1.ThirdSlide);
            Console.WriteLine(res3.Diameter);

            Console.WriteLine(res.GetHeight());
            Console.WriteLine(res.GetWidth());
            Console.WriteLine(res.GetArea());
            Console.WriteLine(res.GetPerimeter());

            Console.WriteLine();

            Console.WriteLine(res1.GetHeight());
            Console.WriteLine(res1.GetWidth());
            Console.WriteLine(res1.GetArea());
            Console.WriteLine(res1.GetPerimeter());

            Console.WriteLine();

            Console.WriteLine(res2.GetHeight());
            Console.WriteLine(res2.GetWidth());
            Console.WriteLine(res2.GetArea());
            Console.WriteLine(res2.GetPerimeter());

            Console.WriteLine();

            Console.WriteLine(res3.GetHeight());
            Console.WriteLine(res3.GetWidth());
            Console.WriteLine(res3.GetArea());
            Console.WriteLine(res3.GetPerimeter());

            Console.ReadKey();
        }
    }
}
