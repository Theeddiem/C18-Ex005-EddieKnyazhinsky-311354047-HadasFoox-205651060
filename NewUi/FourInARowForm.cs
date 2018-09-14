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
        //   Rectangle[] m_Rectangles;
        PictureBox[,] m_CoinsMatrix;
        PictureBox m_Coin1Picture;
        PictureBox m_Coin2Picture;
        PictureBox m_EmptyCoinPicture;
        PictureBox m_CurrentCoinPicture;
        Panel m_BorderPanel;
        Graphics m_formGraphics;
        Timer timer = new Timer();
        int difference = -6;
        int rowToStop;
        int m_col;


        public FourInARowForm(GameSettingsForm i_GameSettings)
        {
      
            InitializeComponent();
            m_GameSettings = i_GameSettings;
            bool againstHuman = i_GameSettings.CheckBoxPlayerTwo;

            Player playerOne = new Player(i_GameSettings.PlayerOneLabel, 'O');
            Player playerTwo = new Player(i_GameSettings.PlayerTwoLabel, 'X');
            m_GameLogic = new GamePlayLogic(i_GameSettings.Rows, i_GameSettings.Cols, !againstHuman, playerOne, playerTwo);
            buildGame(m_GameSettings.Rows, m_GameSettings.Cols);
            m_formGraphics = this.CreateGraphics();
            m_BorderPanel.Paint += new PaintEventHandler(borderPanelPaint);
            m_BorderPanel.MouseClick += new MouseEventHandler(borderPanelClick);
            timer.Interval = 12;
            timer.Tick += timer_Tick;
            m_CoinsMatrix = new PictureBox[i_GameSettings.Rows, i_GameSettings.Cols];
            

        }

      
        private void borderPanelPaint(object sender, PaintEventArgs e)
        {
        
            m_formGraphics = e.Graphics;

            int rows = m_GameSettings.Rows;
            int cols = m_GameSettings.Cols;
            SolidBrush boardBrush = new SolidBrush(Color.DeepSkyBlue);
            SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);

            SolidBrush coin1Brush = new SolidBrush(Color.Red);
            SolidBrush coin2Brush = new SolidBrush(Color.Yellow);

            char[,] gameMatrix = m_GameLogic.GameMatirx;
            Graphics formGraphics = m_BorderPanel.CreateGraphics();


            for (int row = 0; row < gameMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < gameMatrix.GetLength(1); column++)
                {

                    //  m_CoinsMatrix[row, column] = new PictureBox();

                    if (gameMatrix[row, column] == 'O')
                    {
                        //  m_formGraphics.DrawEllipse(new Pen(coin1Brush,2), 35 + column * 65, 35 + row * 65, 55, 55);
                        formGraphics.DrawImage(m_Coin1Picture.Image, 5 + column * 65, 5 + row * 65, 55, 55);
                        //     m_CoinsMatrix[row, column].Image = m_Coin1Picture.Image;
                    }
                    if (gameMatrix[row, column] == 'X')
                    {
                        // m_formGraphics.DrawEllipse(new Pen(coin2Brush, 2), 35 + column * 65, 35 + row * 65, 55, 55);
                        formGraphics.DrawImage(m_Coin2Picture.Image, 5 + column * 65, 5 + row * 65, 55, 55);
                        //      m_CoinsMatrix[row, column].Image = m_Coin2Picture.Image;
                    }
                    if (gameMatrix[row, column] == '\0')
                    {
                        // m_formGraphics.DrawEllipse(new Pen(emptyBrush, 2), 5 + column * 65, 5 + row * 65, 55, 55);
                        m_formGraphics.FillEllipse(emptyBrush, 5 + column * 65, 5 + row * 65, 55, 55);


                        // formGraphics.DrawImage(m_EmptyCoinPicture.Image, column * 65 + 5, row * 65 + 5, 55, 55);

                        //   m_CoinsMatrix[row, column].Image = m_EmptyCoinPicture.Image;
                    }


                }
            }

            this.Size = new Size(30 + 65 * cols + 65 * 2, (30 + 65 * rows) + 65);


            // e.Graphics.FillEllipse(coin1Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
            //  e.Graphics.FillEllipse(coin2Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);

              boardBrush.Dispose();
            m_formGraphics.Dispose();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            m_formGraphics = m_BorderPanel.CreateGraphics();
            if (m_CurrentCoinPicture.Bottom <= rowToStop * 65 + 59)
            {
                m_CurrentCoinPicture.Top -= difference;
            }

            else
            {
               
                timer.Stop();
                MessageBox.Show("Tick Timer Finshed");
                // updateGameMatrix();

                //  ss();
                m_formGraphics.DrawImage(m_CurrentCoinPicture.Image, m_col * 65 + 5, rowToStop * 65 + 5, 55, 55);
                // Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                // m_formGraphics.DrawLine(pen, m_col*20, 10, 300, 100);
            }
        }

 
        private void borderPanelClick(object sender, MouseEventArgs e)
        {
            m_col = BoardWasPressed(e.Location);
            if (m_col != -1)
            {
                if (m_GameLogic.CheckAvailableCol(m_col + 1))
                {
                    fallingCoin(m_col + 1);
                     playerMove(m_col + 1);
                      //  MessageBox.Show("affter");

                        if (m_GameLogic.GameType && m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo)
                        {
                            computerMove();
                        }
                    
                }
              
            }
        }

        private void fallingCoin(int i_Col)
        {
      
            if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerOne)
            {
                m_CurrentCoinPicture.Image = m_Coin1Picture.Image;
            }
            else
            {
                m_CurrentCoinPicture.Image = m_Coin2Picture.Image;
            }
            
            m_CurrentCoinPicture.Location = new Point(i_Col *65 - 60, 0);
            m_CurrentCoinPicture.Size = new Size(55, 55);
            m_BorderPanel.Controls.Add(m_CurrentCoinPicture);
            timer.Start();
          

        }

  

        private void changeTurnLabel()
        {
            SolidBrush boardBrush = new SolidBrush(Color.DeepSkyBlue);
            SolidBrush emptyBrush = new SolidBrush(Color.LightSkyBlue);
            
            SolidBrush coin1Brush = new SolidBrush(Color.Red);
            SolidBrush coin2Brush = new SolidBrush(Color.Yellow);
            SolidBrush screenBrush = new SolidBrush(Color.WhiteSmoke);

            m_formGraphics = m_BorderPanel.CreateGraphics();

            if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerOne)
            {
                m_formGraphics.FillEllipse(screenBrush,  + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
                m_formGraphics.FillEllipse(coin2Brush,  + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
            }
            else
            {
                m_formGraphics.DrawEllipse(new Pen(coin1Brush,2),  30+ 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 555, 15);
                m_formGraphics.DrawEllipse(new Pen(screenBrush,2), 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 555, 15);
            }
        }

        private int BoardWasPressed(Point i_Location)
        {
            int rows = m_GameSettings.Rows;
            int cols = m_GameSettings.Cols;
            int colClicked = -1;

            if ( i_Location.X <= 65 * cols &&
                i_Location.Y <= 65 * rows)
            {
                colClicked = (i_Location.X ) / 65;
            }

            return colClicked;
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
            rowToStop = rowMove;
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
            //   updateGameMatrix();
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
              // updateGameMatrix();
            }
            else
            {
                this.Close();
            }

        }
        
        private void buildGame(int i_Rows, int i_Cols)
        {
            m_BorderPanel = new Panel();
            m_BorderPanel.BackColor = (Color.DeepSkyBlue);
            this.m_BorderPanel.Location = new Point(30, 30);
            this.m_BorderPanel.Size = new Size(65 * m_GameSettings.Cols, 65 * m_GameSettings.Rows); // should be 65
            // this.m_BorderPanel.Size = new Size(30 + 65 * m_GameSettings.Cols + 65 * 2, (30 + 65 * m_GameSettings.Rows) + 65);
            this.Controls.Add(m_BorderPanel);

            m_PlayerOneLabel = new Label();
            m_PlayerOneLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerOneLabel);
            m_PlayerOneLabel.Location = new Point(30 + 65 * i_Cols + 30, (30 + 65 * i_Rows) / 2);
            m_PlayerOneLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerOneLabel);
     
            m_PlayerTwoLabel = new Label();
            m_PlayerTwoLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerTwoLabel);
            m_PlayerTwoLabel.Location = new Point(30 + 65 * i_Cols + 30, (30 + 65 * i_Rows) / 2 + 40);
            m_PlayerTwoLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerTwoLabel);

            PictureBox quitButton = new PictureBox();
            quitButton.Image = Properties.Resources.YellowCoin;
            quitButton.Text = "Quit Round";
            quitButton.Location = new Point(30 + 65 * i_Cols + 20, 30 + 65 * i_Rows - 34);
            quitButton.Font = new Font("Ariel", 9, FontStyle.Bold);
            quitButton.Click += new EventHandler(this.quitButton1);
            this.Controls.Add(quitButton);

            m_CoinsMatrix = new PictureBox[i_Rows, i_Cols];

            m_Coin1Picture = new PictureBox();
            m_Coin1Picture.Image = Properties.Resources.YellowCoin;

            m_Coin2Picture = new PictureBox();
            m_Coin2Picture.Image = Properties.Resources.RedCoin;
        
            m_EmptyCoinPicture = new PictureBox();
            m_EmptyCoinPicture.Image = Properties.Resources.Empty;
    
            m_CurrentCoinPicture = new PictureBox();
         

      
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            MessageBox.Show("s");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
