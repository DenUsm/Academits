using System;
using System.Collections.Generic;
using System.Text;

namespace ModelGame
{
    public class Cells
    {
        private Cell[,] cells;
        private int height;
        private int width;
        private int countMine;
        private Cell[] mineCells;

        public Cells(int height, int width, int countMine)
        {
            cells = new Cell[height, width];
            this.height = height;
            this.width = width;
            this.countMine = countMine;
            SetInitialCoordinate();
            //SetMineCoordinate();
            //SetIntersection();
        }

        //получение индекса в массиве по координатам
        private int GetIndex(int x, int y)
        {
            int res = y * height - width - x;
            return res;
        }

        private void SetIntersection()
        {
            //Cell[] temp = GetCoordinateAround(mineCells[1]);
            //Cell[] temp1 = GetCoordinateAround(mineCells[2]);
            //
            //for (int i = 0; i < Math.Min(temp.Length, temp1.Length); i++)
            //{
            //    for(int j = 0; j < temp.Length; j++)
            //    {
            //        for(int t = 0; t < temp1.Length; t++)
            //        {
            //            if(temp[j].CompareTo(temp1[t]) == 0)
            //            {
            //                //cells[GetIndex(temp[j].X, temp[j].Y)].Type = "#";
            //            }
            //        }
            //    }
            //}
        }

        //получение координат точек вокруг мины
        //public Cell[] GetCoordinateAround(Cell cell)
        //{
        //    List<Cell> list = new List<Cell>();
        //
        //    int x = cell.X;
        //    int y = cell.Y;
        //
        //    //1 2 3
        //    //4 X 6
        //    //7 8 9
        //
        //    //1
        //    if(x - 1 >= 0 && y - 1 >= 0)
        //    {
        //        list.Add(new Cell(x - 1, y - 1));
        //    }
        //    //2
        //    if (y - 1 >= 0)
        //    {
        //        list.Add(new Cell(x, y - 1));
        //    }
        //    //3
        //    if (x + 1 < width && y - 1 >= 0)
        //    {
        //        list.Add(new Cell(x + 1, y - 1));
        //    }
        //    //4
        //    if (x - 1 >= 0)
        //    {
        //        list.Add(new Cell(x - 1, y));
        //    }
        //    //6
        //    if (x + 1 < width)
        //    {
        //        list.Add(new Cell(x + 1, y));
        //    }
        //    //7
        //    if (x - 1 >= 0 && y + 1 < height)
        //    {
        //        list.Add(new Cell(x - 1, y + 1));
        //    }
        //    //8
        //    if (y + 1 < height)
        //    {
        //        list.Add(new Cell(x, y + 1));
        //    }
        //    //9
        //    if (x + 1 < width && y + 1 < height)
        //    {
        //        list.Add(new Cell(x + 1, y + 1));
        //    }
        //
        //    return list.ToArray();
        //}

        //задание координат для каждой ячейки
        private void SetInitialCoordinate()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = new Cell(TypeCell.None);
                }
            }
        }

        //задание координат для мин
        private void SetMineCoordinate()
        {
            //mineCells = new Cell[] {new Cell(0, 2), new Cell(0, 6), new Cell(1, 6), new Cell(2, 8),
            //                        new Cell(3, 8), new Cell(5, 0), new Cell(5, 1), new Cell(5, 2),
            //                        new Cell(7, 0), new Cell(8, 7) };
            //
            //cells[2].Type = "*";
            //cells[6].Type = "*";
            //cells[15].Type = "*";
            //cells[26].Type = "*";
            //cells[35].Type = "*";
            //cells[45].Type = "*";
            //cells[46].Type = "*";
            //cells[47].Type = "*";
            //cells[63].Type = "*";
            //cells[79].Type = "*";

            //Random random = new Random();
            //int rangeCoordinate = width - 1;
            //int rangeCells = cells.Length - 1;
            //
            //int randomCell = random.Next(0, rangeCells);
            //int x = random.Next(0, rangeCoordinate);
            //int y = random.Next(0, rangeCoordinate);
            //
            //for(int i = 0; i < countMine; i++)
            //{
            //    while(cells[randomCell].Type.Equals("*"))
            //    {
            //        x = random.Next(0, rangeCoordinate);
            //        y = random.Next(0, rangeCoordinate);
            //        randomCell = random.Next(0, rangeCells);
            //    }
            //    cells[randomCell].Type = "*";
            //}
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            int t = 0;

            int interval = 2;

            str.Append("".PadLeft(interval, ' '));
            for (int i = 1; i <= width; i++)
            {
                str.AppendFormat("{0}", i.ToString().PadLeft(interval + 1, ' '));
            }

            str.Append("\r\n");

            str.Append("".PadLeft(interval, ' '));
            for (int i = 0; i < (interval + 1) * width + 1; i++)
            {
                str.Append("-");
            }

            str.Append("\r\n");

            for (int i = 1; i <= height; i++)
            {
                str.AppendFormat("{0}|", i.ToString().PadLeft(interval, ' '));
                for (int j = 1; j <= width; j++)
                {
                    str.AppendFormat("[{0}]", cells[i, j].Type);
                    t++;
                }
                str.Append("\r\n");
            }

            return str.ToString();
        }

    }
}
