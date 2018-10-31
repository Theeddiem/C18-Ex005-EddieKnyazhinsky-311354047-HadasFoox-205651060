using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using C18_Four_in_a_Row;

namespace FourInARow
{
    public partial class FourInARowForm : Form
    {
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private GameSettingsForm m_GameSettings;
        private GamePlayLogic m_GameLogic;
        private Label m_PlayerOneLabel;
        private Label m_PlayerTwoLabel;
        private PictureBox m_Coin1Picture;
        private PictureBox m_Coin2Picture;
        private Panel m_BorderPanel;
        private Graphics m_formGraphics;
        private SolidBrush m_Coin1Brush;
        private SolidBrush m_Coin2Brush;
        private SolidBrush m_ScreenBrush;
        private SolidBrush m_EmptyCoinBrush;
        private SoundPlayer m_CoinSound;

        public FourInARowForm(GameSettingsForm i_GameSettings)
        {
            InitializeComponent();
            m_GameSettings = i_GameSettings;
            m_formGraphics = this.CreateGraphics();
            setGameLogic();
            buildGame();
            initializeEventHandlers();
        }

        private void initializeEventHandlers()
        {
            m_BorderPanel.MouseClick += new MouseEventHandler(boardPanel_Click);
            this.Paint += new PaintEventHandler(markStartingPlayerTurn);
            m_BorderPanel.Paint += new PaintEventHandler(drawingBlankCoins);
            m_GameLogic.CellChangeOccured += new CellChangeEventHandler(gameLogic_CellChange);
        }

        private void setGameLogic()
        {
            bool againstHuman = m_GameSettings.CheckBoxPlayerTwo;
            Player playerOne = new Player(m_GameSettings.PlayerOneLabel, 'O');
            Player playerTwo = new Player(m_GameSettings.PlayerTwoLabel, 'X');
            m_GameLogic = new GamePlayLogic(m_GameSettings.Rows, m_GameSettings.Cols, !againstHuman, playerOne, playerTwo);
        }

        private void markStartingPlayerTurn(object sender, PaintEventArgs e)
        {
            m_formGraphics.FillEllipse(m_Coin1Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
        }

        private void drawingBlankCoins(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < m_GameSettings.Rows; i++)
            {
                for (int j = 0; j < m_GameSettings.Cols; j++)
                {
                    e.Graphics.FillEllipse(m_EmptyCoinBrush, 5 + j * 65, 5 + i * 65 + 7, 45, 44);
                }
            }
        }

        private void clearGameMatrix()
        {
            m_BorderPanel.Controls.Clear();
        }
        
        private void boardPanel_Click(object sender, MouseEventArgs e)
        {
            int col = boardWasPressed(e.Location);
            boardClick(col);
        }

        private void boardClick(int i_Col)
        {
            if (m_GameLogic.CheckAvailableCol(i_Col + 1) && !computerTurn())
            {
                playerMove(i_Col + 1);
            }
        }

        private void coin_Click(object sender, MouseEventArgs e)
        {
            int col = (sender as PictureBox).Location.X / 65;
            boardClick(col);
        }

        private void coin_DoneFalling(object sender, DoneFallingEventArgs e)
        {
            m_CoinSound.Play();
            updateTurnStatus(e.Row, e.Col + 1);
            changeTurnLabel();

            if (computerTurn())
            {
                computerMove();
            }
            else
            {
                enabledPanel(true);
            }
        }

        private bool computerTurn()
        {
            return m_GameLogic.GameType && m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo;
        }

        private void gameLogic_CellChange(object sender, CellChangeEventArgs e)
        {
            FallingPictureBox coinPlayer = getNewCoin();
            coinPlayer.Location = new Point(e.Col * 65, 0);
            coinPlayer.Size = new Size(65, 65);
            coinPlayer.MouseClick += new MouseEventHandler(coin_Click);
            coinPlayer.PictureDoneFalling += new DoneFallingEventHendeler(coin_DoneFalling);
            m_BorderPanel.Controls.Add(coinPlayer);
            coinPlayer.StartFall(e.Row, e.Col);
            enabledPanel(false);
        }

        private FallingPictureBox getNewCoin()
        {
            FallingPictureBox coinPlayer;

            if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerOne)
            {
                coinPlayer = new FallingPictureBox(m_Coin1Picture);
            }
            else
            {
                coinPlayer = new FallingPictureBox(m_Coin2Picture);
            }

            return coinPlayer;
        }

        private int boardWasPressed(Point i_Location)
        {
            return i_Location.X / 65;
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
        }

        private void updateTurnStatus(int i_Row, int i_Col)
        {
            if (!checkIfEndOfGame(i_Row, i_Col))
            {
                m_GameLogic.ChangeTurn();
            }
            else
            {
                if (computerTurn())
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
                winMessage(m_GameLogic.CurrentPlayer);
            }
            else if (m_GameLogic.CheckIfATie())
            {
                aTieMessage();
                lastMove = true;
            }

            return lastMove;
        }

