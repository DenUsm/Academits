using System;
using ModelGame;
using ViewInterface;

namespace PresenterGame
{
    public class PresenterMineSweeper
    {
        private ModelMineSweeper model = new ModelMineSweeper(9, 9, 10);
        private IMineSweeperView view;

        public PresenterMineSweeper(IMineSweeperView view)
        {
            this.view = view;
            view.GetIndexCell += new EventHandler<EventArgs>(GetIndexCell);
        }

        //получение индекса ячейки выбранной пользователем
        private void GetIndexCell(object sender, EventArgs e)
        {
            int [,] res = view.GetCoordinate;
            view.SetValue = model.GetTypeCell(res[0, 0], res[0, 1]);
        }
    }
}
