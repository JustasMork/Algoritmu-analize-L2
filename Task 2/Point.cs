namespace L2
{
    class Point
    {
        protected int x;
        protected int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public bool isDifferent(Point point)
        {

            if (point.getX() == x && point.getY() == y)
                return false;
            return true;
        }


        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }
    }
}
