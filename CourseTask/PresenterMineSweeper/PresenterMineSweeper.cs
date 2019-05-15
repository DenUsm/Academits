using System;
using ModelGame;
using ViewInterface;

namespace PresenterGame
{
    public class PresenterMineSweeper
    {
        private readonly IMineSweeperView view;
        private readonly ModelMineSweeper model = new ModelMineSweeper();

        public PresenterMineSweeper(IMineSweeperView view)
        {
            this.view = view;
            view.OpenCell += new EventHandler<EventArgs>(Open);
            view.SetFlag += new EventHandler<EventArgs>(Flag);

            model.SetGameParameter(Level.Beginner);
        }

        //Открытие ячейки
        private void Open(object sender, EventArgs e)
        {
            model.OpenCell(view.X, view.Y);
            view.UpdateView(model);
        }

        //Пометить/отменить ячейку флагом
        private void Flag(object sender, EventArgs e)
        {
            model.SetFlagCoordinate(view.X, view.Y);
            view.UpdateView(model);
        }
    }
}
