using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Square res = new Square(6.25);
            Triangle res1 = new Triangle(1, 2, 5, 4, 5.5, 1.5);

            Console.WriteLine(res.GetHeigth());
            Console.WriteLine(res.GetWidth());
            Console.WriteLine(res.GetArea());
            Console.WriteLine(res.GetPerimeter());

            Console.WriteLine();

            Console.WriteLine(res1.GetHeigth());
            Console.WriteLine(res1.GetWidth());
            Console.WriteLine(res1.GetArea());
            Console.WriteLine(res1.GetPerimeter());

            Console.ReadKey();
        }
    }
}
