using System;
using System.Drawing;
using Snake.Objects;

namespace Snake
{
    public class ConsoleDrawer
    {
        public ConsoleDrawer(Grid grid)
        {
            Grid = grid;
            Console.Clear();
            Console.SetWindowSize(grid.Width, GetHeight(grid) + 1);
            Console.SetBufferSize(grid.Width, GetHeight(grid) + 1);
            Console.CursorVisible = false;
        }

        public Grid Grid { get; }

        private static int GetHeight(Grid grid)
        {
            return (int)Math.Ceiling(grid.Width / 2.0);
        }

        public void Draw()
        {
            Console.Clear();

            var lastf = ConsoleColor.Gray;
            var lastb = ConsoleColor.Gray;

            for (var y = 0; y < GetHeight(Grid); y++)
                for (var x = 0; x < Grid.Width; x++)
                {
                    var yup = y * 2;
                    var ydown = y * 2 + 1;
                    var up = Grid.GetWithoutChecking(new Point(x, yup));
                    var down = Grid.Get(new Point(x, ydown));
                    var foregroundColor = GetColor(up);
                    var backgroundColor = GetColor(down);
                    if (lastf != foregroundColor) // performance
                    {
                        Console.ForegroundColor = foregroundColor;
                        lastf = foregroundColor;
                    }

                    if (lastb != backgroundColor)
                    {
                        Console.BackgroundColor = backgroundColor;
                        lastb = backgroundColor;
                    }

                    Console.Write('▀');
                }
            //if (y != GetHeight(Grid) - 1) Console.WriteLine();
        }

        private ConsoleColor GetColor(GridObject up)
        {
            return up?.Color ?? ConsoleColor.Black;
        }
    }
}