using System;
using System.Drawing;
using System.Windows.Forms;
using ViewInterface;
using ModelGame;

namespace GuiView
{
    public partial class GuiViewMineSweeper : Form, IMineSweeperView
    {
        private Button[,] cells;
        private Control[,] board;
        private bool firstClick = true;

        public event EventHandler<EventArgs> NewGame;
        public event EventHandler<EventArgs> Rule;
        public event EventHandler<EventArgs> HighScore;
        public event EventHandler<EventArgs> OpenCell;
        public event EventHandler<EventArgs> SetFlag;
        public event EventHandler<EventArgs> ChoosenLevel;
        public event EventHandler<EventArgs> GetTime;

        public int X { get; private set; }
        public int Y { get; private set; }
        public Level Level { get; private set; }

        public int WidthGame { private get; set; }
        public int HeightGame { private get; set; }
        public int MineCount { private get; set; }
        public int Time { private get; set; }

        public GuiViewMineSweeper()
        {
            InitializeComponent();
            InitializeGameBoard(9, 9, 10);
        }

        //начальное создание игрового поля
        private void InitializeGameBoard(int width, int height, int countMine)
        {
            //Стартовый отступ по ширине и высоте
            int startX = 15, startY = 75;
            cells = new Button[width, height];
            board = new Control[width, height];

            //Заполнение и расстановка кнопок на форме
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = createButton(startX + 24 * x, startY + 24 * y, x, y);
                }
            }

            //Изменение размеров формы в зависимости от количства ячеек
            Width = startX * 2 + (width + 1) * 24 - 8;
            Height = startY + (height + 2) * 24;

            //Автоматическое выставление расположения gbTime
            gbTime.Location = new Point(startX, startY - 50);

            //Автоматическое выставление расположения btnFace
            btnFace.Location = new Point(startX + Width / 2 - btnFace.Width - 8, startY - 45);
            btnFace.BackgroundImage = Properties.Resources.smileybase;

            //Автоматическое выставление расположения gbMines
            gbMines.Location = new Point(Width - 2 * startX - gbMines.Width, startY - 50);

