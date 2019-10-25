namespace Ex02_Othelo_Engine
{
    public class Coin
    {
        public enum eCoinColor
        {
            Black,
            White,
            Uninitiliazed
        }

        private eCoinColor m_CoinColor;

        public Coin(eCoinColor i_coinColor)
        {
            m_CoinColor = i_coinColor;
        }

        public void FlipCoin()
        {
            if (m_CoinColor == eCoinColor.Black)
            {
                m_CoinColor = eCoinColor.White;
            }
            else if (m_CoinColor == eCoinColor.White)
            {
                m_CoinColor = eCoinColor.Black;
            }
        }

        public eCoinColor StateOfCoin
        {
            get
            {
                return m_CoinColor;
            }

            set
            {
                m_CoinColor = value;
            }
        }

        public eCoinColor GetOppositeColor
        {
            get
            {
                eCoinColor oppositeColor;

                if (m_CoinColor == eCoinColor.Black)
                {
                    oppositeColor = eCoinColor.White;
                }
                else if (m_CoinColor == eCoinColor.White)
                {
                    oppositeColor = eCoinColor.Black;
                }
                else
                {
                    oppositeColor = eCoinColor.Uninitiliazed;
                }

                return oppositeColor;
            }
        }
    }
}
