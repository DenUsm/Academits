using System.Collections.Generic;

namespace Shape
{
    class ShapesComparerArea : IComparer<Shape>
    {
        public int Compare(Shape firstShape, Shape secondShape)
        {
            if(firstShape.GetArea() > secondShape.GetArea())
            {
                return -1;
            }
            else if(firstShape.GetArea() < secondShape.GetArea())
            {
                return 1;
            }
            return 0;
        }
    }
}
