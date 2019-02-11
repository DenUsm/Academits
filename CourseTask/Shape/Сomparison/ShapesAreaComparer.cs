using System.Collections.Generic;

namespace Shape.Сomparison
{
    class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape firstFigure, IShape secondFigure)
        {
            return secondFigure.GetArea().CompareTo(firstFigure.GetArea());
        }
    }
}
