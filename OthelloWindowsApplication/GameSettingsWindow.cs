using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02_Othelo_Engine;

namespace OthelloWindowsApplication
{
    public partial class GameSettingsWindow : Form
    {
        private int m_SizeOfBoard;
        private Player.eStateOfPlayer m_StateOfSecondPlayer;

        public GameSettingsWindow()
        {
            InitializeComponent();
            m_SizeOfBoard = 6;
            this.ComputerButton.Click += new System.EventHandler(this.startButton_Click);
            this.PlayerButton.Click += new System.EventHandler(this.startButton_Click);
        }

        public int SizeOfBoard
        {
            get
            {
                return m_SizeOfBoard;
            }

            set
            {
                m_SizeOfBoard = value;
            }
        }

        public Player.eStateOfPlayer StateOfSecondPlayer
        {
            get
            {
                return m_StateOfSecondPlayer;
            }

            set
            {
                m_StateOfSecondPlayer = value;
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringButton = new StringBuilder();

            if (SizeOfBoard == 12)
            {
                SizeOfBoard = 6;
                stringButton.AppendFormat("Board Size : {0}x{0} (click to increase)", SizeOfBoard);
                BoardSizeButton.Text = stringButton.ToString();
            }
            else if (SizeOfBoard == 10)
            {
                SizeOfBoard = 12;
                stringButton.AppendFormat("Board Size : {0}x{0} (click to decrease)", SizeOfBoard);
                BoardSizeButton.Text = stringButton.ToString();
            }
            else
            {
                SizeOfBoard = SizeOfBoard + 2;
                stringButton.AppendFormat("Board Size : {0}x{0} (click to increase)", SizeOfBoard);
                BoardSizeButton.Text = stringButton.ToString();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (sender == PlayerButton)
            {
                StateOfSecondPlayer = Player.eStateOfPlayer.Human;
            }
            else
            {
                StateOfSecondPlayer = Player.eStateOfPlayer.Computer;
            }

            this.Hide();
            this.Close();
        }
    }
}
