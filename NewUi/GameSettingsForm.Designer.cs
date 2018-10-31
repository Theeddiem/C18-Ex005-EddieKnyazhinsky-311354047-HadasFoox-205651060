namespace FourInARow
{
    public partial class GameSettingsForm
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
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Player 1:";
            // 
            // checkBox1VsPc
            // 
            this.checkBox1VsPc.AutoSize = true;
            this.checkBox1VsPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1VsPc.Location = new System.Drawing.Point(44, 70);
            this.checkBox1VsPc.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1VsPc.Name = "checkBox1VsPc";
            this.checkBox1VsPc.Size = new System.Drawing.Size(76, 19);
            this.checkBox1VsPc.TabIndex = 2;
            this.checkBox1VsPc.Text = "Player 2: ";
            this.checkBox1VsPc.UseVisualStyleBackColor = true;
            this.checkBox1VsPc.CheckedChanged += new System.EventHandler(this.checkBox1VsPc_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(113, 70);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer2.TabIndex = 3;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(113, 40);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Board Size:";
            // 
            // RowsNumber
            // 
            this.RowsNumber.Location = new System.Drawing.Point(96, 138);
            this.RowsNumber.Margin = new System.Windows.Forms.Padding(2);
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
            this.RowsNumber.Size = new System.Drawing.Size(41, 20);
            this.RowsNumber.TabIndex = 4;
            this.RowsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ColsNumber
            // 
            this.ColsNumber.Location = new System.Drawing.Point(174, 138);
            this.ColsNumber.Margin = new System.Windows.Forms.Padding(2);
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
            this.ColsNumber.Size = new System.Drawing.Size(41, 20);
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
            this.label4.Location = new System.Drawing.Point(57, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cols:";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(85, 174);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(155, 27);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Play!";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(331, 216);
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
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
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