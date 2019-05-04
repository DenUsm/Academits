using System;
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
        private Cell[] mineCells;

        public CellsBoard(int width, int height, int countMine)
        {
            Width = width;
            Height = height;
            CountMine = countMine;
            Cell = new Cell[Width, Height];
            mineCells = new Cell[countMine];
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
                }
            }
        }

        //получение списка ячеек вокруг текущий
        private Cell[] GetCoordinateAround(int x, int y)
        {
            List<Cell> list = new List<Cell>();

            //1 2 3
            //4 X 6
            //7 8 9

            //1
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                list.Add(Cell[x - 1, y - 1]);
            }
            //2
            if (y - 1 >= 0)
            {
                list.Add(Cell[x, y - 1]);
            }
            //3
            if (x + 1 < Width && y - 1 >= 0)
            {
                list.Add(Cell[x + 1, y - 1]);
            }
            //4
            if (x - 1 >= 0)
            {
                list.Add(Cell[x - 1, y]);
            }
            //6
            if (x + 1 < Width)
            {
                list.Add(Cell[x + 1, y]);
            }
            //7
            if (x - 1 >= 0 && y + 1 < Height)
            {
                list.Add(Cell[x - 1, y + 1]);
            }
            //8
            if (y + 1 < Height)
            {
                list.Add(Cell[x, y + 1]);
            }
            //9
            if (x + 1 < Width && y + 1 < Height)
            {
                list.Add(Cell[x + 1, y + 1]);
            }

            return list.ToArray();
        }

        //задание координат для мин с учетом координат первого нажатия
        public void SetMineCoordinate(int firstX, int firstY)
        {
            Random random = new Random();
            int rangeCoordinate = Width;

            int x = random.Next(0, rangeCoordinate);
            int y = random.Next(0, rangeCoordinate);

            for (int i = 0; i < CountMine; i++)
            {
                while (Cell[x, y].Type == Type.Mine || (x == firstX && y == firstY))
                {
                    x = random.Next(0, rangeCoordinate);
                    y = random.Next(0, rangeCoordinate);
                }
                Cell[x, y].Type = Type.Mine;
                mineCells[i] = Cell[x, y];
            }
        }

        //Задание чисел вокруг мин
        public void SetInitialValue()
        {
            foreach (var cell in this)
            {
                if (cell.Type != Type.Mine)
                {
                    int count = 0;
                    foreach (var mine in GetCoordinateAround(cell.X, cell.Y))
                    {
                        for (int i = 0; i < mineCells.Length; i++)
                        {
                            if (mine.CompareTo(mineCells[i]) == 0)
                            {
                                count++;
                            }
                        }
                    }
                    cell.Type = (Type)count;
                }
            }
        }

        //Функция открытия всех мин на карте
        public void OpenMineOnBoard()
        {
           foreach(var cell in this)
           {
                if(cell.Type == Type.Mine)
                {
                    cell.IsOpened = true;
                }
           }
        }

        //Функция открытия соседних пустых ячеек
        public void OpenAroundEmptyCells(int x, int y)
        {
            Stack<Cell> stack = new Stack<Cell>();
            stack.Push(Cell[x, y]);

            while(stack.Count != 0)
            {
                Cell cell = stack.Pop();

                if(cell.Type == Type.Empty && !cell.IsOpened)
                {
                    cell.IsOpened = true;
                }

                Cell[] aroundCells = GetCoordinateAround(cell.X, cell.Y);
                foreach (var around in aroundCells)
                {
                    if (around.Type == Type.Empty && !around.IsOpened)
                    {
                        stack.Push(Cell[around.X, around.Y]);
                    }
                    else if(around.Type != Type.Mine && !around.IsOpened)
                    {
                        around.IsOpened = true;
                    }
                }
            }
        }




        public string ShowSolvedBoard()
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
                    int res = (int)Cell[j - 1, i - 1].Type;
                    str.AppendFormat("[{0}]", (res == -1) ? "*" : res.ToString());
                }
                str.Append("\r\n");
            }
            return str.ToString();
        }

        public string ShowBoard()
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
                    str.Append(UpdateCellBoard(j - 1, i - 1));
                }
                str.Append("\r\n");
            }

            return str.ToString();
        }

        private string UpdateCellBoard(int x, int y)
        {
            StringBuilder str = new StringBuilder();
            if (Cell[x, y].IsOpened)
            {
                int res = (int)Cell[x, y].Type;
                str.AppendFormat("[{0}]", (res == -1) ? "*" : res.ToString());
            }
            else if(Cell[x, y].IsFlagged)
            {
                str.AppendFormat("[{0}]", "@");
            }
            else
            {
                str.AppendFormat("[{0}]", " ");
            }
            return str.ToString();
        }



        public IEnumerator<Cell> GetEnumerator()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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

    public enum GameStatus
    {
        InPogress = 0,
        GameOver = 1,
        Win = 2
    }
}
