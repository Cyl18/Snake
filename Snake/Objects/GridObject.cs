using System;
using System.Drawing;

namespace Snake.Objects
{
    public abstract class GridObject : IDrawable
    {
        public Point Point { get; internal set; }
        public abstract ConsoleColor Color { get; }
    }

    public interface IDrawable
    {
        ConsoleColor Color { get; }
    }
}