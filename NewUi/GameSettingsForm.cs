using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FourInARow
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public int Rows
        {
            get { return (int)RowsNumber.Value; }
        }

        public int Cols
        {
            get { return (int)ColsNumber.Value; }
        }

        public string PlayerOneLabel
        {
            get { return textBoxPlayer1.Text; }
        }

        public string PlayerTwoLabel
        {
            get { return textBoxPlayer2.Text; }
        }

        private void checkBox1VsPc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1VsPc.Checked)
            {
                this.textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = string.Empty;
            }
            else
            {
                this.textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        public bool CheckBoxPlayerTwo
        {
            get { return checkBox1VsPc.Checked; }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (textBoxPlayer1.Text == string.Empty)
            {
                textBoxPlayer1.Text = "Player 1";
            }

            if (textBoxPlayer2.Text == string.Empty)
            {
                textBoxPlayer2.Text = "Player 2";
            }

            if (!checkBox1VsPc.Checked)
            {
                textBoxPlayer2.Text = "Computer";
            }

            FourInARowForm fourInARowForm = new FourInARowForm(this);
            fourInARowForm.ShowDialog();

            this.Close();
        }
    }
}
