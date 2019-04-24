using System;

namespace ModelGame
{
    class Cell
    {
        private int x;
        private int y;
        private Cell[] aroundCells;
        private string type;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
