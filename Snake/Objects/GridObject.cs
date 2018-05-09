using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake.Objects
{
    public abstract class GridObject : IDrawable
    {
        public abstract ConsoleColor Color { get; }
        public Point Point { get; internal set; }
    }

    public interface IDrawable
    {
        ConsoleColor Color { get; }
    }
}