using System;
using System.Collections.Generic;
using System.Text;

namespace C18_Four_in_a_Row
{
    public class GamePlayLogic
    {
        private char[,] m_GameMatrix;
        private bool m_AgainstPc;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private Player m_CurrentPlayerTurn;
        private int m_PcMoveRight;
        private int m_PcMoveLeft;

        public GamePlayLogic(int i_Row, int i_Col, bool i_AgainstPc, Player i_PlayerOne, Player i_PlayerTwo)
        {
            m_GameMatrix = new char[i_Row, i_Col];
            m_AgainstPc = i_AgainstPc;
            m_PlayerOne = i_PlayerOne;
            m_PlayerTwo = i_PlayerTwo;
            m_CurrentPlayerTurn = m_PlayerOne;
        }
       
        public Player PlayerOne
        {
            get { return m_PlayerOne; }
            set { m_PlayerOne = value; }
        }

        public Player PlayerTwo
        {
            get { return m_PlayerTwo; }
            set { m_PlayerTwo = value; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayerTurn; }
            set { m_CurrentPlayerTurn = value; }
        }

        public bool GameType
        {
            get { return m_AgainstPc; }
            set { m_AgainstPc = value; }
        }

        public int PcMoveRight
        {
            get { return m_PcMoveRight; }
            set { m_PcMoveRight = value; }
        }

        public int PcMoveLeft
        {
            get { return m_PcMoveLeft; }
            set { m_PcMoveLeft = value; }
        }

        public char[,] GameMatirx
        {
            get { return m_GameMatrix; }
            set { m_GameMatrix = value; }
        }

        public void Quitter() 
        {
            if(m_CurrentPlayerTurn == m_PlayerOne)
            {
                m_PlayerTwo.PlayerScore++;
            }
            else
            {
                m_PlayerOne.PlayerScore++;
            }
        }

        public void ClearGameMatrix()
         { 
            for (int i = 0; i < m_GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_GameMatrix.GetLength(1); j++)
                {
                    m_GameMatrix[i, j] = '\0';
                }
            }
         }

        public int MakeAction(int i_Move)
        {
            int rowToMark = 0;
            
            for (int i = m_GameMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (m_GameMatrix[i, i_Move - 1] == '\0')
                {
                    rowToMark = i;
                    break;
                }
            }

            m_GameMatrix[rowToMark, i_Move - 1] = CurrentPlayer.Coin;
            return rowToMark;
        }

        public bool CheckIfWinner(int i_Row, int i_Col, int i_SequenceSize)
        {
            bool hasSequenceSize = true;

            if (!CheckRowWin(i_Row, i_Col, i_SequenceSize))
            {
                if (!CheckColWin(i_Row, i_Col, i_SequenceSize))
                {
                    if (!CheckDiagonalUpDownWin(i_Row, i_Col, i_SequenceSize))
                    {
                        if (!CheckDiagonalDownUpWin(i_Row, i_Col, i_SequenceSize))
                        {
                            hasSequenceSize = false;
                        }
                    }
                }
            }

           if (hasSequenceSize)
            {
                m_CurrentPlayerTurn.PlayerScore++;
            }

           return hasSequenceSize;
        }

        public bool CheckRowWin(int i_Row, int i_Col, int i_SequenceSize)
        {
            int sumCoinsInARow = 1;
            char coin = m_GameMatrix[i_Row, i_Col];

            int checkRight = i_Col + 1, checkLeft = i_Col - 1;
            while (checkRight < m_GameMatrix.GetLength(1) && m_GameMatrix[i_Row, checkRight] == coin)
            {
                sumCoinsInARow++;
                checkRight++;
            }

            while (checkLeft >= 0 && m_GameMatrix[i_Row, checkLeft] == coin)
            {
                sumCoinsInARow++;
                checkLeft--;
            }

            m_PcMoveRight = checkRight;
            m_PcMoveLeft = checkLeft;

            return sumCoinsInARow >= i_SequenceSize;
        }

