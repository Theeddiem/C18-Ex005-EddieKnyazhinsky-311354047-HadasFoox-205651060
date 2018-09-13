namespace NewUi
{
    partial class FourInARowForm
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
            this.buttonFall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFall
            // 
            this.buttonFall.AccessibleName = "ButtonOne";
            this.buttonFall.Location = new System.Drawing.Point(113, 13);
            this.buttonFall.Name = "buttonFall";
            this.buttonFall.Size = new System.Drawing.Size(75, 23);
            this.buttonFall.TabIndex = 0;
            this.buttonFall.Text = "button1";
            this.buttonFall.UseVisualStyleBackColor = true;
          this.buttonFall.Click += new System.EventHandler(this.button1_Click);
            // 
            // FourInARowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.buttonFall);
            this.Name = "FourInARowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FourInARowForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFall;
    }
}