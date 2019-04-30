using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModelGame
{
    class CellsBoard : IEnumerable<Cell>
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CountMine { get; set; }
        public Cell[,] Cell { get; set; }

        public CellsBoard(int width, int height, int countMine)
        {
            Width = width;
            Height = height;
            CountMine = countMine;
            Cell = new Cell[Width, Height];
            InitializeCells();
        }

        //здние нчальных координт для кждой ячейки
        private void InitializeCells()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cell[j, i] = new Cell(j, i);
                    Cell[j, i].Type = Type.Empty;
                    Cell[j, i].AroundCell = GetCoordinateAround(j, i);
                }
            }
        }

        //получение координат ячеек вокруг текущей
        private Cell[] GetCoordinateAround(int x, int y)
        {
            List<Cell> list = new List<Cell>();

            //1 2 3
            //4 X 6
            //7 8 9

            //1
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                list.Add(new Cell(x - 1, y - 1));
            }
            //2
            if (y - 1 >= 0)
            {
                list.Add(new Cell(x, y - 1));
            }
            //3
            if (x + 1 < Width && y - 1 >= 0)
            {
                list.Add(new Cell(x + 1, y - 1));
            }
            //4
            if (x - 1 >= 0)
            {
                list.Add(new Cell(x - 1, y));
            }
            //6
            if (x + 1 < Width)
            {
                list.Add(new Cell(x + 1, y));
            }
            //7
            if (x - 1 >= 0 && y + 1 < Height)
            {
                list.Add(new Cell(x - 1, y + 1));
            }
            //8
            if (y + 1 < Height)
            {
                list.Add(new Cell(x, y + 1));
            }
            //9
            if (x + 1 < Width && y + 1 < Height)
            {
                list.Add(new Cell(x + 1, y + 1));
            }

            return list.ToArray();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            int interval = 2;

            str.Append("".PadLeft(interval, ' '));
            for (int i = 1; i <= Width; i++)
            {
                str.AppendFormat("{0}", i.ToString().PadLeft(interval + 1, ' '));
            }

            str.Append("\r\n");

            str.Append("".PadLeft(interval, ' '));
            for (int i = 0; i < (interval + 1) * Width + 1; i++)
            {
                str.Append("-");
            }

            str.Append("\r\n");

            for (int i = 1; i <= Height; i++)
            {
                str.AppendFormat("{0}|", i.ToString().PadLeft(interval, ' '));
                for (int j = 1; j <= Width; j++)
                {
                    str.AppendFormat("[{0}]", (int)Cell[j - 1, i - 1].Type);
                }
                str.Append("\r\n");
            }

            return str.ToString();
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            for (int i = 1; i <= Height; i++)
            {
                for (int j = 1; j <= Width; j++)
                {
                    yield return Cell[j, i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
