using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex02_Othelo_Engine;

namespace OthelloWindowsApplication
{
    public partial class GameWindow : Form
    {
        private const int k_SizeOfButton = 50;
        private readonly Control[,] r_ControlsArray;
        private readonly GameManager r_GameEngine;
        private readonly Dictionary<string, int> r_PlayerPoints;
        private readonly System.Windows.Forms.Timer r_Timer;
        private int m_PlayersWithoutMoves;

        public GameWindow(GameManager i_GameEngine, Dictionary<string, int> io_PlayerPoints)
        {
            InitializeComponent();
            r_Timer = new System.Windows.Forms.Timer();
            r_Timer.Tick += new EventHandler(timer_Ticked);
            r_Timer.Interval = 1000;
            r_PlayerPoints = io_PlayerPoints;
            r_GameEngine = i_GameEngine;
            m_PlayersWithoutMoves = 0;
            r_ControlsArray = new System.Windows.Forms.Control[r_GameEngine.GetSizeOfBoard(), r_GameEngine.GetSizeOfBoard()];
            this.ClientSize = new Size((k_SizeOfButton * r_GameEngine.GetSizeOfBoard()) + 20, (k_SizeOfButton * r_GameEngine.GetSizeOfBoard()) + 20);
            initializeButtonArray();
            managePlayerWindow();
        }

        private void initializeButtonArray()
        {
            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    StringBuilder buttonNameBuilder = new StringBuilder();

                    r_ControlsArray[i, j] = new Button();
                    r_ControlsArray[i, j].Size = new System.Drawing.Size(k_SizeOfButton, k_SizeOfButton);
                    buttonNameBuilder.AppendFormat("{0},{1}", i, j);
                    r_ControlsArray[i, j].TabStop = false;
                    r_ControlsArray[i, j].Name = buttonNameBuilder.ToString();
                    r_ControlsArray[i, j].Text = string.Empty;
                    ((Button)this.r_ControlsArray[i, j]).UseVisualStyleBackColor = true;
                    this.Controls.Add(r_ControlsArray[i, j]);
                    r_ControlsArray[i, j].Click += new System.EventHandler(this.button_Clicked);
                }
            }

