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
        public static List<Score> HightSores { get; private set; }
        public Level GameLevel { get; set; }

        public ModelMineSweeper()
        {
            About = GetInformation(@"./ModelGame/AboutProgram.txt");
            Rule = GetInformation(@"./ModelGame/RuleGame.txt");
            HightSores = LoadHightScores();
        }

        //Задние параметром игры для станадратных режимов
        public void SetGameParameter(Level gameLevel)
        {
            if (gameLevel == Level.Beginner)
            {
                cellBoard = new CellsBoard(9, 9, 10);
            }
            else if (gameLevel == Level.Medium)
            {
                cellBoard = new CellsBoard(16, 16, 40);
            }
            else if (gameLevel == Level.Professional)
            {
                cellBoard = new CellsBoard(30, 20, 99);
            }
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
            if (!firstChoice)
            {
                cellBoard.SetOrCancelFlag(x, y);
            }

            if (cellBoard.Status != GameStatus.InPogress)
            {
                StopTimer();
            }
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
        private List<Score> LoadHightScores()
        {
            List<Score> hightSores = new List<Score>();

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"./ModelGame/HightScores.xml");
                // получим корневой элемент
                XmlElement Root = xDoc.DocumentElement;

                foreach (XmlNode nodeUser in Root)
                {
                    int score = 0;
                    XmlNode name = nodeUser.Attributes.GetNamedItem("score");
                    if (name != null)
                    {
                        score = Convert.ToInt32(name.Value);
                    }
                    hightSores.Add(new Score(nodeUser.InnerText, score));
                }
            }
            catch (FileNotFoundException)
            {
                hightSores = null;
            }

            return hightSores;
        }

        //Проверка добавления рекорда в таблицу
        public bool CheckResult()
        {
            if (HightSores.Count == 0)
            {
                HightSores = new List<Score>() { new Score(null, Time) };
                return true;
            }

            for (int i = 0; i < HightSores.Count; i++)
            {
                if (Time < HightSores[i].TimeResult)
                {
                    HightSores[i].TimeResult = Time;
                    return true;
                }
            }

            return false;
        }

        //Запись результата в файл .xml рекордов
        public void SaveResultHightScore(string name)
        {
            for (int i = 0; i < HightSores.Count; i++)
            {
                if (HightSores[i].TimeResult == Time)
                {
                    HightSores[i].Name = name;
                }
            }

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            for (int i = 0; i < HightSores.Count; i++)
            {
                XmlNode userNode = xmlDoc.CreateElement("user");
                XmlAttribute attribute = xmlDoc.CreateAttribute("score");
                attribute.Value = HightSores[i].TimeResult.ToString();
                userNode.Attributes.Append(attribute);
                userNode.InnerText = HightSores[i].Name;
                rootNode.AppendChild(userNode);
            }

            xmlDoc.Save(@"./ModelGame/HightScores.xml");
        }
    }
}
