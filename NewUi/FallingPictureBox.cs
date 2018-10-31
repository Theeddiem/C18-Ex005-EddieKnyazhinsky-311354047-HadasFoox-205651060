using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FourInARow
{
    public delegate void DoneFallingEventHendeler(object sender, DoneFallingEventArgs e);

    public class DoneFallingEventArgs : EventArgs
    {
        public int Row;
        public int Col;
    }

    public class FallingPictureBox : PictureBox
    {
        private Timer m_Timer;
        private int m_RowToStop;
        private int m_Col;

        public event DoneFallingEventHendeler PictureDoneFalling;

        public FallingPictureBox(PictureBox i_PictureBox)
        {
            this.Image = i_PictureBox.Image;
            m_Timer = new Timer();
            m_Timer.Interval = 1;
            m_Timer.Tick += timer_Tick;
        }

        public void StartFall(int i_Row, int i_Col)
        {
            m_RowToStop = i_Row;
            m_Col = i_Col;
            m_Timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Bottom <= (m_RowToStop + 1) * 65)
            {
                this.Top += 12;
            }
            else
            {
                m_Timer.Stop();
                DoneFalling();
            }
        }

        public void DoneFalling()
        {
            DoneFallingEventArgs e = new DoneFallingEventArgs();
            e.Row = m_RowToStop;
            e.Col = m_Col;
            OnDoneFalling(e);
        }

        protected virtual void OnDoneFalling(DoneFallingEventArgs e)
        {
            if (PictureDoneFalling != null)
            {
                PictureDoneFalling.Invoke(this, e);
            }
        }
    }
}
