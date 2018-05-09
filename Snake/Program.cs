using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        private static volatile SnakeGame _currentGame;

        private static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                    if (_currentGame != null)
                        _currentGame.PendingTurn = Console.ReadKey().Key.ToDirection();
            });
            while (true)
            {
                _currentGame = new SnakeGame();
                while (_currentGame.Tick()) Thread.Sleep(300);
                Thread.Sleep(2000);
            }
        }
    }
}