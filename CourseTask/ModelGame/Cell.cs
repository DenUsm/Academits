using System;

namespace ModelGame
{
    public class Cell : IComparable<Cell>
    {
        public TypeCell Type { get; set; }

        public Cell(TypeCell type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", Type);
        }

        public int CompareTo(Cell other)
        {
            if(Type == other.Type)
            {
                return 0;
            }
            return 1;
        }
    }

    public enum TypeCell
    {
        Mine = -1,
        None = 0,
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
