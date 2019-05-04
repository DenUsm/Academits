using System;

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
   
        public void GetFirstCoordinateFromUser(int x, int y)
        {
            //задаем мины с учетом первого нажатия пользовтеля
            cellBoard.SetMineCoordinate(x - 1, y - 1);
            //задаем чиловые значения вокруг мин
            cellBoard.SetInitialValue();
            //помечем ячейку как отмеченную
            cellBoard.Cell[x - 1, y - 1].IsOpened = true;

            if (cellBoard.Cell[x - 1, y - 1].Type == Type.Empty)
            {
                cellBoard.OpenAroundEmptyCells(x - 1, y - 1);
            }

            Console.WriteLine(cellBoard.ShowBoard());
        }

        public void GetCoordinateFromUser(int x, int y)
        {
            if(cellBoard.Cell[x - 1, y - 1].Type == Type.Mine)
            {
                cellBoard.OpenMineOnBoard();
                Console.WriteLine(cellBoard.ShowBoard());
                Console.WriteLine("GameOver");
                Console.ReadKey();
                return;
            }
            else
            {
                cellBoard.Cell[x - 1, y - 1].IsOpened = true;
                if (cellBoard.Cell[x - 1, y - 1].Type == Type.Empty)
                {
                    cellBoard.OpenAroundEmptyCells(x - 1, y - 1);
                }
                Console.WriteLine(cellBoard.ShowBoard());
            }            
        }

        public void SetFlagCoordinate(int x, int y)
        {
            if(cellBoard.Cell[x - 1, y - 1].IsFlagged)
            {
                cellBoard.Cell[x - 1, y - 1].IsFlagged = false;
            }
            else
            {
                cellBoard.Cell[x - 1, y - 1].IsFlagged = true;
            }
            Console.WriteLine(cellBoard.ShowBoard()); 
        }

        public void ShowSolved()
        {
            Console.WriteLine(cellBoard.ShowSolvedBoard());
        }
    }
}
