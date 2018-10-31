using System;
using System.Collections.Generic;
using System.Text;

namespace C18_Four_in_a_Row
{
    public class PcAi
    {
        // $G$ CSS-002 (-5) Bad member variable name (should be m_CamelCased)
        private int m_right;
        private int m_left;
        private GamePlayLogic m_CurrentGame;

        public PcAi(GamePlayLogic i_Game)
        {
            m_CurrentGame = i_Game;
        }

        public int MakeAiMove()
        {
            int move = -1;
            for (int i = m_CurrentGame.GameMatirx.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = m_CurrentGame.GameMatirx.GetLength(1) - 1; j >= 0; j--)
                {
                    // $G$ CSS-999 (-3) instead of using stirngs in a if statement use constants 
                    if (m_CurrentGame.GameMatirx[i, j] == 'X')
                    {
                        if (canWin(i, j, 3))
                        {
                            move = findBestMove(i);
                            if (move != -1)
                            {
                                move += 1;
                                break;
                            }
                        }
                    }
                    else if (m_CurrentGame.GameMatirx[i, j] == 'O')
                    {
                        if (canWin(i, j, 3))
                        {
                            move = findBestMove(i);
                            if (move != -1)
                            {
                                move += 1;
                                break;
                            }
                        }
                    }
                    else if (m_CurrentGame.GameMatirx[i, j] == 'X')
                    {
                        if (canWin(i, j, 2))
                        {
                            move = findBestMove(i);
                            if (move != -1)
                            {
                                move += 1;
                                break;
                            }
                        }
                    }
                    else if (m_CurrentGame.GameMatirx[i, j] == 'O')
                    {
                        if (canWin(i, j, 2))
                        {
                            move = findBestMove(i);
                            if (move != -1)
                            {
                                move += 1;
                                break;
                            }
                        }
                    }
                }
            }

            if (move == -1)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                move = rnd.Next(1, m_CurrentGame.GameMatirx.GetLength(1) + 1);
                while (!m_CurrentGame.CheckAvailableCol(move))
                {
                    move = rnd.Next(1, m_CurrentGame.GameMatirx.GetLength(1) + 1);
                }
            }

            return move;
        }

        private int findBestMove(int i_Row)
        {
            int move = -1;
            m_right = m_CurrentGame.PcMoveRight;
            m_left = m_CurrentGame.PcMoveLeft;

            if (m_right < m_CurrentGame.GameMatirx.GetLength(1) && m_CurrentGame.GameMatirx[i_Row, m_right] == '\0')
            {
                move = m_right;
            }
            else if (m_left >= 0 && m_CurrentGame.GameMatirx[i_Row, m_left] == '\0')
            {
                move = m_left;
            }

            return move;
        }

        private bool canWin(int i_Row, int i_Col, int i_SequenceSize)
        {
            bool hasSequenceSize = true;

            if (!m_CurrentGame.CheckRowWin(i_Row, i_Col, i_SequenceSize))
            {
                if (!m_CurrentGame.CheckDiagonalUpDownWin(i_Row, i_Col, i_SequenceSize))
                {
                    if (!m_CurrentGame.CheckDiagonalDownUpWin(i_Row, i_Col, i_SequenceSize))
                    {
                        hasSequenceSize = false;
                    }
                }
            }

            return hasSequenceSize;
        }
    }
}
