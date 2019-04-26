using System;

namespace ViewInterface
{
    public interface IMineSweeperView
    {
        int[,] GetCoordinate { get; }

        int SetValue { set; }

        //получение индекса
        event EventHandler<EventArgs> GetIndexCell;
    }
}
