using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02_Othelo_Engine;

namespace OthelloWindowsApplication
{
    public class ApplicationManager
    {
        private readonly Dictionary<string, int> r_PlayerPoints;
        private readonly GameSettingsWindow r_GameSettingsWindow;
        private Player.eStateOfPlayer m_StateOfSecondPlayer;
        private int m_SizeOfBoard;
        private GameWindow m_GameWindow;

        public ApplicationManager()
        {
            r_PlayerPoints = new Dictionary<string, int>();
            r_PlayerPoints.Add("Yellow", 0);
            r_PlayerPoints.Add("Red", 0);
            r_GameSettingsWindow = new GameSettingsWindow();
            GameSettingsWindow.ComputerButton.Click += new EventHandler(SetTheGame);
            GameSettingsWindow.PlayerButton.Click += new EventHandler(SetTheGame);
            GameSettingsWindow.ShowDialog();
        }

        public GameSettingsWindow GameSettingsWindow
        {
            get
            {
                return r_GameSettingsWindow;
            }
        }

        public GameWindow GameWindow
        {
            get
            {
                return m_GameWindow;
            }

            set
            {
                m_GameWindow = value;
            }
        }

        public void SetTheGame(object sender, EventArgs e)
        {
            m_StateOfSecondPlayer = GameSettingsWindow.StateOfSecondPlayer;
            m_SizeOfBoard = GameSettingsWindow.SizeOfBoard;
            startGame();
        }

        private void startGame()
        {
            DialogResult result;

            do
            {
                GameWindow = new GameWindow(new GameManager("Yellow", "Red", m_StateOfSecondPlayer, m_SizeOfBoard), r_PlayerPoints);
                GameWindow.ShowDialog();
                result = GameWindow.DialogResult;
            }
            while (result == DialogResult.Yes);
        }
    }
}
