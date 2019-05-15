namespace GuiView
{
    partial class RuleMineSweeper
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
            this.rtbRule = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbRule
            // 
            this.rtbRule.BackColor = System.Drawing.SystemColors.Control;
            this.rtbRule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbRule.Location = new System.Drawing.Point(3, 2);
            this.rtbRule.Name = "rtbRule";
            this.rtbRule.ReadOnly = true;
            this.rtbRule.Size = new System.Drawing.Size(363, 198);
            this.rtbRule.TabIndex = 0;
            this.rtbRule.Text = "";
            // 
            // RuleMineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 204);
            this.Controls.Add(this.rtbRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RuleMineSweeper";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правила игры";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRule;
    }
}