            initalizeButtonLocation();
        }

        private void initalizeButtonLocation()
        {
            System.Drawing.Point location = new System.Drawing.Point();
            int buttonHeightStartLocation = Top + 10;
            int buttonWidthStartLocation = Left + 10;

            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                location.Y = buttonHeightStartLocation + (k_SizeOfButton * i);
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    location.X = buttonWidthStartLocation + (k_SizeOfButton * j);
                    r_ControlsArray[i, j].Location = location;
                }
            }
        }

        private void initalizePictureBox(int i_Row, int i_Column)
        {
            PictureBox newPictureBox = new PictureBox();

            newPictureBox.Size = r_ControlsArray[i_Row, i_Column].Size;
            newPictureBox.Name = r_ControlsArray[i_Row, i_Column].Name;
            newPictureBox.Text = string.Empty;
            newPictureBox.Location = r_ControlsArray[i_Row, i_Column].Location;
            newPictureBox.BorderStyle = BorderStyle.Fixed3D;
            Controls.Remove(r_ControlsArray[i_Row, i_Column]);
            r_ControlsArray[i_Row, i_Column] = newPictureBox;
            Controls.Add(r_ControlsArray[i_Row, i_Column]);
        }

        private void managePlayerWindow()
        {
            List<Ex02_Othelo_Engine.Point> possiblePlayerMovesArray;

            windowText();
            updateCoinsOfBoard();
            possiblePlayerMovesArray = r_GameEngine.checkPossiblePlayerMoves();
            updatePossibleMovesOfCurrentPlayer(possiblePlayerMovesArray);
            if (r_GameEngine.isBoardFull())
            {
                handleEndGame();
            }
            else if(m_PlayersWithoutMoves == 2)
            {
                noMoreOptionsMessage();
            }
            else
            {
                if (possiblePlayerMovesArray.Count == 0)
                {
                    m_PlayersWithoutMoves++;
                    playerSwitchMessage(r_GameEngine.getCurrentPlayerName);
                    r_GameEngine.switchPlayerTurn();
                    if (r_GameEngine.GetStateOfCurrentPlayer() == Player.eStateOfPlayer.Computer)
                    {
                        r_Timer.Start();
                    }
                    else
                    {
                        managePlayerWindow();
                    }
                }
                else
                {
                    m_PlayersWithoutMoves = 0;
                }
            }
        }

        private void timer_Ticked(object sender, EventArgs e)
        {
            r_Timer.Stop();
            manageComputerWindow();
        }

        private void manageComputerWindow()
        {
            List<Ex02_Othelo_Engine.Point> possiblePlayerMovesArray;

            possiblePlayerMovesArray = r_GameEngine.checkPossiblePlayerMoves();
            updatePossibleMovesOfCurrentPlayer(possiblePlayerMovesArray);
            if (r_GameEngine.isBoardFull())
            {
                handleEndGame();
            }
            else if (m_PlayersWithoutMoves == 2)
            {
                noMoreOptionsMessage();
            }
            else
            {
                if (possiblePlayerMovesArray.Count == 0)
                {
                    m_PlayersWithoutMoves++;
                    playerSwitchMessage(r_GameEngine.getCurrentPlayerName);
                    r_GameEngine.switchPlayerTurn();
                }
                else
                {
                    m_PlayersWithoutMoves = 0;
                    choosePossibleMove(possiblePlayerMovesArray);
                }

                managePlayerWindow();
            }
        }

        private void playerSwitchMessage(string i_CurrentPlayerName)
        {
            StringBuilder playerSwitch = new StringBuilder();

            playerSwitch.AppendFormat("{0} player has no valid moves, and therefore the turn will switch to the other player", i_CurrentPlayerName);
            MessageBox.Show(playerSwitch.ToString(), "Othello");
        }

        private void noMoreOptionsMessage()
        {
            StringBuilder noMoreOptionsStr = new StringBuilder();

            noMoreOptionsStr.Append("Neither of the players have any valid options, and therefore the game will end");
            MessageBox.Show(noMoreOptionsStr.ToString(), "Othello");
            handleEndGame();
        }

        private void updatePossibleMovesOfCurrentPlayer(List<Ex02_Othelo_Engine.Point> i_PossiblePlayerMovesArray)
        {
            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    if (i_PossiblePlayerMovesArray.Contains(new Ex02_Othelo_Engine.Point(i, j)))
                    {
                        this.r_ControlsArray[i, j].Enabled = Enabled;
                        this.r_ControlsArray[i, j].BackColor = Color.ForestGreen;
                    }
                    else
                    {
                        if (r_ControlsArray[i, j] is Button)
                        {
                            ((Button)this.r_ControlsArray[i, j]).UseVisualStyleBackColor = true;
                        }

                        this.r_ControlsArray[i, j].Enabled = false;
                    }
                }
            }
        }

        private void choosePossibleMove(List<Ex02_Othelo_Engine.Point> i_PossiblePlayerMovesArray)
        {
            Random randomOption = new Random();
            int randomMoveNumber;

            randomMoveNumber = randomOption.Next(0, i_PossiblePlayerMovesArray.Count - 1);
            r_GameEngine.updateBoardGame(i_PossiblePlayerMovesArray[randomMoveNumber]);
            r_GameEngine.switchPlayerTurn();
        }

        private void updateCoinsOfBoard()
        {
            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    if (r_GameEngine.GetMatrixBoard.GetCoin(i, j).StateOfCoin == Coin.eCoinColor.Black)
                    {
                        if (this.r_ControlsArray[i, j] is Button)
                        {
                            initalizePictureBox(i, j);
                        }

                        ((PictureBox)r_ControlsArray[i, j]).Image = OthelloWindowsApplication.Properties.Resources.CoinRed;
                        ((PictureBox)r_ControlsArray[i, j]).SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else if (r_GameEngine.GetMatrixBoard.GetCoin(i, j).StateOfCoin == Coin.eCoinColor.White)
                    {
                        if (this.r_ControlsArray[i, j] is Button)
                        {
                            initalizePictureBox(i, j);
                        }

                        ((PictureBox)r_ControlsArray[i, j]).Image = OthelloWindowsApplication.Properties.Resources.CoinYellow;
                        ((PictureBox)r_ControlsArray[i, j]).SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void windowText()
        {
            StringBuilder windowText = new StringBuilder();

            windowText.AppendFormat("Othello - {0}'s Turn", r_GameEngine.getCurrentPlayerName);
            this.Text = windowText.ToString();
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Button)sender).Enabled = false;
            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    if (sender == this.r_ControlsArray[i, j])
                    {
                        r_GameEngine.updateBoardGame(new Ex02_Othelo_Engine.Point(i, j));
                    }
                }
            }

            r_GameEngine.switchPlayerTurn();
            if (r_GameEngine.GetStateOfCurrentPlayer() == Player.eStateOfPlayer.Computer)
            {
                windowText();
                updateCoinsOfBoard();
                lockButtons();
                r_Timer.Start();         
            }
            else
            {
                managePlayerWindow();
            }
        }

        private void lockButtons()
        {
            for (int i = 0; i < r_GameEngine.GetSizeOfBoard(); ++i)
            {
                for (int j = 0; j < r_GameEngine.GetSizeOfBoard(); ++j)
                {
                    if (r_ControlsArray[i, j] is Button)
                    {
                        ((Button)this.r_ControlsArray[i, j]).UseVisualStyleBackColor = true;
                    }

                    this.r_ControlsArray[i, j].Enabled = false;
                }
            }
        }

        private void handleEndGame()
        {
            int currentPlayerPoints, oppositePlayerPoints;
            StringBuilder endGameMessage = new StringBuilder();
            string currentPlayerName, oppositePlayerName;

            currentPlayerName = r_GameEngine.getCurrentPlayerName;
            oppositePlayerName = r_GameEngine.getOppositePlayerName;
            r_GameEngine.checkAmountOfPoints(out currentPlayerPoints, out oppositePlayerPoints);
            if (currentPlayerPoints > oppositePlayerPoints)
            {
                r_PlayerPoints[currentPlayerName]++;
                endGameMessage.AppendFormat(@"{0} Won!! ({1}/{2}) ({3}/{4}){5}", currentPlayerName, currentPlayerPoints, oppositePlayerPoints, r_PlayerPoints[oppositePlayerName], r_PlayerPoints[currentPlayerName], Environment.NewLine);
            }
            else if (currentPlayerPoints < oppositePlayerPoints)
            {
                r_PlayerPoints[oppositePlayerName]++;
                endGameMessage.AppendFormat(@"{0} Won!! ({1}/{2}) ({3}/{4}){5}", oppositePlayerName, oppositePlayerPoints, currentPlayerPoints, r_PlayerPoints[currentPlayerName], r_PlayerPoints[oppositePlayerName], Environment.NewLine);
            }
            else
            {
                r_PlayerPoints[currentPlayerName]++;
                r_PlayerPoints[oppositePlayerName]++;
                endGameMessage.AppendFormat(@"Both players have {0} points{1}", currentPlayerPoints, Environment.NewLine);
            }

            endGameMessage.Append("Would you like another round?");
            DialogResult = MessageBox.Show(endGameMessage.ToString(), "Othello", MessageBoxButtons.YesNo);
            this.Close();
        }
    }
}
