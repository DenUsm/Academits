using System;

namespace ModelGame
{
    public class Cell : IComparable<Cell>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int type { get; set; }

        public Cell()
        {

        }

        public override string ToString()
        {
            return "1";
        }

        public int CompareTo(Cell other)
        {
            if(X == other.X && Y == other.Y)
            {
                return 0;
            }
            return 1;
        }
    }
}
