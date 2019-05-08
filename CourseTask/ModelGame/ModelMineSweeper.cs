﻿using System;

namespace ModelGame
{
    public class ModelMineSweeper
    {
        private CellsBoard cellBoard;
        private bool firstChoice = true;

        //Задние параметром игры для модели
        public void SetGameParameter(int width, int height, int countMine)
        {
            cellBoard = new CellsBoard(width, height, countMine);
        }

        //Открытие ячейки
        public void OpenCell(int x, int y)
        {
            x = x - 1;
            y = y - 1;

            if (firstChoice)
            {
                //задаем мины с учетом первого нажатия пользовтеля
                cellBoard.SetMineCoordinate(x, y);
                //задаем чиловые значения вокруг мин
                cellBoard.SetInitialValue();
                //устанавливаем флаг первого выбора ячйки
                firstChoice = false;
            }
            //Открывам ячейку
            cellBoard.OpenCell(x, y);
        }

        //Отметить ячейку флагом
        public void SetFlagCoordinate(int x, int y)
        {
            cellBoard.SetOrCancelFlag(x - 1, y - 1);
        }

        //получить статус игры
        public GameStatus GetStatusGame()
        {
            return cellBoard.Status;
        }

        //public string GetGameRule()
        //{
        //
        //}

        //public string GetHightScore()
        //{
        //
        //}
    }
}
