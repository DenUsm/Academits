using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModelGame
{
    public class ModelMineSweeper : IEnumerable<Cell>
    {
        private Cell[,] cells;
        private int height;
        private int width;
        private int countMine;
        private Cell[] mineCells;

        public ModelMineSweeper(int height, int width, int countMine)
        {
            cells = new Cell[height, width];
            this.height = height;
            this.width = width;
            this.countMine = countMine;
            SetInitialCoordinate();
            SetMineCoordinate();
            SetInitialValue();
        }

        //Получение типа ячейки по координатам
        public int GetTypeCell(int x, int y)
        {
            return (int)cells[x - 1, y - 1].Type;
        }

        //Задание начальных координат
        private void SetInitialCoordinate()
        {
            int t = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[j, i] = new Cell(j, i, TypeCell.None);
                    cells[j, i].aroundCell = GetCoordinateAround(j, i);
                    t++;
                }
            }
        }

        //Задание чисел вокруг мин
        private void SetInitialValue()
        {
            foreach (var cell in this)
            {
                if (cell.Type != TypeCell.Mine)
                {
                    int count = 0;
                    foreach (var mine in cell.aroundCell)
                    {
                        for (int i = 0; i < mineCells.Length; i++)
                        {
                            if (mine.CompareTo(mineCells[i]) == 0)
                            {
                                count++;
                            }
                        }
                    }
                    cell.Type = (TypeCell)count;
                }
            }
        }

        //задание координат для мин
        private void SetMineCoordinate()
        {
            mineCells = new Cell[] {new Cell(2, 0), new Cell(6, 0), new Cell(6, 1), new Cell(8, 2),
                                    new Cell(8, 3), new Cell(0, 5), new Cell(1, 5), new Cell(2, 5),
                                    new Cell(0, 7), new Cell(7, 8) };

            cells[2, 0].Type = TypeCell.Mine;
            cells[6, 0].Type = TypeCell.Mine;
            cells[6, 1].Type = TypeCell.Mine;
            cells[8, 2].Type = TypeCell.Mine;
            cells[7, 3].Type = TypeCell.Mine;
            cells[0, 5].Type = TypeCell.Mine;
            cells[1, 5].Type = TypeCell.Mine;
            cells[2, 5].Type = TypeCell.Mine;
            cells[0, 7].Type = TypeCell.Mine;
            cells[7, 8].Type = TypeCell.Mine;

            //Random random = new Random();
            //int rangeCoordinate = width;
            //int rangeCells = cells.Length - 1;
            //
            //int randomCell = random.Next(0, rangeCells);
            //int x = random.Next(0, rangeCoordinate);
            //int y = random.Next(0, rangeCoordinate);
            //
            //for(int i = 0; i < countMine; i++)
            //{
            //    while(cells[randomCell].Type == TypeCell.Mine)
            //    {
            //        x = random.Next(0, rangeCoordinate);
            //        y = random.Next(0, rangeCoordinate);
            //        randomCell = random.Next(0, rangeCells);
            //    }
            //    cells[randomCell].Type = TypeCell.Mine;
            //}
        }

        //получение координат точек вокруг мины
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
            if (x + 1 < width && y - 1 >= 0)
            {
                list.Add(new Cell(x + 1, y - 1));
            }
            //4
            if (x - 1 >= 0)
            {
                list.Add(new Cell(x - 1, y));
            }
            //6
            if (x + 1 < width)
            {
                list.Add(new Cell(x + 1, y));
            }
            //7
            if (x - 1 >= 0 && y + 1 < height)
            {
                list.Add(new Cell(x - 1, y + 1));
            }
            //8
            if (y + 1 < height)
            {
                list.Add(new Cell(x, y + 1));
            }
            //9
            if (x + 1 < width && y + 1 < height)
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
                    str.AppendFormat("[{0}]", (int)cells[j - 1, i - 1].Type);
                }
                str.Append("\r\n");
            }

            return str.ToString();
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            int t = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    yield return cells[j, i];
                    t++;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
