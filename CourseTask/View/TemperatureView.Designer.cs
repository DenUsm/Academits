namespace View
{
    partial class TemperatureView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureView));
            this.cmbInputScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOutputScale = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tbInputValue = new System.Windows.Forms.TextBox();
            this.tbOutputValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbInputScale
            // 
            this.cmbInputScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputScale.FormattingEnabled = true;
            this.cmbInputScale.Location = new System.Drawing.Point(24, 25);
            this.cmbInputScale.Name = "cmbInputScale";
            this.cmbInputScale.Size = new System.Drawing.Size(121, 21);
            this.cmbInputScale.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Входная шкала измерения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выходная шкала измерения";
            // 
            // cmbOutputScale
            // 
            this.cmbOutputScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputScale.FormattingEnabled = true;
            this.cmbOutputScale.Location = new System.Drawing.Point(180, 25);
            this.cmbOutputScale.Name = "cmbOutputScale";
            this.cmbOutputScale.Size = new System.Drawing.Size(121, 21);
            this.cmbOutputScale.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(226, 103);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Перевести";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tbInputValue
            // 
            this.tbInputValue.Location = new System.Drawing.Point(24, 63);
            this.tbInputValue.Name = "tbInputValue";
            this.tbInputValue.Size = new System.Drawing.Size(121, 20);
            this.tbInputValue.TabIndex = 4;
            this.tbInputValue.Text = "0";
            this.tbInputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOutputValue
            // 
            this.tbOutputValue.Location = new System.Drawing.Point(180, 63);
            this.tbOutputValue.Name = "tbOutputValue";
            this.tbOutputValue.ReadOnly = true;
            this.tbOutputValue.Size = new System.Drawing.Size(121, 20);
            this.tbOutputValue.TabIndex = 5;
            this.tbOutputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TemperatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 138);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tbOutputValue);
            this.Controls.Add(this.tbInputValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOutputScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInputScale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TemperatureView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInputScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOutputScale;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox tbInputValue;
        private System.Windows.Forms.TextBox tbOutputValue;
    }
}