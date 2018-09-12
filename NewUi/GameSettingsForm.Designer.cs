namespace NewUi
{
    partial class GameSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1VsPc = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RowsNumber = new System.Windows.Forms.NumericUpDown();
            this.ColsNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Player 1:";
            // 
            // checkBox1VsPc
            // 
            this.checkBox1VsPc.AutoSize = true;
            this.checkBox1VsPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1VsPc.Location = new System.Drawing.Point(69, 107);
            this.checkBox1VsPc.Name = "checkBox1VsPc";
            this.checkBox1VsPc.Size = new System.Drawing.Size(107, 26);
            this.checkBox1VsPc.TabIndex = 2;
            this.checkBox1VsPc.Text = "Player2: ";
            this.checkBox1VsPc.UseVisualStyleBackColor = true;
            this.checkBox1VsPc.CheckedChanged += new System.EventHandler(this.checkBox1VsPc_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(170, 107);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(215, 26);
            this.textBoxPlayer2.TabIndex = 3;
            this.textBoxPlayer2.Text = "[Computer]";
            
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(170, 61);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(215, 26);
            this.textBoxPlayer1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Board Size:";
            
            // 
            // RowsNumber
            // 
            this.RowsNumber.Location = new System.Drawing.Point(144, 212);
            this.RowsNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.RowsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RowsNumber.Name = "RowsNumber";
            this.RowsNumber.Size = new System.Drawing.Size(61, 26);
            this.RowsNumber.TabIndex = 4;
            this.RowsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ColsNumber
            // 
            this.ColsNumber.Location = new System.Drawing.Point(261, 212);
            this.ColsNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ColsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ColsNumber.Name = "ColsNumber";
            this.ColsNumber.Size = new System.Drawing.Size(61, 26);
            this.ColsNumber.TabIndex = 5;
            this.ColsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cols:";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(128, 268);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(232, 41);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Play!";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 332);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ColsNumber);
            this.Controls.Add(this.RowsNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.checkBox1VsPc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GameSettingsForm";
            this.Text = "GameSettings";
            
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1VsPc;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RowsNumber;
        private System.Windows.Forms.NumericUpDown ColsNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPlay;
    }
}

