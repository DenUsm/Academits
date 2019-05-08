using System;

namespace ViewInterface
{
    public interface IMineSweeperView
    {
        //Событие новавя игра
        event EventHandler<EventArgs> NewGame;

        //Событие правила игры
        event EventHandler<EventArgs> Rule;

        //Событие правила игры
        event EventHandler<EventArgs> Exit;

        //Cобытие рекорды
        event EventHandler<EventArgs> HighScore;

        //Событие выбора ячейки
        event EventHandler<EventArgs> OpenCell;

        //Событие отметить ячейку флагом
        event EventHandler<EventArgs> SetFlag;
    }
}
