using System.Collections.Generic;

namespace Ex02_Othelo_Engine
{
    public class GameManager
    {
        private const int k_NumOfPlayers = 2;
        private readonly Player[] r_PlayersArray;
        private readonly BoardGame r_BoardMatrix;
        private Player m_CurrentTurn;

        public GameManager(string i_FirstName, string i_SecondName, Player.eStateOfPlayer i_SecondPlayerState, int i_sizeOfBoard)
        {
            r_PlayersArray = new Player[k_NumOfPlayers] { new Player(i_FirstName, Coin.eCoinColor.White, Player.eStateOfPlayer.Human), new Player(i_SecondName, Coin.eCoinColor.Black, i_SecondPlayerState) };
            m_CurrentTurn = r_PlayersArray[0];
            r_BoardMatrix = new BoardGame(i_sizeOfBoard);
        }

        public int GetSizeOfBoard()
        {
            return r_BoardMatrix.GetSizeOfBoard;
        }

        public List<Point> checkPossiblePlayerMoves()
        {
            List<Point> possiblePlayerMovesArray = new List<Point>();

            checkPossiblePlayerMovesInY(possiblePlayerMovesArray);
            checkPossiblePlayerMovesInX(possiblePlayerMovesArray);
            checkPossiblePlayerMovesInDiagonal(possiblePlayerMovesArray);

            return possiblePlayerMovesArray;
        }

        private Player getOppositePlayer
        {
            get
            {
                Player oppositePlayer;

                if (m_CurrentTurn == r_PlayersArray[0])
                {
                    oppositePlayer = r_PlayersArray[1];
                }
                else
                {
                    oppositePlayer = r_PlayersArray[0];
                }

                return oppositePlayer;
            }
        }

        public string getCurrentPlayerName
        {
            get
            {
                return m_CurrentTurn.GetPlayerName;
            }
        }

        public string getOppositePlayerName
        {
            get
            {
                return getOppositePlayer.GetPlayerName;
            }
        }

        private void checkPossiblePlayerMovesInDiagonal(List<Point> i_PossiblePlayerMovesArray)
        {
            CheckPossiblePlayerMovesInAscendingRightDiagonal(i_PossiblePlayerMovesArray);
            CheckPossiblePlayerMovesInDescendingLeftDiagonal(i_PossiblePlayerMovesArray);
            CheckPossiblePlayerMovesInDescendingRightDiagonal(i_PossiblePlayerMovesArray);
            CheckPossiblePlayerMovesInAscendingLeftDiagonal(i_PossiblePlayerMovesArray);
        }

