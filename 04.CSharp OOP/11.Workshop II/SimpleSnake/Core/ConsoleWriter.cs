using SimpleSnake.GameObjects;
using SimpleSnake.Interfaces;
using System;

namespace SimpleSnake.Core
{
    public class ConsoleWriter : IWriter
    {
        public void Write(Point point, char symbol)
        {
            Console.CursorLeft = point.X;
            Console.CursorTop = point.Y;

            Console.Write(symbol);
        }
    }
}
