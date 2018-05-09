using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using Snake.Objects;

namespace Snake
{
    public class Snake : IEnumerable<SnakeComponent>
    {
        public SnakeHead Head { get; }

        public Snake(SnakeHead head)
        {
            Head = head;
        }

        public IEnumerator<SnakeComponent> GetEnumerator()
        {
            return AsEnumerable().GetEnumerator();
        }

        private IEnumerable<SnakeComponent> AsEnumerable()
        {
            yield return Head;
            SnakeComponent cobj = Head;

            while ((cobj = cobj.NextComponent) != null)
            {
                yield return cobj;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point GetNextPoint()
        {
            return Head.Point.Add(Head.Direction.GetTransformPoint());
        }
    }
}