        private void CheckPossiblePlayerMovesInAscendingRightDiagonal(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;
            int matrix_size = r_BoardMatrix.GetSizeOfBoard - 1;

            for (int x = 0; x <= matrix_size - 2; x++)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = 0; y <= matrix_size - x; y++)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x + y, y);
                }
            }

            for (int y = 1; y <= matrix_size - 2; y++)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int x = 0; x <= matrix_size - y; x++)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, x + y);
                }
            }
        }

        private void CheckPossiblePlayerMovesInDescendingLeftDiagonal(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;
            int matrix_size = r_BoardMatrix.GetSizeOfBoard - 1;

            for (int x = matrix_size - 2; x >= 0; x--)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = matrix_size - x; y >= 0; y--)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x + y, y);
                }
            }

            for (int y = matrix_size - 2; y >= 1; y--)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int x = matrix_size - y; x >= 0; x--)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, x + y);
                }
            }
        }

        private void CheckPossiblePlayerMovesInDescendingRightDiagonal(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;
            int matrix_size = r_BoardMatrix.GetSizeOfBoard - 1;

            for (int x = 0; x <= matrix_size - 2; x++)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = matrix_size; y - x >= 0; y--)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x + matrix_size - y, y);
                }
            }

            for (int y = matrix_size - 1; y >= 2; y--)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int x = 0; x <= y; x++)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y - x);
                }
            }
        }

        private void CheckPossiblePlayerMovesInAscendingLeftDiagonal(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;
            int matrix_size = r_BoardMatrix.GetSizeOfBoard - 1;

            for (int x = 2; x <= matrix_size; x++)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = 0; y <= x; y++)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x - y, y);
                }
            }

            for (int y = 1; y <= matrix_size - 2; y++)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int x = matrix_size; x >= y; x--)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y + matrix_size - x);
                }
            }
        }

        private void checkPossiblePlayerMovesInY(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;

            for (int y = 0; y < r_BoardMatrix.GetSizeOfBoard; ++y)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);

                for (int x = 0; x < r_BoardMatrix.GetSizeOfBoard; ++x)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y);
                }

                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);

                for (int x = r_BoardMatrix.GetSizeOfBoard - 1; x >= 0; --x)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y);
                }
            }
        }

        private void checkPossiblePlayerMovesInX(List<Point> i_PossiblePlayerMovesArray)
        {
            bool v_IsCurrentPlayerColor = true;
            bool v_IsOppositePlayerColor = true;

            for (int x = 0; x < r_BoardMatrix.GetSizeOfBoard; ++x)
            {
                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = 0; y < r_BoardMatrix.GetSizeOfBoard; ++y)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y);
                }

                resetFlagsOfPlayersColors(ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor);
                for (int y = r_BoardMatrix.GetSizeOfBoard - 1; y >= 0; --y)
                {
                    addPossibleMoves(i_PossiblePlayerMovesArray, ref v_IsCurrentPlayerColor, ref v_IsOppositePlayerColor, x, y);
                }
            }
        }

        private void resetFlagsOfPlayersColors(ref bool io_IsCurrentPlayerColor, ref bool io_IsOppositePlayerColor)
        {
            if (io_IsCurrentPlayerColor)
            {
                io_IsCurrentPlayerColor = !io_IsCurrentPlayerColor;
            }

            if (io_IsOppositePlayerColor)
            {
                io_IsOppositePlayerColor = !io_IsOppositePlayerColor;
            }
        }

        private void addPossibleMoves(List<Point> i_PossiblePlayerMovesArray, ref bool io_IsCurrentPlayerColor, ref bool io_IsOppositePlayerColor, int i_CoordinateX, int i_CoordinateY)
        {
            Coin.eCoinColor currentPlayerColor = m_CurrentTurn.GetPlayerColor;
            Coin.eCoinColor currentOppositePlayerColor = getOppositePlayer.GetPlayerColor;

            if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == currentPlayerColor && !io_IsCurrentPlayerColor)
            {
                io_IsCurrentPlayerColor = !io_IsCurrentPlayerColor;
            }

            if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == currentOppositePlayerColor)
            {
                if (io_IsCurrentPlayerColor)
                {
                    if (!io_IsOppositePlayerColor)
                    {
                        io_IsOppositePlayerColor = !io_IsOppositePlayerColor;
                    }
                }
            }
            else if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == currentPlayerColor)
            {
                if (io_IsCurrentPlayerColor && io_IsOppositePlayerColor)
                {
                    io_IsOppositePlayerColor = !io_IsOppositePlayerColor;
                }
            }
            else if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == Coin.eCoinColor.Uninitiliazed)
            {
                if (io_IsCurrentPlayerColor && io_IsOppositePlayerColor)
                {
                    i_PossiblePlayerMovesArray.Add(new Point(i_CoordinateX, i_CoordinateY));
                    io_IsCurrentPlayerColor = !io_IsCurrentPlayerColor;
                    io_IsOppositePlayerColor = !io_IsOppositePlayerColor;
                }
                else if (io_IsCurrentPlayerColor)
                {
                    io_IsCurrentPlayerColor = !io_IsCurrentPlayerColor;
                }
                else if (io_IsOppositePlayerColor)
                {
                    io_IsOppositePlayerColor = !io_IsOppositePlayerColor;
                }
            }
        }

        public void updateBoardGame(Point i_UserInputCoordinate)
        {
            r_BoardMatrix.GetCoin(i_UserInputCoordinate.CoordinateX, i_UserInputCoordinate.CoordinateY).StateOfCoin = m_CurrentTurn.GetPlayerColor;
            updateBoardRow(i_UserInputCoordinate);
            updateBoardColumn(i_UserInputCoordinate);
            updateBoardRisingDiagonal(i_UserInputCoordinate);
            updateBoardDescendingDiagonal(i_UserInputCoordinate);
        }

        private void updateBoardRow(Point i_UserInputCoordinate)
        {
            bool v_IsUserColorFlag = true;
            bool v_IsOppositeUserColorFlag = true;
            bool v_IsLoopContinue = true;
            List<Point> flippedCoinsArray = new List<Point>();

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            for (int x = i_UserInputCoordinate.CoordinateX + 1; x < r_BoardMatrix.GetSizeOfBoard; ++x)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, x, i_UserInputCoordinate.CoordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }
            }

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            flippedCoinsArray.Clear();
            for (int x = i_UserInputCoordinate.CoordinateX - 1; x >= 0; --x)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, x, i_UserInputCoordinate.CoordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }
            }
        }

        private void updateBoardColumn(Point i_UserInputCoordinate)
        {
            bool v_IsUserColorFlag = true;
            bool v_IsOppositeUserColorFlag = true;
            bool v_IsLoopContinue = true;
            List<Point> flippedCoinsArray = new List<Point>();

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            for (int y = i_UserInputCoordinate.CoordinateY - 1; y >= 0; --y)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, i_UserInputCoordinate.CoordinateX, y);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }
            }

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            flippedCoinsArray.Clear();
            for (int y = i_UserInputCoordinate.CoordinateY + 1; y < r_BoardMatrix.GetSizeOfBoard; ++y)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, i_UserInputCoordinate.CoordinateX, y);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }
            }
        }

        private void updateBoardRisingDiagonal(Point i_UserInputCoordinate)
        {
            int coordinateX = i_UserInputCoordinate.CoordinateX + 1, coordinateY = i_UserInputCoordinate.CoordinateY + 1;
            bool v_IsUserColorFlag = true;
            bool v_IsOppositeUserColorFlag = true;
            bool v_IsLoopContinue = true;
            List<Point> flippedCoinsArray = new List<Point>();

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            while (coordinateX >= 0 && coordinateX < r_BoardMatrix.GetSizeOfBoard && coordinateY >= 0 && coordinateY < r_BoardMatrix.GetSizeOfBoard)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, coordinateX, coordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }

                ++coordinateX;
                ++coordinateY;
            }

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            flippedCoinsArray.Clear();
            coordinateX = i_UserInputCoordinate.CoordinateX - 1;
            coordinateY = i_UserInputCoordinate.CoordinateY + 1;
            while (coordinateX >= 0 && coordinateX < r_BoardMatrix.GetSizeOfBoard && coordinateY >= 0 && coordinateY < r_BoardMatrix.GetSizeOfBoard)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, coordinateX, coordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }

                --coordinateX;
                ++coordinateY;
            }
        }

        private void updateBoardDescendingDiagonal(Point i_UserInputCoordinate)
        {
            int coordinateX = i_UserInputCoordinate.CoordinateX - 1, coordinateY = i_UserInputCoordinate.CoordinateY - 1;
            bool v_IsUserColorFlag = true;
            bool v_IsOppositeUserColorFlag = true;
            bool v_IsLoopContinue = true;
            List<Point> flippedCoinsArray = new List<Point>();

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            while (coordinateX >= 0 && coordinateX < r_BoardMatrix.GetSizeOfBoard && coordinateY >= 0 && coordinateY < r_BoardMatrix.GetSizeOfBoard)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, coordinateX, coordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }

                --coordinateX;
                --coordinateY;
            }

            resetFlagsOfPlayersColors(ref v_IsUserColorFlag, ref v_IsOppositeUserColorFlag);
            flippedCoinsArray.Clear();
            coordinateX = i_UserInputCoordinate.CoordinateX + 1;
            coordinateY = i_UserInputCoordinate.CoordinateY - 1;
            while (coordinateX >= 0 && coordinateX < r_BoardMatrix.GetSizeOfBoard && coordinateY >= 0 && coordinateY < r_BoardMatrix.GetSizeOfBoard)
            {
                v_IsLoopContinue = updateCurrentflipCoinsArray(flippedCoinsArray, ref v_IsOppositeUserColorFlag, ref v_IsUserColorFlag, coordinateX, coordinateY);
                if (!v_IsLoopContinue)
                {
                    v_IsLoopContinue = !v_IsLoopContinue;
                    break;
                }

                ++coordinateX;
                --coordinateY;
            }
        }

        private bool updateCurrentflipCoinsArray(List<Point> i_FlippedCoinsArray, ref bool io_IsOppositeUserColorFlag, ref bool io_IsUserColorFlag, int i_CoordinateX, int i_CoordinateY)
        {
            bool v_IsContinueWithLoop = true;
            Coin.eCoinColor currentOppositePlayerColor = this.getOppositePlayer.GetPlayerColor;
            Coin.eCoinColor currentPlayerColor = m_CurrentTurn.GetPlayerColor;

            if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == currentOppositePlayerColor)
            {
                i_FlippedCoinsArray.Add(new Point(i_CoordinateX, i_CoordinateY));
                if (!io_IsOppositeUserColorFlag)
                {
                    io_IsOppositeUserColorFlag = !io_IsOppositeUserColorFlag;
                }
            }
            else if (r_BoardMatrix.GetCoin(i_CoordinateX, i_CoordinateY).StateOfCoin == currentPlayerColor)
            {
                if (io_IsOppositeUserColorFlag)
                {
                    flipCoinsArray(i_FlippedCoinsArray);
                }

                v_IsContinueWithLoop = !v_IsContinueWithLoop;
            }
            else
            {
                v_IsContinueWithLoop = !v_IsContinueWithLoop;
            }

            return v_IsContinueWithLoop;
        }

        private void flipCoinsArray(List<Point> i_FlippedCoinsArray)
        {
            foreach (Point coinCoordinate in i_FlippedCoinsArray)
            {
                r_BoardMatrix.GetCoin(coinCoordinate.CoordinateX, coinCoordinate.CoordinateY).FlipCoin();
            }
        }

        public void switchPlayerTurn()
        {
            m_CurrentTurn = getOppositePlayer;
        }

        public BoardGame GetMatrixBoard
        {
            get
            {
                return r_BoardMatrix;
            }
        }

        public Player GetCurrentUserTurn
        {
            get
            {
                return m_CurrentTurn;
            }
        }

        public int GetTheNumberOfCoinsOfTheCurrentPlayer()
        {
            return r_BoardMatrix.GetTheNumberOfCoinsWithSameColor(m_CurrentTurn.GetPlayerColor);
        }

        public int GetTheNumberOfCoinsOfTheOppositePlayer()
        {
            return r_BoardMatrix.GetTheNumberOfCoinsWithSameColor(getOppositePlayer.GetPlayerColor);
        }

        public Player.eStateOfPlayer GetStateOfCurrentPlayer()
        {
            return m_CurrentTurn.GetStateOfPlayer;
        }

        public bool isBoardFull()
        {
            bool v_IsBoardFull = false;

            if (r_BoardMatrix.GetTheNumberOfCoinsWithSameColor(Coin.eCoinColor.Uninitiliazed) == 0)
            {
                v_IsBoardFull = !v_IsBoardFull;
            }

            return v_IsBoardFull;
        }

        public void checkAmountOfPoints(out int o_PointsOfCurrentPlayer, out int o_PointsOfOppositePlayer)
        {
            o_PointsOfCurrentPlayer = GetTheNumberOfCoinsOfTheCurrentPlayer();
            o_PointsOfOppositePlayer = GetTheNumberOfCoinsOfTheOppositePlayer();
        }
    }
}