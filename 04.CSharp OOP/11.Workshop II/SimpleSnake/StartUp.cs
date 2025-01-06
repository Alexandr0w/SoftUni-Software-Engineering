using SimpleSnake.Core;
using SimpleSnake.GameObjects;
using SimpleSnake.Interfaces;
using SimpleSnake.Utilities;
using System;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            IWriter writer = new ConsoleWriter();
            Playground playground = new Playground(60, 20);

            IEngine engine = new Engine(playground, writer);
            engine.Run();

            Console.ReadLine();
        }
    }
}
