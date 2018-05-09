using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Snake.Objects;

namespace Snake
{
    public class Snake : IEnumerable<SnakeComponent>
    {
        public Snake(SnakeHead head)
        {
            Head = head;
        }

        public SnakeHead Head { get; }

        public IEnumerator<SnakeComponent> GetEnumerator()
        {
            return AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<SnakeComponent> AsEnumerable()
        {
            yield return Head;
            SnakeComponent cobj = Head;

            while ((cobj = cobj.NextComponent) != null) yield return cobj;
        }

        public Point GetNextPoint()
        {
            return Head.Point.Add(Head.Direction.GetTransformPoint());
        }
    }
}