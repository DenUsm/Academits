using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using System.Xml;

namespace ModelGame
{
    public class ModelMineSweeper
    {
        public CellsBoard cellBoard;
        private bool firstChoice;
        public int Time { get; private set; }
        private Timer timer;
        public static string About { get; private set; }
        public static string Rule { get; private set; }
        public static Dictionary<string, int> HightSores { get; private set; }

        public ModelMineSweeper()
        {
            About = GetInformation(@"./ModelGame/AboutProgram.txt");
            Rule = GetInformation(@"./ModelGame/RuleGame.txt");
            HightSores = LoadHightScores();
        }

        //Задние параметром игры для модели
        public void SetGameParameter(int width, int height, int countMine)
        {
            cellBoard = new CellsBoard(width, height, countMine);
            firstChoice = true;
            //создние таймер с интрвалом 1 секунда
            timer = new Timer(1000);
            // устанавливаем события обратного вызова таймера
            timer.Elapsed += new ElapsedEventHandler(Tick);
            Time = 0;
        }

        //Функция обратного вызова таймера
        private void Tick(object sender, ElapsedEventArgs e)
        {
            Time++;
        }

        //Отановка игрового таймера
        public void StopTimer()
        {
            timer.Stop();
            timer.Dispose();
        }

        //Открытие ячейки
        public void OpenCell(int x, int y)
        {
            if (firstChoice)
            {
                //задаем мины с учетом первого нажатия пользовтеля
                cellBoard.SetMineCoordinate(x, y);
                //задаем чиловые значения вокруг мин
                cellBoard.SetInitialValue();
                //устанавливаем флаг первого выбора ячйки
                firstChoice = false;
                timer.Start();
            }
            //Открывам ячейку
            cellBoard.OpenCell(x, y);

            if (cellBoard.Status != GameStatus.InPogress)
            {
                StopTimer();
            }
        }

        //Отметить ячейку флагом
        public void SetFlagCoordinate(int x, int y)
        {
            cellBoard.SetOrCancelFlag(x, y);
        }

        //получить статус игры
        public GameStatus GetStatusGame()
        {
            return cellBoard.Status;
        }

        //получение информции об игре из файла
        private string GetInformation(string path)
        {
            StringBuilder str = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string readline;
                    while ((readline = reader.ReadLine()) != null)
                    {
                        str.Append(readline);
                        str.Append(Environment.NewLine);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                str = null;
            }

            return str.ToString();
        }

        //получение таблицы рекордов
        private Dictionary<string, int> LoadHightScores()
        {
            Dictionary<string, int> hightSores = new Dictionary<string, int>();

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"./ModelGame/HightScores.xml");
                // получим корневой элемент
                XmlElement Root = xDoc.DocumentElement;

                foreach (XmlNode nodeUser in Root)
                {
                    string nameUser = null;
                    XmlNode name = nodeUser.Attributes.GetNamedItem("name");
                    if (name != null)
                    {
                        nameUser = name.Value;
                    }

                    foreach (XmlNode nodeScore in nodeUser.ChildNodes)
                    {
                        if (nodeScore.Name == "score")
                        {
                            hightSores.Add(nameUser, Convert.ToInt32(nodeScore.InnerText));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                hightSores = null;
            }

            return hightSores;
        }

    }
}
