namespace Ex02_Othelo_Engine
{
    public struct Point
    {
        private readonly int r_CoordinateX;
        private readonly int r_CoordinateY;

        public Point(int i_CoordinateX, int i_CoordinateY)
        {
            r_CoordinateX = i_CoordinateX;
            r_CoordinateY = i_CoordinateY;
        }

        public int CoordinateX
        {
            get
            {
                return r_CoordinateX;
            }
        }

        public int CoordinateY
        {
            get
            {
                return r_CoordinateY;
            }
        }
    }
}
