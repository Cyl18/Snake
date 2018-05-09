using System;
using System.Drawing;

namespace Snake
{
    public enum Direction
    {
        Left,
        Right,
        Down,
        Up
    }

    public static class DirectionExtensions
    {
        public static Direction? ToDirection(this ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return Direction.Left;

                case ConsoleKey.RightArrow:
                    return Direction.Right;

                case ConsoleKey.DownArrow:
                    return Direction.Down;

                case ConsoleKey.UpArrow:
                    return Direction.Up;

                default:
                    return null;
            }
        }

        public static Point GetTransformPoint(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(-1, 0);

                case Direction.Right:
                    return new Point(1, 0);

                case Direction.Down:
                    return new Point(0, 1);

                case Direction.Up:
                    return new Point(0, -1);

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}