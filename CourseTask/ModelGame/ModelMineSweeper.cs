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
                            hightSores.Add(new Score(nameUser, Convert.ToInt32(nodeScore.InnerText)));
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

        //Проверка добавления рекорда в таблицу
        public bool CheckResult()
        {
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

            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlNode users = doc.CreateElement("users");
            doc.AppendChild(users);

            for (int i = 0; i < HightSores.Count; i++)
            {
                XmlNode user = doc.CreateElement("user");
                XmlAttribute userAttribute = doc.CreateAttribute("name");
                userAttribute.Value = HightSores[i].Name;

                XmlNode score = doc.CreateElement("score");
                score.AppendChild(doc.CreateTextNode(HightSores[i].TimeResult.ToString()));
            }

            doc.Save(@"./ModelGame/HightScores.xml");
        }
    }
}
