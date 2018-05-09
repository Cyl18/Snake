using System;

namespace Snake.Objects
{
    public class SnakeHead : SnakeComponent
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Cyan;
        public Direction Direction { get; internal set; }
    }
}