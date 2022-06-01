using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        private static volatile SnakeGame _currentGame;

        public static void Main(string[] args)
        {
            // 开一个线程来读取键盘输入
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var dir = Console.ReadKey().Key.ToDirection();
                    if (_currentGame != null)
                        _currentGame.PendingTurn = dir;
                }
            }, TaskCreationOptions.LongRunning);

            while (true)
            {
                _currentGame = new SnakeGame();
                while (_currentGame.Tick()) Thread.Sleep(300);
                // 一局游戏之后显示2s结果
                Thread.Sleep(2000);
            }
        }

    }
}