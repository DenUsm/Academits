using System;

namespace ModelGame
{
    public class Cell : IComparable<Cell>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cell[] aroundCell { get; set; }

        public TypeCell Type { get; set; }

        public Cell(int x, int y, TypeCell type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", Type);
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

    public enum TypeCell
    {
        Nine = -1,
        None = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Mine = 7,
        Eight = 8,
        Seven = 9
    }
}