        public bool CheckColWin(int i_Row, int i_Col, int i_SequenceSize)
        {
            int sumCoinsInARow = 1;
            char coin = m_GameMatrix[i_Row, i_Col];
            
            int checkUp = i_Row - 1, checkDown = i_Row + 1;
            while (checkUp >= 0  && m_GameMatrix[checkUp, i_Col] == coin)
            {
                sumCoinsInARow++;
                checkUp--;
            }

            while (checkDown < m_GameMatrix.GetLength(0) && m_GameMatrix[checkDown, i_Col] == coin)
            {
                sumCoinsInARow++;
                checkDown++;
            }

            return sumCoinsInARow >= i_SequenceSize;
        }

        public bool CheckDiagonalUpDownWin(int i_Row, int i_Col, int i_SequenceSize)
        {
            int sumCoinsInARow = 1;
            char coin = m_GameMatrix[i_Row, i_Col];

            int checkUpRow = i_Row - 1, checkDownRow = i_Row + 1,
                checkUpCol = i_Col - 1, checkDownCol = i_Col + 1;

            while (checkUpRow >= 0 && checkUpCol >= 0 && m_GameMatrix[checkUpRow, checkUpCol] == coin)
            {
                sumCoinsInARow++;
                checkUpRow--;
                checkUpCol--;
            }

            while (checkDownRow < m_GameMatrix.GetLength(0) && checkDownCol < m_GameMatrix.GetLength(1) && m_GameMatrix[checkDownRow, checkDownCol] == coin)
            {
                sumCoinsInARow++;
                checkDownRow++;
                checkDownCol++;
            }

            m_PcMoveRight = checkDownCol;
            m_PcMoveLeft = checkUpCol;

            return sumCoinsInARow >= i_SequenceSize;
        }

        public bool CheckDiagonalDownUpWin(int i_Row, int i_Col, int i_SequenceSize)
        {
            int sumCoinsInARow = 1;
            char coin = m_GameMatrix[i_Row, i_Col];

            int checkUpRow = i_Row - 1, checkDownRow = i_Row + 1,
                checkUpCol = i_Col + 1, checkDownCol = i_Col - 1;

            while (checkUpRow >= 0 && checkUpCol < m_GameMatrix.GetLength(1) && m_GameMatrix[checkUpRow, checkUpCol] == coin)
            {
                sumCoinsInARow++;
                checkUpRow--;
                checkUpCol++;
            }

            while (checkDownRow < m_GameMatrix.GetLength(0) && checkDownCol >= 0 && m_GameMatrix[checkDownRow, checkDownCol] == coin)
            {
                sumCoinsInARow++;
                checkDownRow++;
                checkDownCol--;
            }

            m_PcMoveRight = checkUpCol;
            m_PcMoveLeft = checkDownCol;

            return sumCoinsInARow >= i_SequenceSize;
        }

        public bool CheckIfATie()
        {
            bool tie = true;
            for(int i = 0; i < m_GameMatrix.GetLength(1); i++)
            {
                if (m_GameMatrix[0, i] == '\0')
                {
                    tie = false;
                    break;
                }
            }

            return tie;
        }

        public int MakeAiMove()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomCol = rnd.Next(1, m_GameMatrix.GetLength(1) + 1);

            while(!CheckAvailableCol(randomCol))
            {
                randomCol = rnd.Next(1, m_GameMatrix.GetLength(1) + 1);
            }

            return randomCol;
        }

        public bool CheckAvailableCol(int i_Col)
        {
            return m_GameMatrix[0, i_Col - 1] == '\0';
        }

        public void ChangeTurn()
        {
            if (m_CurrentPlayerTurn == m_PlayerOne)
            {
                m_CurrentPlayerTurn = m_PlayerTwo;
            }
            else
            {
                m_CurrentPlayerTurn = m_PlayerOne;
            }
        }
    }
}
