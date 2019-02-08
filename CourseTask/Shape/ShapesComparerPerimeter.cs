using System.Collections.Generic;

namespace Shape
{
    class ShapesComparerPerimeter : IComparer<Shape>
    {
        public int Compare(Shape firstShape, Shape secondShape)
        {
            if(firstShape.GetPerimeter() > secondShape.GetPerimeter())
            {
                return -1;
            }
            else if(firstShape.GetPerimeter() < secondShape.GetPerimeter())
            {
                return 1;
            }
            return 0;
        }
    }
}