        private void enabledPanel(bool i_Enabled)
        {
            m_BorderPanel.Enabled = i_Enabled;
        }

        private void updateLabels()
        {
            m_PlayerOneLabel.Text = string.Format("{0}: {1}", m_GameLogic.PlayerOne.PlayerName, m_GameLogic.PlayerOne.PlayerScore);
            m_PlayerTwoLabel.Text = string.Format("{0}: {1}", m_GameLogic.PlayerTwo.PlayerName, m_GameLogic.PlayerTwo.PlayerScore);
        }

        private void anotherRound(string i_Message, string i_Title)
        {
            // $G$ NTT-999 (-10) You should use Environment.NewLine instead of ' \n '.
            if (MessageBox.Show(i_Message + "\nAnother Round?", i_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_GameLogic.ClearGameMatrix();
                
                if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerTwo)
                {
                    m_GameLogic.ChangeTurn();
                }

                updateLabels();
                clearGameMatrix();
            }
            else
            {
                this.Close();
            }
        }
        
        private void buildGame()
        {
            buildBoard();
            buildLabels();
            buildBottons();
            buildBrushes();
        }

        private void buildBrushes()
        {
            m_Coin1Brush = new SolidBrush(Color.Yellow);
            m_Coin2Brush = new SolidBrush(Color.Red);
            m_ScreenBrush = new SolidBrush(Color.WhiteSmoke);
            m_EmptyCoinBrush = new SolidBrush(Color.LightSkyBlue);
        }

        private void buildBottons()
        {
            PictureBox quitButton = new PictureBox();
            quitButton.Image = NewUi.Properties.Resources.WhiteFlag;
            quitButton.Location = new Point(30 + 65 * m_GameSettings.Cols + 20, 30 + 65 * m_GameSettings.Rows - 50);
            quitButton.Click += new EventHandler(this.quitButton);
            this.Controls.Add(quitButton);
        }

        private void buildLabels()
        {
            buildPlayer1Label();
            buildPlayer2Label();
        }

        private void buildPlayer2Label()
        {
            m_PlayerTwoLabel = new Label();
            m_PlayerTwoLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerTwoLabel);
            m_PlayerTwoLabel.Location = new Point(30 + 65 * m_GameSettings.Cols + 30, (30 + 65 * m_GameSettings.Rows) / 2 + 40);
            m_PlayerTwoLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerTwoLabel);
        }

        private void buildPlayer1Label()
        {
            m_PlayerOneLabel = new Label();
            m_PlayerOneLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerOneLabel);
            m_PlayerOneLabel.Location = new Point(30 + 65 * m_GameSettings.Cols + 30, (30 + 65 * m_GameSettings.Rows) / 2);
            m_PlayerOneLabel.Font = new Font("Ariel", 9, FontStyle.Bold);
            this.Controls.Add(m_PlayerOneLabel);
        }

        private void buildBoard()
        {
            buildBoardPanel();
            createCoins();
        }

        private void buildBoardPanel()
        {
            m_BorderPanel = new Panel();
            m_BorderPanel.BackColor = Color.DeepSkyBlue;
            this.m_BorderPanel.Location = new Point(30, 30);
            this.m_BorderPanel.Size = new Size(65 * m_GameSettings.Cols, 65 * m_GameSettings.Rows);
            this.Controls.Add(m_BorderPanel);

            this.Size = new Size(65 + 65 * m_GameSettings.Cols + 65 * 2, (30 + 65 * m_GameSettings.Rows) + 65);
        }

        private void createCoins()
        {
            m_Coin1Picture = new PictureBox();
            m_Coin1Picture.Image = NewUi.Properties.Resources.YellowCoin;
            m_Coin1Picture.Size = new Size(65, 65);

            m_Coin2Picture = new PictureBox();
            m_Coin2Picture.Image = NewUi.Properties.Resources.RedCoin;
            m_Coin2Picture.Size = new Size(65, 65);

            m_CoinSound = new SoundPlayer(NewUi.Properties.Resources.CoinSound);
        }

        private void changeTurnLabel()
        {
            if (m_GameLogic.CurrentPlayer == m_GameLogic.PlayerOne)
            {
                m_formGraphics.FillEllipse(m_ScreenBrush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
                m_formGraphics.FillEllipse(m_Coin1Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
            }
            else
            {
                m_formGraphics.FillEllipse(m_Coin2Brush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2 + 40, 15, 15);
                m_formGraphics.FillEllipse(m_ScreenBrush, 30 + 65 * m_GameSettings.Cols + 15, (30 + 65 * m_GameSettings.Rows) / 2, 15, 15);
            }
        }

        private void quitButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            m_GameLogic.Quit();
            updateLabels();
            anotherRound(string.Format("{0} Quit", m_GameLogic.CurrentPlayer.PlayerName), "Quit!");
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
