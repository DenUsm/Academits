using System;
using ModelGame;

namespace ViewInterface
{
    public interface IMineSweeperView
    {
        //Координата ячейки
        int X { get; }

        int Y { get; }

        //уровень игры
        Level Level { get; }
        
        //параметры игры
        int WidthGame { set; }

        int HeightGame { set; }

        int MineCount { set; }

        //время игры
        int Time { set; }

        //Событие новавя игра
        event EventHandler<EventArgs> NewGame;

        //Событие выбора сложности
        event EventHandler<EventArgs> ChoosenLevel;

        //Событие правила игры
        event EventHandler<EventArgs> Rule;

        //Cобытие рекорды
        event EventHandler<EventArgs> HighScore;

        //Событие выбора ячейки
        event EventHandler<EventArgs> OpenCell;

        //Событие отметить ячейку флагом
        event EventHandler<EventArgs> SetFlag;

        //Событие обновления view
        void UpdateView(MineSweeperModel model);

        //Событие вызываемое таймером
        event EventHandler<EventArgs> GetTime;
    }
}
