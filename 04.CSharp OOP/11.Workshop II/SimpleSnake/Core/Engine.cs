using SimpleSnake.GameObjects;
using SimpleSnake.Interfaces;
using System;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private const char WallSymbol = '\u25A0';

        private readonly Playground _playground;
        private readonly IWriter _writer;

        public Engine(Playground playground,IWriter writer)
        {
            this._playground = playground ?? throw new ArgumentNullException(nameof(playground));
            this._writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Run()
        {
            this.WritePlayground();

            Snake snake = new Snake(new Point(1, 1), new Point(1, 0));
            this._writer.Write(snake.Head, 'S');

            for (int i = 1; i < 5; i++)
            {
                snake.Grow();
                this._writer.Write(snake.Head, 'S');
            }
        }

        private void WritePlayground()
        {
            for (int i = 0; i <= this._playground.Width + 1; i++)
            {
                this._writer.Write(new Point(i, 0), WallSymbol);
                this._writer.Write(new Point(i, this._playground.Height + 1), WallSymbol);
            }

            for (int i = 0; i <= this._playground.Height; i++)
            {
                this._writer.Write(new Point(0, i), WallSymbol);
                this._writer.Write(new Point(this._playground.Width + 1, i), WallSymbol);
            }
        }
    }
}
