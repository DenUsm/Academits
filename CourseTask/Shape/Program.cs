using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Square firstSquare = new Square(6.25);
            Triangle firstTriangle = new Triangle(1, 2, 5, 4, 5.5, 1.5);
            Rectangle firstRectangle = new Rectangle(5, 10);
            Circle firstCircle = new Circle(3);
            Square secondSquare = new Square(6.25);
            Triangle secondTriangle = new Triangle(1, 2, 5, 4, 5.5, 1.5);
            Rectangle secondRectangle = new Rectangle(5, 10);
            Circle secondCircle = new Circle(3);
            Square thirdSquare = new Square(6.25);
            Triangle thirdTriangle = new Triangle(1, 2, 5, 4, 5.5, 1.5);
            Rectangle thirdRectangle = new Rectangle(5, 10);

            Console.ReadKey();
        }
    }
}
