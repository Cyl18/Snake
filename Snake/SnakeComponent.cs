using System;
using System.Collections.Generic;
using System.Text;
using Snake.Objects;

namespace Snake
{
    public abstract class SnakeComponent : GridObject
    {
        public SnakeComponent NextComponent { get; internal set; }
    }
}