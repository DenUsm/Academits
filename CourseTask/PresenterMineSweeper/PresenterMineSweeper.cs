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
        }
    }
}
