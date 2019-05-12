using System;
using System.Timers;

namespace ModelGame
{
    public class ModelMineSweeper
    {
        public CellsBoard cellBoard;
        private bool firstChoice;
        public int Time { get; private set; }
        private Timer timer;

        //Задние параметром игры для модели
        public void SetGameParameter(int width, int height, int countMine)
        {
            cellBoard = new CellsBoard(width, height, countMine);
            firstChoice = true;
            Time = 0;
            //создние таймер с интрвалом 1 секунда
            timer = new Timer(1000);
            // устанавливаем события обратного вызова таймера
            timer.Elapsed += new ElapsedEventHandler(Tick);
        }

        //Функция обратного вызова таймера
        private void Tick(object sender, ElapsedEventArgs e)
        {
            Time++;
        }

        //Отановка игрового таймера
        public void StopTimer()
        {
            timer.Stop();
            timer.Dispose();
        }

        //Открытие ячейки
        public void OpenCell(int x, int y)
        {
            if (firstChoice)
            {
                //задаем мины с учетом первого нажатия пользовтеля
                cellBoard.SetMineCoordinate(x, y);
                //задаем чиловые значения вокруг мин
                cellBoard.SetInitialValue();
                //устанавливаем флаг первого выбора ячйки
                firstChoice = false;
                timer.Start();
            }
            //Открывам ячейку
            cellBoard.OpenCell(x, y);

            if (cellBoard.Status != GameStatus.InPogress)
            {
                StopTimer();
            }
        }

        //Отметить ячейку флагом
        public void SetFlagCoordinate(int x, int y)
        {
            cellBoard.SetOrCancelFlag(x, y);
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
