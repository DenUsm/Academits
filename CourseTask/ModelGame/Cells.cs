using System;

namespace ModelGame
{
    public class Cells
    {
        private Cell[] cells;

        public Cells(int size)
        {
            cells = new Cell[size * size];
        }

        //получение координат мин
        public void SetMineCoordinate()
        {
            Random random = new Random();
            int x = random.Next(0, 9);
            int y = random.Next(0, 9);

            for (int i = 0; i < cells.Length - 1; i++)
            {
                while(cells[i].CompareTo(cells[i+1]) != 0)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                }
                cells[i].
                coordinateMine[i, 1] = y;
            }
        }
    }
}
