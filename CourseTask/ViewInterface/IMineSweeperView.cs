using System;
using ModelGame;

namespace ViewInterface
{
    public interface IMineSweeperView
    {
        //Координата ячейки
        int X { get; }

        int Y { get; }

        //Событие новавя игра
        event EventHandler<EventArgs> NewGame;

        //Событие правила игры
        event EventHandler<EventArgs> Rule;

        //Cобытие рекорды
        event EventHandler<EventArgs> HighScore;

        //Событие выбора ячейки
        event EventHandler<EventArgs> OpenCell;

        //Событие отметить ячейку флагом
        event EventHandler<EventArgs> SetFlag;

        //Событие обновления view
        void UpdateView(ModelMineSweeper model);
    }
}
