using System;
using C18_Four_in_a_Row;
using System.Drawing;
using System.Windows.Forms;

namespace NewUi
{
    public partial class FourInARowForm : Form
    {
        private GameSettingsForm m_GameSettings;
        private GamePlayLogic m_GameLogic;
        private Label m_PlayerOneLabel;
        private Label m_PlayerTwoLabel;
        Rectangle[] m_Rectangles;
      //  SolidBrush boardBrush = new SolidBrush(Color.DeepSkyBlue);
      //  SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);
      ////  Graphics formGraphics;
      //  SolidBrush coin1Brush = new SolidBrush(Color.Red);
      //  SolidBrush coin2Brush = new SolidBrush(Color.Yellow);
      //  SolidBrush screenBrush = new SolidBrush(Color.Beige);

        public FourInARowForm(GameSettingsForm i_GameSettings)
        {
            InitializeComponent();
            m_GameSettings = i_GameSettings;
            bool againstHuman = i_GameSettings.CheckBoxPlayerTwo;
            Player playerOne = new Player(i_GameSettings.PlayerOneLabel, 'O');
            Player playerTwo = new Player(i_GameSettings.PlayerTwoLabel, 'X');
            m_GameLogic = new GamePlayLogic(i_GameSettings.Rows, i_GameSettings.Cols, !againstHuman, playerOne, playerTwo);
            buildLabels(m_GameSettings.Rows, m_GameSettings.Cols);
            this.Paint += new PaintEventHandler(this.fourInARowForm_Paint);
            this.MouseClick += new MouseEventHandler(fourInARowForm_Click);
         
        }

        private void fourInARowForm_Click(object sender, MouseEventArgs e)
        {
            int col = boardWasPressed(e.Location);
            if (col != -1)
            {
                if (m_GameLogic.CheckAvailableCol(col + 1))
                {

                    playerMove(col + 1);
                    //changeTurnLabel();
                    if (m_GameLogic.GameType && m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo)
                    {
                        computerMove();
                    }
                }
            }
        }

        private void changeTurnLabel()
        {
            SolidBrush boardBrush = new SolidBrush(Color.DeepSkyBlue);
            SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);
            Graphics formGraphics = this.CreateGraphics();
            SolidBrush coin1Brush = new SolidBrush(Color.Red);
            SolidBrush coin2Brush = new SolidBrush(Color.Yellow);
            SolidBrush screenBrush = new SolidBrush(Color.WhiteSmoke);

            if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerOne)
            {
                formGraphics.FillEllipse(screenBrush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
                formGraphics.FillEllipse(coin2Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
            }
            else
            {
                formGraphics.FillEllipse(coin1Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
                formGraphics.FillEllipse(screenBrush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
            }
        }

        private int boardWasPressed(Point i_Location)
        {
            int rows = m_GameSettings.Rows;
            int cols = m_GameSettings.Cols;
            int colClicked = -1;

            if (i_Location.X >= 30 && i_Location.X <= 30 + 65 * cols &&
                i_Location.Y >= 30 && i_Location.Y <= 30 + 65 * rows)
            {
                colClicked = (i_Location.X - 30) / 65;
            }

            return colClicked;
        }

        private void fourInARowForm_Paint(object sender, PaintEventArgs e)
        {
           int rows = m_GameSettings.Rows;
           int cols = m_GameSettings.Cols;
           m_Rectangles = new Rectangle[cols];
          //formGraphics = this.CreateGraphics();
           SolidBrush boardBrush = new SolidBrush(Color.DeepSkyBlue);
           SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);
            Graphics formGraphics = this.CreateGraphics();
           SolidBrush coin1Brush = new SolidBrush(Color.Red);
           SolidBrush coin2Brush = new SolidBrush(Color.Yellow);
            
           
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        m_Rectangles[j] = new Rectangle(new Point(30 + j * 65, 30), new Size(65, 65 * rows));
                        formGraphics.FillRectangle(boardBrush, m_Rectangles[j]);
                    }
                    formGraphics.FillEllipse(emptyBrush, 35 + j * 65, 35 + i * 65, 55, 55);
                }
            }
            formGraphics.FillEllipse(coin1Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
            //formGraphics.FillEllipse(coin2Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
            this.Size = new Size(30 + 65 * cols + 65 * 2 + 25, (30 + 65 * rows) + 65);
            boardBrush.Dispose();
            formGraphics.Dispose();
        }

        private void computerMove()
        {
            PcAi pcMove = new PcAi(m_GameLogic);
            int move = pcMove.MakeAiMove();
            playerMove(move);
        }

