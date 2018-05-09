using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Snake.Objects;

namespace Snake
{
    public class Grid : IEnumerable<GridObject>
    {
        public Grid(Size size)
        {
            Width = size.Width;
            Height = size.Height;
            Objects = new GridObject[size.Width, size.Height];
        }

        public GridObject[,] Objects { get; }
        public int Width { get; }
        public int Height { get; }

        public IEnumerator<GridObject> GetEnumerator()
        {
            return Objects.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public GridObject Get(Point point)
        {
            return IsOutOfGrid(point) ? null : Objects[point.X, point.Y];
        }

        public bool IsOutOfGrid(Point point)
        {
            return point.X >= Width || point.Y >= Height || point.X < 0 || point.Y < 0;
        }

        public GridObject GetWithoutChecking(Point point)
        {
            return Objects[point.X, point.Y];
        }

        public void Set(Point point, GridObject obj)
        {
            Objects[point.X, point.Y] = obj;
            if (obj != null) obj.Point = point;
        }
    }
}