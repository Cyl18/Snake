using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake.Objects
{
    internal class Food : GridObject
    {
        public override ConsoleColor Color { get; } = ConsoleColor.Red;
    }
}