        private void playerMove(int i_Move)
        {
            int rowMove = m_GameLogic.MakeAction(i_Move);
            updateGameMatrix();
            changeTurnLabel();
            if (!checkIfEndOfGame(rowMove, i_Move))
            {
                m_GameLogic.ChangeTurn();
            }
            else
            {
                if (m_GameLogic.GameType && m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo)
                {
                    m_GameLogic.ChangeTurn();
                }
            }
        }

        private bool checkIfEndOfGame(int i_RowOfAMove, int i_Move)
        {
            bool lastMove = false;
            if (m_GameLogic.CheckIfWinner(i_RowOfAMove, i_Move - 1, 4))
            {
                lastMove = true;
                updateGameMatrix();
                winMessage(m_GameLogic.CurrentPlayer);
                updateLabels();
            }
            else if (m_GameLogic.CheckIfATie())
            {
                aTieMessage();
                lastMove = true;
            }

            return lastMove;
        }

        private void updateLabels()
        {
            m_PlayerOneLabel.Text = string.Format("{0}: {1}", m_GameLogic.PlayerOne.PlayerName, m_GameLogic.PlayerOne.PlayerScore);
            m_PlayerTwoLabel.Text = string.Format("{0}: {1}", m_GameLogic.PlayerTwo.PlayerName, m_GameLogic.PlayerTwo.PlayerScore);
        }

        private void anotherRound(string i_Message, string i_Title)
        {
           
            if (MessageBox.Show(i_Message + "\nAnother Round?", i_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_GameLogic.ClearGameMatrix();
                
                if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo)
                {
                    m_GameLogic.ChangeTurn();
                }
                updateGameMatrix();
            }
            else
            {
                this.Close();
            }

        }

        private void updateGameMatrix()
        {
            char[,] gameMatrix = m_GameLogic.GameMatirx;
            SolidBrush coin1Brush = new SolidBrush(Color.Red);
            SolidBrush coin2Brush = new SolidBrush(Color.Yellow);
            SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);
            Graphics formGraphics = this.CreateGraphics();

            for (int row = 0; row < gameMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < gameMatrix.GetLength(1); column++)
                {
                    if (gameMatrix[row, column] == 'O')
                    {
                        formGraphics.FillEllipse(coin1Brush, 35 + column * 65, 35 + row * 65, 55, 55);
                    }
                    if (gameMatrix[row, column] == 'X')
                    {
                        formGraphics.FillEllipse(coin2Brush, 35 + column * 65, 35 + row * 65, 55, 55);
                    }
                    if(gameMatrix[row, column] == '\0')
                    {
                        formGraphics.FillEllipse(emptyBrush, 35 + column * 65, 35 + row * 65, 55, 55);
                    }
                    
                }
            }
        }

        private void buildLabels(int i_Rows, int i_Cols)
        {
            m_PlayerOneLabel = new Label();
            m_PlayerOneLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerOneLabel);
            m_PlayerOneLabel.Location = new Point(30 + 65 * i_Cols + 30, (30 + 65 * i_Rows) / 2);
            m_PlayerOneLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerOneLabel);
            //formGraphics.FillEllipse(coin1Brush, 30 + 65 * i_Cols + 20, (30 + 65 * i_Rows) / 2, 200, 200);

            m_PlayerTwoLabel = new Label();
            m_PlayerTwoLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerTwoLabel);
            m_PlayerTwoLabel.Location = new Point(30 + 65 * i_Cols + 30, (30 + 65 * i_Rows) / 2 + 40);
            m_PlayerTwoLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerTwoLabel);

            Button quitButton = new Button();
            quitButton.Text = "Quit Round";
            quitButton.Size = new Size(90, 35);
            quitButton.BackColor = Color.Red;
            quitButton.Location = new Point(30 + 65 * i_Cols + 20, 30 + 65 * i_Rows - 34);
            quitButton.Font = new Font("Ariel", 9, FontStyle.Bold);
            quitButton.Click += new EventHandler(this.quitButton1);
            this.Controls.Add(quitButton);
            
        }
        private void quitButton1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            m_GameLogic.Quit();
            updateLabels();
            anotherRound(string.Format("{0} Quit",m_GameLogic.CurrentPlayer.PlayerName),"Quit!");
        }

        private void aTieMessage()
        {
            anotherRound("It's A Tie!!", "A Tie!");
        }

        private void winMessage(Player i_Player)
        {

            anotherRound(string.Format("{0} Won!!", i_Player.PlayerName), "A win!");
        }

        private void quitMessage()
        {
            MessageBox.Show("You Quit, better luck next time!");
        }

    }
}
