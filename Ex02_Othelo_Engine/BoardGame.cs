namespace Ex02_Othelo_Engine
{
    public class BoardGame
    {
        private readonly int r_SizeOfBoard;
        private readonly Coin[,] r_BoardMatrix;

        public BoardGame(int i_SizeOfBoard)
        {
            r_SizeOfBoard = i_SizeOfBoard;
            r_BoardMatrix = new Coin[r_SizeOfBoard, r_SizeOfBoard];
            for (int i = 0; i < i_SizeOfBoard; ++i)
            {
                for (int j = 0; j < i_SizeOfBoard; ++j)
                {
                    r_BoardMatrix[i, j] = new Coin(Coin.eCoinColor.Uninitiliazed);
                }
            }

            initilizedBoard();
        }

        private void initilizedBoard()
        {
            int middleOfBoardPosition = r_SizeOfBoard / 2;

            r_BoardMatrix[middleOfBoardPosition - 1, middleOfBoardPosition - 1].StateOfCoin = Coin.eCoinColor.White;
            r_BoardMatrix[middleOfBoardPosition - 1, middleOfBoardPosition].StateOfCoin = Coin.eCoinColor.Black;
            r_BoardMatrix[middleOfBoardPosition, middleOfBoardPosition - 1].StateOfCoin = Coin.eCoinColor.Black;
            r_BoardMatrix[middleOfBoardPosition, middleOfBoardPosition].StateOfCoin = Coin.eCoinColor.White;
        }

        public int GetTheNumberOfCoinsWithSameColor(Coin.eCoinColor i_CoinColorInput)
        {
            int countTheNumberOfSameColorCoin = 0;

            foreach (Coin coin in r_BoardMatrix)
            {
                if (coin.StateOfCoin == i_CoinColorInput)
                {
                    ++countTheNumberOfSameColorCoin;
                }
            }

            return countTheNumberOfSameColorCoin;
        }

        public Coin GetCoin(int i_CoordinateX, int i_CoordinateY)
        {
            return r_BoardMatrix[i_CoordinateX, i_CoordinateY];
        }

        public int GetSizeOfBoard
        {
            get
            {
                return r_SizeOfBoard;
            }
        }

        public Coin[,] GetBoardMatrix
        {
            get
            {
                return r_BoardMatrix;
            }
        }
    }
}
