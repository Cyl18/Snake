using Snake.Objects;

namespace Snake
{
    public abstract class SnakeComponent : GridObject
    {
        public SnakeComponent NextComponent { get; internal set; }
    }
}