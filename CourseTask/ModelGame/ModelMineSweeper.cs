namespace ModelGame
{
    public class ModelMineSweeper
    {
        private CellsBoard cellBoard;

        //Задние параметром игры для модели
        public void SetParameterGame(int width, int height, int countMine)
        {
            cellBoard = new CellsBoard(width, height, countMine);
        }
   
        public void GetCoordinateFromUser(int x,)
        //Задание чисел вокруг мин
        //private void SetInitialValue()
        //{
        //    foreach (var cell in this)
        //    {
        //        if (cell.Type != TypeCell.Mine)
        //        {
        //            int count = 0;
        //            foreach (var mine in cell.aroundCell)
        //            {
        //                for (int i = 0; i < mineCells.Length; i++)
        //                {
        //                    if (mine.CompareTo(mineCells[i]) == 0)
        //                    {
        //                        count++;
        //                    }
        //                }
        //            }
        //            cell.Type = (TypeCell)count;
        //        }
        //    }
        //}

        //задание координат для мин
        //private void SetMineCoordinate()
        //{
        //    mineCells = new Cell[] {new Cell(2, 0), new Cell(6, 0), new Cell(6, 1), new Cell(8, 2),
        //                            new Cell(8, 3), new Cell(0, 5), new Cell(1, 5), new Cell(2, 5),
        //                            new Cell(0, 7), new Cell(7, 8) };
        //
        //    cells[2, 0].Type = TypeCell.Mine;
        //    cells[6, 0].Type = TypeCell.Mine;
        //    cells[6, 1].Type = TypeCell.Mine;
        //    cells[8, 2].Type = TypeCell.Mine;
        //    cells[7, 3].Type = TypeCell.Mine;
        //    cells[0, 5].Type = TypeCell.Mine;
        //    cells[1, 5].Type = TypeCell.Mine;
        //    cells[2, 5].Type = TypeCell.Mine;
        //    cells[0, 7].Type = TypeCell.Mine;
        //    cells[7, 8].Type = TypeCell.Mine;
        //
        //    //Random random = new Random();
        //    //int rangeCoordinate = width;
        //    //int rangeCells = cells.Length - 1;
        //    //
        //    //int randomCell = random.Next(0, rangeCells);
        //    //int x = random.Next(0, rangeCoordinate);
        //    //int y = random.Next(0, rangeCoordinate);
        //    //
        //    //for(int i = 0; i < countMine; i++)
        //    //{
        //    //    while(cells[randomCell].Type == TypeCell.Mine)
        //    //    {
        //    //        x = random.Next(0, rangeCoordinate);
        //    //        y = random.Next(0, rangeCoordinate);
        //    //        randomCell = random.Next(0, rangeCells);
        //    //    }
        //    //    cells[randomCell].Type = TypeCell.Mine;
        //    //}
        //}

        public override string ToString()
        {
            return cellBoard.ToString();
        }

        //public IEnumerator<Cell> GetEnumerator()
        //{
        //    int t = 0;
        //    for (int i = 0; i < height; i++)
        //    {
        //        for (int j = 0; j < width; j++)
        //        {
        //            yield return cells[j, i];
        //            t++;
        //        }
        //    }
        //}
        //
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
