using System;

namespace Snake.Objects
{
    internal class Food : GridObject
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Red;
    }
}