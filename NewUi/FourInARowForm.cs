using C18_Four_in_a_Row;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewUi
{
    public partial class FourInARowForm : Form
    {
        private GameSettingsForm m_GameSettings;
        private GamePlayLogic m_CurrentGame;
        private Button[] m_ButtonArray;
        private Button[,] m_ButtonMatirx;
        private Label m_PlayerOneLabel;
        private Label m_PlayerTwoLabel;
        
        public FourInARowForm(GameSettingsForm i_GameSettings)
        {
            m_GameSettings = i_GameSettings;
            bool againstHuman = i_GameSettings.CheckBoxPlayerTwo;
            Player playerOne = new Player(i_GameSettings.PlayerOneLabel, 'O');
            Player playerTwo = new Player(i_GameSettings.PlayerTwoLabel, 'X');
            m_CurrentGame = new GamePlayLogic(i_GameSettings.Rows, i_GameSettings.Cols, !againstHuman, playerOne, playerTwo);
            InitializeComponent();
            buildBoard();
        }

        protected void colButtonClick(object sender, EventArgs e)
        {
                Button button = sender as Button;
                int rowOfAMove = m_CurrentGame.MakeAction(int.Parse(button.Text));
                printGame();
                if (!m_CurrentGame.CheckAvailableCol(int.Parse(button.Text)))
                {
                   button.Enabled = false;
                }
                if (!checkIfEndOfGame(rowOfAMove, int.Parse(button.Text)))
                {
                    m_CurrentGame.ChangeTurn();
                }
                if (m_CurrentGame.GameType && m_CurrentGame.CurrentPlayer == m_CurrentGame.PlayerTwo)
                {
                    computerMove();
                }
        }

        private void computerMove()
        {
            PcAi pcMove = new PcAi(m_CurrentGame);
            int move = pcMove.MakeAiMove();
            int rowOfAMove = m_CurrentGame.MakeAction(move);

            if (!m_CurrentGame.CheckAvailableCol(move))
            {
                m_ButtonArray[move - 1].Enabled = false;

            }
            checkIfEndOfGame(rowOfAMove, move);
            m_CurrentGame.ChangeTurn();
            printGame();
        }

        private bool checkIfEndOfGame(int i_RowOfAMove, int i_Move)
        {
            bool lastMove = false;
            if (m_CurrentGame.CheckIfWinner(i_RowOfAMove, i_Move - 1, 4))
            {
                lastMove = true;
                printGame();
                winMessage(m_CurrentGame.CurrentPlayer);
                m_PlayerOneLabel.Text = string.Format("{0}: {1}", m_CurrentGame.PlayerOne.PlayerName, m_CurrentGame.PlayerOne.PlayerScore);
                m_PlayerTwoLabel.Text = string.Format("{0}: {1}", m_CurrentGame.PlayerTwo.PlayerName, m_CurrentGame.PlayerTwo.PlayerScore);
            }
            else if (m_CurrentGame.CheckIfATie())
            {
                aTieMessage();
                lastMove = true;
            }

            return lastMove;
        }

        private void anotherRound(string i_Message, string i_Title)
        {

            if (MessageBox.Show(i_Message + "\nAnother Round?", i_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_CurrentGame.ClearGameMatrix();
                enabledButtonsBack();

                if (m_CurrentGame.CurrentPlayer == m_CurrentGame.PlayerTwo)
                {
                    m_CurrentGame.ChangeTurn();
                }
                printGame();
            }
            else
            {
                this.Close();
            }

        }
        private void enabledButtonsBack()
        {
            foreach (Button button in m_ButtonArray)
            {
                button.Enabled = true;
            }
        }

        private void printGame()
        {
            char[,] gameMatrix = m_CurrentGame.GameMatirx;

            for (int row = 0; row < gameMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < gameMatrix.GetLength(1); column++)
                {
                    m_ButtonMatirx[row, column].Text = (gameMatrix[row, column]).ToString();
                }
            }
        }

        private void buildBoard()
        {
            int rows = m_GameSettings.Rows;
            int cols = m_GameSettings.Cols;

            buildButtonsArray(cols);
            buildButtonsMatrix(rows, cols);
            buildLabels(rows,cols);
        }

        private void buildButtonsArray(int i_Cols)
        {
            m_ButtonArray = new Button[i_Cols];
            for (int i = 0; i < i_Cols; i++)
            {
                m_ButtonArray[i] = new Button();
                m_ButtonArray[i].Size = new Size(60, 23);
                m_ButtonArray[i].Location = new Point(30 + i * 65, 30);
                m_ButtonArray[i].Text = ((i + 1).ToString());
                m_ButtonArray[i].Click += new EventHandler(colButtonClick);
                Controls.Add(m_ButtonArray[i]);
            }

        }

        private void buildButtonsMatrix(int i_Rows,int i_Cols)
        {
            m_ButtonMatirx = new Button[i_Rows, i_Cols];

            for (int row = 0; row < i_Rows; row++)
            {
                for (int column = 0; column < i_Cols; column++)
                {
                    m_ButtonMatirx[row, column] = new Button();
                    m_ButtonMatirx[row, column].Size = new Size(60, 30);
                    m_ButtonMatirx[row, column].Location = new Point(30 + column * 65, 30 + (row + 1) * 50);

                    this.Controls.Add(m_ButtonMatirx[row, column]);
                }
            }

        }

        private void buildLabels(int i_Rows, int i_Cols)
        {
            Point point = new Point();
            point = m_ButtonMatirx[i_Rows - 1, i_Cols - 1].Location;

            this.Size = new Size(point.X + 100, point.Y + 125);

            m_PlayerOneLabel = new Label();
            m_PlayerOneLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerOneLabel);
            m_PlayerOneLabel.Location = new Point(point.X / 2 - 50, point.Y + 50);
            this.Controls.Add(m_PlayerOneLabel);

            m_PlayerTwoLabel = new Label();
            m_PlayerTwoLabel.Text = string.Format("{0}: 0", m_GameSettings.PlayerTwoLabel);
            m_PlayerTwoLabel.Location = new Point(point.X / 2 + 50, point.Y + 50);
            this.Controls.Add(m_PlayerTwoLabel);
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
