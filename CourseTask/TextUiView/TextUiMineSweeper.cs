using System;
using ViewInterface;
using PresenterGame;

namespace TextUiView
{
    public class TextUiMineSweeper : IMineSweeperView
    {
        public static TextUiMineSweeper view;
        public static PresenterMineSweeper presenter;

        static void Main(string[] args)
        {
            view = new TextUiMineSweeper();
            PresenterMineSweeper presenter = new PresenterMineSweeper(view);

            while (true)
            {

                Console.WriteLine("Пожалуйста введите координату x:");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Пожалуйста введите координату y:");
                int y = Convert.ToInt32(Console.ReadLine());

                //view.SetValue = new int[1, 2];
                //Console.WriteLine("Тип ячейки - {0}", model.GetTypeCell(x, y).ToString());
                //Console.WriteLine();
                //Console.WriteLine(model.ToString());
            }
        }

        public int[,] GetCoordinate => throw new NotImplementedException();

        public int SetValue { set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs> GetIndexCell;
      
    }
}
