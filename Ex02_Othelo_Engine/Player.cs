namespace Ex02_Othelo_Engine
{
    public class Player
    {
        public enum eStateOfPlayer
        {
            Human,
            Computer
        }

        private readonly string r_FullName;
        private readonly Coin.eCoinColor r_PlayerColor;
        private readonly eStateOfPlayer r_PlayerState;

        public Player(string i_FullName, Coin.eCoinColor i_PlayerColor, eStateOfPlayer i_PlayerState)
        {
            r_PlayerState = i_PlayerState;

            if (i_FullName != null)
            {
                r_FullName = i_FullName;
            }

            if (i_PlayerColor != Coin.eCoinColor.Uninitiliazed)
            {
                r_PlayerColor = i_PlayerColor;
            }
        }

        public string GetPlayerName
        {
            get
            {
                return r_FullName;
            }
        }

        public Coin.eCoinColor GetPlayerColor
        {
            get
            {
                return r_PlayerColor;
            }
        }

        public eStateOfPlayer GetStateOfPlayer
        {
            get
            {
                return r_PlayerState;
            }
        }
    }
}
