using System;

namespace ModelGame
{
    public class ModelMineSweeper
    {
        private Cell[] cells;
        private int countMine;
        private int[,] coordinateMine;
        private int[,] coordinateIntersection = new int[10, 10];

        public ModelMineSweeper(int size, int countMine)
        {
            this.size = new int[size, size];
            this.countMine = countMine;
            coordinateMine = new int[10, 2] { { 0, 2 }, { 0, 6 }, { 1, 6 }, { 2, 8 }, { 3, 8 }, { 5, 0 }, { 5, 1 }, { 5, 2 }, { 7, 0 }, { 8, 7 } };
        }

        //проверка содержится ли уже координата мин
        private bool ContainsValue(int x, int y)
        {
            for (int i = 0; i < coordinateMine.GetLength(0); i++)
            {
                if(coordinateMine[i, 0] == x && coordinateMine[i, 1] == y)
                {
                    return true;
                }
            }
            return false;
        }
        
        //получение координат мин
        private void GetCoordinateMine()
        {
            Random random = new Random();      
            int x = random.Next(0, 9);
            int y = random.Next(0, 9);

            for (int i = 0; i < coordinateMine.GetLength(0); i++)
            {
                while(ContainsValue(x,y))
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                }
                coordinateMine[i, 0] = x;
                coordinateMine[i, 1] = y;
            }
        }

        //Инициалицация поля с минами
        public void FieldInitial()
        {
            //GetCoordinateMine();

            for (int i = 0; i < coordinateMine.GetLength(0); i++)
            {
                size[coordinateMine[i, 0], coordinateMine[i, 1]] = 1;
            }

            for (int i = 0; i < size.GetLength(0); i++)
            {    
                for (int j = 0; j < size.GetLength(1); j++)
                {
                    if (size[i, j] == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }        
                Console.WriteLine();
            }           
        }

        private int[,] GetCoordinateAroundMine()
        {
            int[,] coordinate = new int[9, 2];

            for(int i = 0; i < coordinate.GetLength(0); i++)
            {
                int x = coordinateMine[i, 0];
                int y = coordinateMine[i, 1];

                //проверяем если мины расположены в углу
                if(y == 0 && x == 0)
                {

                }
            }

            //1 2 3
            //4 X 6
            //7 8 9         
        }

        public void GetCoordinateIntersection()
        {
            int
        }

    }
}
