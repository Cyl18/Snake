using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Snake.Objects;

namespace Snake
{
    public class SnakeGame
    {
        public Grid Grid { get; }
        public Direction? PendingTurn { get; internal set; }
        public bool PendingExpand { get; private set; }
        public Snake Snake { get; }
        private readonly Random _random = new Random();

        public SnakeGame()
        {
            Grid = new Grid(new Size(20, 20));
            Drawer = new ConsoleDrawer(Grid);

            var head = new SnakeHead();
            Grid.Set(GetRandomPoint(), head);
            Snake = new Snake(head);
        }

        private Point GetRandomPoint()
        {
            while (true)
            {
                var x = _random.Next(Grid.Width);
                var y = _random.Next(Grid.Height);
                var ptr = new Point(x, y);
                if (Grid.Get(ptr) == null) return ptr;
            }
        }

        public bool Tick()
        {
            TickPendingTurn();
            TickExpand();
            if (TickMove())
            {
                TickFood();
                TickDraw();
                return true;
            }
            else
            {
                GameOver();
                return false;
            }
        }

        private void TickDraw()
        {
            Drawer.Draw();
        }

        private void TickFood()
        {
            if (!Grid.Any(obj => obj is Food))
            {
                var point = GetRandomPoint();
                Grid.Set(point, new Food());
            }
        }

        private void TickExpand()
        {
            if (PendingExpand)
            {
                PendingExpand = false;
                if (Snake.Head.NextComponent == null)
                {
                    var tp = Snake.Head.Direction.GetTransformPoint();
                    var point = Snake.Head.Point.Add(new Point(-tp.X, -tp.Y));
                    var body = new SnakeBody();
                    Snake.Head.NextComponent = body;
                    Grid.Set(point, body);
                }
            }
            else
            {
                var components = Snake.ToArray();
                var i = components.Length - 2;
                if (i >= 0)
                {
                    components[i].NextComponent = null;
                    Grid.Set(components[i + 1].Point, null);
                }
            }
        }

        private bool TickMove()
        {
            var nextPoint = Snake.GetNextPoint();
            var obj = Grid.Get(nextPoint);
            if (Grid.IsOutOfGrid(nextPoint) || obj is SnakeComponent) return false;
            if (obj is Food) PendingExpand = true;

            var currentPoint = Snake.Head.Point;
            var previousObj = Snake.Head.NextComponent;

            Grid.Set(nextPoint, Snake.Head);
            if (Snake.Head.NextComponent == null)
            {
                Grid.Set(currentPoint, null);
                return true;
            }

            var newBody = new SnakeBody { NextComponent = previousObj };
            Grid.Set(currentPoint, newBody);

            Snake.Head.NextComponent = newBody;
            return true;
        }

        private void TickPendingTurn()
        {
            if (PendingTurn != null)
            {
                Snake.Head.Direction = PendingTurn.Value;
                PendingTurn = null;
            }
        }

        private void GameOver()
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {Snake.Count()}");
        }

        public ConsoleDrawer Drawer { get; set; }
    }
}