            //задание количества мин
            lbCountMine.Text = countMine.ToString();
        }

        //удаление контролов ячеек с формы
        private void RemoveControl()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Controls.Remove(board[i, j]);
                }
            }
            btnFace.Image = null;
        }

        //Создание поле из кнопок и их расположение 
        private Button createButton(int x, int y, int gridX, int gridY)
        {
            Button bttn = new Button();
            int sizeBttn = 24;

            bttn.Text = null;
            bttn.Name = gridX.ToString() + " " + gridY.ToString();
            //Задаем размер кнопки
            bttn.Size = new Size(sizeBttn, sizeBttn);
            //Положении кнопки
            bttn.Location = new Point(x, y);
            //начальная картинка кнопки
            bttn.BackgroundImage = Properties.Resources.unmarked;

            board[gridX, gridY] = bttn;

            //Добавление контрола
            Controls.AddRange(new Control[] { board[gridX, gridY] });

            //Добавление события для клика на ячейку
            bttn.MouseDown += new MouseEventHandler(bttnClick);

            return bttn;
        }

        //событие открытия или высавления флага на игровом поле
        private void bttnClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            string[] split = btn.Name.Split(new Char[] { ' ' });

            //Получаем координаты ячейки
            X = Convert.ToInt32(split[0]);
            Y = Convert.ToInt32(split[1]);

            if (e.Button == MouseButtons.Left)
            {
                OpenCell(this, EventArgs.Empty);
                if (firstClick)
                {
                    GameTimer.Start();
                    firstClick = false;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                SetFlag(this, EventArgs.Empty);
            }
        }

        private void SetImageCellNotMine(int type, int x, int y)
        {
            //Выставление соответсвующей картинки на ячейки
            switch (type)
            {
                case (int)ModelGame.Type.Empty:
                    cells[x, y].Image = Properties.Resources.tilebase;
                    break;
                case (int)ModelGame.Type.One:
                    cells[x, y].Image = Properties.Resources.mine1;
                    break;
                case (int)ModelGame.Type.Two:
                    cells[x, y].Image = Properties.Resources.mine2;
                    break;
                case (int)ModelGame.Type.Three:
                    cells[x, y].Image = Properties.Resources.mine3;
                    break;
                case (int)ModelGame.Type.Four:
                    cells[x, y].Image = Properties.Resources.mine4;
                    break;
                case (int)ModelGame.Type.Five:
                    cells[x, y].Image = Properties.Resources.mine5;
                    break;
                case (int)ModelGame.Type.Six:
                    cells[x, y].Image = Properties.Resources.mine6;
                    break;
                case (int)ModelGame.Type.Seven:
                    cells[x, y].Image = Properties.Resources.mine7;
                    break;
                case (int)ModelGame.Type.Eight:
                    cells[x, y].Image = Properties.Resources.mine8;
                    break;
            }

            //Отменить действие нажатия на уже открытых ячейках
            cells[x, y].MouseDown -= new MouseEventHandler(bttnClick);
        }

        private void SetImageCellMine(Cell cell, int x, int y)
        {
            if(!cell.IsFlagged)
            {
                cells[x, y].Image = Properties.Resources.mine;
            }
            else if (x == X && y == Y)
            {
                cells[x, y].Image = Properties.Resources.hit;
            }

            //Отменить действие нажатия на уже открытых ячейках
            cells[x, y].MouseDown -= new MouseEventHandler(bttnClick);
        }

        //Обновление view после события
        public void UpdateView(ModelMineSweeper model)
        {
            var iterator = model.cellBoard.GetEnumerator();
            lbCountMine.Text = MineCount.ToString();

            while (iterator.MoveNext())
            {
                int x = iterator.Current.X;
                int y = iterator.Current.Y;

                if (iterator.Current.IsOpened)
                {
                    int type = (int)iterator.Current.Type;

                    //Выставление соответсвующей картинки для типа мина
                    if (type == (int)ModelGame.Type.Mine)
                    {
                        SetImageCellMine(iterator.Current, x, y);
                        continue;
                    }
                    //Выставление соответсвующей картинки для не мин
                    SetImageCellNotMine(type, x, y);
                    continue;
                }
                else if (iterator.Current.IsFlagged)
                {
                    cells[x, y].Image = Properties.Resources.flag;
                }
                else
                {
                    cells[x, y].Image = Properties.Resources.unmarked;
                }
            }

            //проверка игря на проигрыш
            if (model.GetStatusGame() == GameStatus.GameOver)
            {
                GameTimer.Stop();

                //Отменить действие нажатия на оставшихся ячейках
                iterator = model.cellBoard.GetEnumerator();
                while (iterator.MoveNext())
                {
                    int x = iterator.Current.X;
                    int y = iterator.Current.Y;

                    if(iterator.Current.IsFlagged && (iterator.Current.Type != ModelGame.Type.Mine))
                    {
                        cells[x, y].Image = Properties.Resources.notmine;
                    }

                    if (!iterator.Current.IsOpened)
                    {
                        cells[x, y].MouseDown -= new MouseEventHandler(bttnClick);
                    }
                }

                btnFace.Image = Properties.Resources.smiley_lose;
            }

            //проверка игры на выигрыш
            if (model.GetStatusGame() == GameStatus.Win)
            {
                GameTimer.Stop();

                MessageBox.Show("Вы победили!!!");
            }

        }

        //нажатие кнопки выхода из меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //нажатие кнопки новой игры
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            NewGame(this, EventArgs.Empty);
            RemoveControl();
            InitializeGameBoard(WidthGame, HeightGame, MineCount);
            lbTime.Text = "0";
            firstClick = true;
        }

        //Переключение режимов игры 
        private void ChangeLevel(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item == btnLevelBeginner)
            {
                Level = Level.Beginner;
                item.Checked = true;
                btnLevelMedium.Checked = false;
                btnLevelProfessional.Checked = false;
            }
            if (item == btnLevelMedium)
            {
                Level = Level.Medium;
                item.Checked = true;
                btnLevelBeginner.Checked = false;
                btnLevelProfessional.Checked = false;
            }
            if (item == btnLevelProfessional)
            {
                Level = Level.Professional;
                item.Checked = true;
                btnLevelBeginner.Checked = false;
                btnLevelMedium.Checked = false;
            }
            ChoosenLevel(this, EventArgs.Empty);
            RemoveControl();
            InitializeGameBoard(WidthGame, HeightGame, MineCount);
            //lbTime.Text = "0";
            //firstClick = true;
        }

        //Нажатие кнопки новая игра
        private void btnFace_Click(object sender, EventArgs e)
        {
            btnNewGame.PerformClick();
        }

        //Нажатие кнопки правила
        private void btnRule_Click(object sender, EventArgs e)
        {
            RuleMineSweeper rule = new RuleMineSweeper();
            rule.EnterRuleOnForm(ModelMineSweeper.Rule);
            rule.ShowDialog();
        }

        //Таймер
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            GetTime(this, EventArgs.Empty);
            lbTime.Text = Time.ToString();
        }
    }
}
