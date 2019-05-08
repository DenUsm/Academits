using System;

namespace ModelGame
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOpened { get; set; }
        public bool IsFlagged { get; set; }
        public Type Type { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Compare(Cell other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
