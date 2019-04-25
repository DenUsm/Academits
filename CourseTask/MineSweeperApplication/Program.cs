using System;
using ModelGame;

namespace MineSweeperApplication
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cells model = new Cells(9, 9, 10);

            //for(int i = 0; i < 3; i++)
            //{
            //    for(int j = 0; j < 3; j++)
            //    {
            //        Cell[] test = model.GetCoordinateAround(new Cell(j, i));
            //        foreach(var value in test)
            //        {
            //            Console.Write("{0} ", value);
            //        }
            //        Console.WriteLine();
            //    }
            //}
            Console.WriteLine(model.ToString());

            Console.ReadKey();
        }
    }
}
