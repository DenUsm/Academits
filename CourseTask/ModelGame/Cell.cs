﻿namespace ModelGame
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOpened { get; set; }
        public bool IsFlagged { get; set; }
        public Type Type { get; set; }
        public Cell[] AroundCell { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Type
    {
        Mine = -1,
        Empty = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9
    }
}
