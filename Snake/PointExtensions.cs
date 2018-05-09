using System.Drawing;

namespace Snake
{
    public static class PointExtensions
    {
        public static Point Add(this Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}