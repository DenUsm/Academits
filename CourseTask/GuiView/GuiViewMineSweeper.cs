using System.Windows.Forms;
using ViewInterface;

namespace GuiView
{
    public partial class GuiViewMineSweeper : Form
    {
        private Button[,] btn_grid;

        public GuiViewMineSweeper()
        {
            InitializeComponent();

            int width = 30;
            int height = 16;

            int param1 = 0;
            int param2 = 0;

            int startX = 0, startY = 0;
            btn_grid = new Button[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    btn_grid[x, y] = createButton(startX + 24 * x, startY + 24 * y, x, y);

                    param1 = 24 * (x + 1);
                    param2 = 24 * (y + 1);
                }                
            }

            Width = param1;
            Height = param2;
        }

        private Button createButton(int x, int y, int gridX, int gridY)
        {
            Button bttn = new Button();

            bttn.Text = "";
            bttn.Name = gridX.ToString() + " " + gridY.ToString();
            bttn.Size = new System.Drawing.Size(24, 24);
            bttn.Location = new System.Drawing.Point(x, y);
            Controls.AddRange(new Control[] { bttn });
            //bttn.Click += new System.EventHandler(bttnOnclick);
            //bttn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bttnOnRightClick);

            return bttn;
        }

    }
}
