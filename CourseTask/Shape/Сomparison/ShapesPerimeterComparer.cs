﻿using System.Collections.Generic;

namespace Shape.Сomparison
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape firstFigure, IShape secondFigure)
        {
            return secondFigure.GetPerimeter().CompareTo(firstFigure.GetHeight());
        }
    }
}
