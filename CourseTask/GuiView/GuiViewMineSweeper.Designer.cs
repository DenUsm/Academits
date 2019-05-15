namespace GuiView
{
    partial class GuiViewMineSweeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiViewMineSweeper));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLevelBeginner = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLevelMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLevelProfessional = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограамеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRule = new System.Windows.Forms.ToolStripMenuItem();
            this.рекордыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.описаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_ElapsedTime = new System.Windows.Forms.Label();
            this.btnFace = new System.Windows.Forms.Button();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.gbMines = new System.Windows.Forms.GroupBox();
            this.lbCountMine = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.gbMines.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.оПрограамеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(322, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGame,
            this.toolStripSeparator2,
            this.btnLevelBeginner,
            this.btnLevelMedium,
            this.btnLevelProfessional,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.новаяИграToolStripMenuItem.Text = "Файл";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(158, 22);
            this.btnNewGame.Text = "Новая игра";
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // btnLevelBeginner
            // 
            this.btnLevelBeginner.Checked = true;
            this.btnLevelBeginner.CheckOnClick = true;
            this.btnLevelBeginner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnLevelBeginner.Name = "btnLevelBeginner";
            this.btnLevelBeginner.Size = new System.Drawing.Size(158, 22);
            this.btnLevelBeginner.Text = "Новичок";
            this.btnLevelBeginner.Click += new System.EventHandler(this.ChangeLevel);
            // 
            // btnLevelMedium
            // 
            this.btnLevelMedium.CheckOnClick = true;
            this.btnLevelMedium.Name = "btnLevelMedium";
            this.btnLevelMedium.Size = new System.Drawing.Size(158, 22);
            this.btnLevelMedium.Text = "Любитель";
            this.btnLevelMedium.Click += new System.EventHandler(this.ChangeLevel);
            // 
            // btnLevelProfessional
            // 
            this.btnLevelProfessional.CheckOnClick = true;
            this.btnLevelProfessional.Name = "btnLevelProfessional";
            this.btnLevelProfessional.Size = new System.Drawing.Size(158, 22);
            this.btnLevelProfessional.Text = "Профессионал";
            this.btnLevelProfessional.Click += new System.EventHandler(this.ChangeLevel);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // оПрограамеToolStripMenuItem
            // 
            this.оПрограамеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRule,
            this.рекордыToolStripMenuItem,
            this.описаниеToolStripMenuItem});
            this.оПрограамеToolStripMenuItem.Name = "оПрограамеToolStripMenuItem";
            this.оПрограамеToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.оПрограамеToolStripMenuItem.Text = "О програаме";
            // 
            // btnRule
            // 
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(180, 22);
            this.btnRule.Text = "Правила";
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // рекордыToolStripMenuItem
            // 
            this.рекордыToolStripMenuItem.Name = "рекордыToolStripMenuItem";
            this.рекордыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.рекордыToolStripMenuItem.Text = "Рекорды";
            // 
            // описаниеToolStripMenuItem
            // 
            this.описаниеToolStripMenuItem.Name = "описаниеToolStripMenuItem";
            this.описаниеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.описаниеToolStripMenuItem.Text = "Описание";
            // 
            // lbl_ElapsedTime
            // 
            this.lbl_ElapsedTime.AutoSize = true;
            this.lbl_ElapsedTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_ElapsedTime.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_ElapsedTime.Location = new System.Drawing.Point(21, 18);
            this.lbl_ElapsedTime.Name = "lbl_ElapsedTime";
            this.lbl_ElapsedTime.Size = new System.Drawing.Size(16, 14);
            this.lbl_ElapsedTime.TabIndex = 3;
            this.lbl_ElapsedTime.Text = "0";
            // 
            // btnFace
            // 
            this.btnFace.Location = new System.Drawing.Point(145, 35);
            this.btnFace.Name = "btnFace";
            this.btnFace.Size = new System.Drawing.Size(33, 33);
            this.btnFace.TabIndex = 6;
            this.btnFace.UseVisualStyleBackColor = true;
            this.btnFace.Click += new System.EventHandler(this.btnFace_Click);
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.lbl_ElapsedTime);
            this.gbTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gbTime.ForeColor = System.Drawing.Color.Maroon;
            this.gbTime.Location = new System.Drawing.Point(12, 28);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(60, 40);
            this.gbTime.TabIndex = 7;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Time";
            // 
            // gbMines
            // 
            this.gbMines.Controls.Add(this.lbCountMine);
            this.gbMines.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gbMines.ForeColor = System.Drawing.Color.Maroon;
            this.gbMines.Location = new System.Drawing.Point(249, 28);
            this.gbMines.Name = "gbMines";
            this.gbMines.Size = new System.Drawing.Size(61, 40);
            this.gbMines.TabIndex = 8;
            this.gbMines.TabStop = false;
            this.gbMines.Text = "Mines";
            // 
            // lbCountMine
            // 
            this.lbCountMine.AutoSize = true;
            this.lbCountMine.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCountMine.ForeColor = System.Drawing.Color.Maroon;
            this.lbCountMine.Location = new System.Drawing.Point(24, 18);
            this.lbCountMine.Name = "lbCountMine";
            this.lbCountMine.Size = new System.Drawing.Size(16, 14);
            this.lbCountMine.TabIndex = 3;
            this.lbCountMine.Text = "0";
            // 
            // GuiViewMineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 269);
            this.Controls.Add(this.gbMines);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.btnFace);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GuiViewMineSweeper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.gbMines.ResumeLayout(false);
            this.gbMines.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNewGame;
        private System.Windows.Forms.ToolStripMenuItem btnLevelBeginner;
        private System.Windows.Forms.ToolStripMenuItem оПрограамеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRule;
        private System.Windows.Forms.ToolStripMenuItem рекордыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem описаниеToolStripMenuItem;
        private System.Windows.Forms.Label lbl_ElapsedTime;
        private System.Windows.Forms.Button btnFace;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.GroupBox gbMines;
        private System.Windows.Forms.Label lbCountMine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnLevelMedium;
        private System.Windows.Forms.ToolStripMenuItem btnLevelProfessional;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}