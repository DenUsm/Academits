using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ModelGame
{
    public class CellsBoard : IEnumerable<Cell>
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CountMine { get; set; }
        public Cell[,] Cells { get; set; }
        private Cell[] mineCells;
        public GameStatus Status { get; set; }

        public CellsBoard(int width, int height, int countMine)
        {
            Width = width;
            Height = height;
            CountMine = countMine;
            Cells = new Cell[Width, Height];
            mineCells = new Cell[countMine];
            Status = GameStatus.InPogress;
            InitializeCells();
        }

        //задние нчальных координт для кждой ячейки
        private void InitializeCells()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells[j, i] = new Cell(j, i);
                    Cells[j, i].Type = Type.Empty;
                }
            }
        }

        //получение списка ячеек вокруг текущий
        private List<Cell> GetCoordinateAround(int x, int y)
        {
            var listCellsAround = new List<Cell>();

            //1 2 3
            //4 X 6
            //7 8 9

            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        continue;
                    }

                    if ((j >= 0 && j < Width) && (i >= 0 && i < Height))
                    {
                        listCellsAround.Add(Cells[j, i]);
                    }
                }
            }

            return listCellsAround;
        }

        //задание координат для мин с учетом координат первого нажатия
        public void SetMineCoordinate(int firstX, int firstY)
        {
            Random random = new Random();

            int x = random.Next(0, Width - 1);
            int y = random.Next(0, Height - 1);

            for (int i = 0; i < CountMine; i++)
            {
                while (Cells[x, y].Type == Type.Mine || (x == firstX && y == firstY))
                {
                    x = random.Next(0, Width - 1);
                    y = random.Next(0, Height - 1);
                }
                Cells[x, y].Type = Type.Mine;
                mineCells[i] = Cells[x, y];
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
                            if (mine.Compare(mineCells[i]))
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
        private void OpenMineOnBoard()
        {
            foreach (var cell in this)
            {
                if (cell.Type == Type.Mine)
                {
                    cell.IsOpened = true;
                }
            }
        }

        //Функция открытия соседних пустых ячеек
        public void OpenAroundEmptyCells(int x, int y)
        {
            Stack<Cell> stack = new Stack<Cell>();
            stack.Push(Cells[x, y]);

            while (stack.Count != 0)
            {
                Cell cell = stack.Pop();

                if (cell.Type == Type.Empty && !cell.IsOpened)
                {
                    cell.IsOpened = true;
                }

                var aroundCells = GetCoordinateAround(cell.X, cell.Y);
                foreach (var around in aroundCells)
                {
                    if (around.Type == Type.Empty && !around.IsOpened)
                    {
                        stack.Push(Cells[around.X, around.Y]);
                    }
                    else if (around.Type != Type.Mine && !around.IsOpened)
                    {
                        around.IsOpened = true;
                    }
                }
            }
        }

        //отмтить ячейку флагом
        public void SetOrCancelFlag(int x, int y)
        {
            if (Cells[x, y].IsFlagged)
            {
                Cells[x, y].IsFlagged = false;
            }
            else
            {
                Cells[x, y].IsFlagged = true;
                CheckStatus();
            }
        }

        //открыть ячейку
        public void OpenCell(int x, int y)
        {
            if (!Cells[x, y].IsOpened)
            {
                if (Cells[x, y].Type == Type.Mine)
                {
                    OpenMineOnBoard();
                    Status = GameStatus.GameOver;
                }
                else if (Cells[x, y].Type == Type.Empty)
                {
                    OpenAroundEmptyCells(x, y);
                }
                else
                {
                    Cells[x, y].IsOpened = true;
                    CheckStatus();
                }
            }
        }

        //проврка статуса игры
        private void CheckStatus()
        {
            int count = 0;
            foreach (var cell in this)
            {
                if (cell.Type == Type.Mine && cell.IsFlagged)
                {
                    count++;
                }
                else
                {
                    Status = GameStatus.InPogress;
                }
            }

            if (count == CountMine)
            {
                Status = GameStatus.Win;

            }
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    yield return Cells[j, i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
