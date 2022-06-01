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

        public IEnumerator<GridObject> GetEnumerator() => Objects.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public GridObject Get(Point point) => IsOutOfGrid(point) ? null : Objects[point.X, point.Y];

        public GridObject GetWithoutChecking(Point point) => Objects[point.X, point.Y];

        public void Set(Point point, GridObject obj)
        {
            Objects[point.X, point.Y] = obj;
            if (obj != null) obj.Point = point;
        }


        // 是否越界

        public bool IsOutOfGrid(Point point) => point.X >= Width || point.Y >= Height || point.X < 0 || point.Y < 0;
    }
}