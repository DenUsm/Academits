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
            view.NewGame += new EventHandler<EventArgs>(Game);
            view.ChoosenLevel += new EventHandler<EventArgs>(GetParameter);
            view.GetTime += new EventHandler<EventArgs>(Time);

            model.SetGameParameter(Level.Beginner);
        }

        //Открытие ячейки
        private void Open(object sender, EventArgs e)
        {
            model.OpenCell(view.X, view.Y);
            view.MineCount = model.cellBoard.CountMine;
            view.UpdateView(model);
        }

        //Пометить/отменить ячейку флагом
        private void Flag(object sender, EventArgs e)
        {
            model.SetFlagCoordinate(view.X, view.Y);
            view.MineCount = model.cellBoard.CountMine;
            view.UpdateView(model);
        }

        //Начать новую игру
        private void Game(object sender, EventArgs e)
        {
            model.SetGameParameter(view.Level);
            view.WidthGame = model.cellBoard.Width;
            view.HeightGame = model.cellBoard.Height;
            view.MineCount = model.cellBoard.CountMine;
        }

        private void Time(object sender, EventArgs e)
        {
            view.Time = model.Time;
        }

        //получение параметров для перерисовки игрового поля
        private void GetParameter(object sender, EventArgs e)
        {
            Game(null, new EventArgs());
        }

    }
}
