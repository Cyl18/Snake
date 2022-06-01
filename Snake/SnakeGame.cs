using System;
using System.Drawing;
using System.Linq;
using Snake.Objects;

namespace Snake
{
    public class SnakeGame
    {
        private readonly Random _random = new Random();

        public SnakeGame()
        {
            Grid = new Grid(new Size(20, 20));
            Drawer = new ConsoleDrawer(Grid);

            var body2 = new SnakeBody();
            var body1 = new SnakeBody();
            body1.NextComponent = body2;
            var head = new SnakeHead();
            head.NextComponent = body1;
            
            Grid.Set(GetRandomPointForHead(), head);
            Snake = new Snake(head);
            TickMove();
        }

        public Grid Grid { get; }
        public Direction? PendingTurn { get; internal set; }
        public bool PendingExpand { get; private set; }
        public Snake Snake { get; }

        public ConsoleDrawer Drawer { get; set; }

        private Point GetRandomPointForHead()
        {
            while (true)
            {
                var x = _random.Next(3, Grid.Width - 3);
                var y = _random.Next(3, Grid.Height - 3);
                var ptr = new Point(x, y);
                if (Grid.Get(ptr) == null) return ptr;
            }
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
            if (TickMove())
            {
                TickFood();
                TickDraw();
                return true;
            }

            GameOver();
            return false;
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
        
        private bool TickMove()
        {
            // 获取蛇头指向的下一个点
            var nextPoint = Snake.GetNextPoint();
            var obj = Grid.Get(nextPoint);

            // 如果出界或者撞到身体则判断游戏结束
            if (Grid.IsOutOfGrid(nextPoint) || obj is SnakeComponent) return false;
            // 如果遇到食物则判定要伸展
            if (obj is Food) PendingExpand = true;

            var currentPoint = Snake.Head.Point;

            // 设置蛇头指向的点为蛇头
            Grid.Set(nextPoint, Snake.Head);

            // 将当前蛇头的点设置为一段新的身体
            var previousObj = Snake.Head.NextComponent;
            var newBody = new SnakeBody { NextComponent = previousObj };
            Grid.Set(currentPoint, newBody);
            Snake.Head.NextComponent = newBody;

            // 如果要伸展，则什么都不做
            if (PendingExpand)
            {
                PendingExpand = false;
            }
            else
            {
                // 否则把最后一个物件清除
                var components = Snake.ToArray();
                var i = components.Length - 2;
                if (i >= 0)
                {
                    components[i].NextComponent = null;
                    Grid.Set(components[i + 1].Point, null);
                }
            }

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

    }
}