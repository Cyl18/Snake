using System;

namespace Snake.Objects
{
    internal class SnakeBody : SnakeComponent
    {
        public override ConsoleColor Color { get; } = ConsoleColor.White;
    }
}