using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Square(22.5);
            Shape shape2 = new Rectangle(35.2, 40);
            Shape shape3 = new Triangle(1, 2, 4, 5, 5.5, 1.5);
            Shape shape4 = new Circle(10);
            Shape shape5 = new Square(60);
            Shape shape6 = new Rectangle(15.2, 17);
            Shape shape7 = new Triangle(1, 3, 5, 7, 5, 2);
            Shape shape8 = new Circle(20);
            Shape shape9 = new Circle(5);
            Shape shape10 = new Square(17);

            Shape[] massShapes = new Shape[] { shape1, shape2, shape3, shape4, shape5, shape6, shape7, shape8, shape9, shape10 };

            GetMaxShapeArea(massShapes);

            Console.ReadKey();
        }

        public static void GetMaxShapeArea(Shape [] mass)
        {
            Array.Sort(mass, new ShapesComparerArea());
            Console.WriteLine("Shape: {0}, Width: {1}, Height: {2}, Area: {3}, Perimeter: {4}", mass[0].GetType().Name, mass[0].GetWidth(), mass[0].GetHeight(), mass[0].GetArea(), mass[0].GetPerimeter());
        }
    }
}
