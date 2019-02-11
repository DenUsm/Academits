using System;
using Shape.Shapes;
using Shape.Сomparison;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Square shape1 = new Square(22.5);
            Rectangle shape2 = new Rectangle(35.2, 40);
            Triangle shape3 = new Triangle(1, 2, 4, 5, 5.5, 1.5);
            Circle shape4 = new Circle(10);
            Square shape5 = new Square(60);
            Rectangle shape6 = new Rectangle(15.2, 17);
            Triangle shape7 = new Triangle(1, 3, 5, 7, 5, 2);
            Circle shape8 = new Circle(20);
            Circle shape9 = new Circle(5);
            Square shape10 = new Square(17);
            Square shape11 = new Square(17);

            if (shape10.GetHashCode() == shape11.GetHashCode())
            {
                if (shape10.Equals(shape11))
                {
                    Console.WriteLine("Object is equals");
                }
            }
            else
            {
                Console.WriteLine("Object do not equals");
            }

            IShape[] shapes = new IShape[] { shape1, shape2, shape3, shape4, shape5, shape6, shape7, shape8, shape9, shape10 };

            foreach (IShape s in shapes)
            {
                Console.WriteLine("{0}", s.ToString());
            }

            IShape maxFigureArea = GetShapeArea(shapes);
            IShape seconMaxPerimeter = GetShapePerimeter(shapes);

            Console.WriteLine();
            Console.WriteLine("Figure have max area {0}", maxFigureArea.ToString());
            Console.WriteLine("Figure have second max perimeter {0}", seconMaxPerimeter.ToString());

            Console.ReadKey();
        }

        public static IShape GetShapeArea(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());
            return shapes[0];
        }

        public static IShape GetShapePerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimeterComparer());
            return shapes[1];
        }
    }
}
