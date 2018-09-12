using System;
using System.Collections.Generic;
using System.Text;

namespace C18_Four_in_a_Row
{
    public class Player
    {
        private readonly string r_PlayerName;
        private int m_PlayerScore;
        private char m_Coin;

        public Player(string i_PlayerName, char i_Coin)
        {
            r_PlayerName = i_PlayerName;
            m_Coin = i_Coin;
        }

        public char Coin
        {
            get { return m_Coin; }
            set { m_Coin = value; }
        }

        public string PlayerName
        {
            get { return r_PlayerName; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value; }
        }
    }
}
