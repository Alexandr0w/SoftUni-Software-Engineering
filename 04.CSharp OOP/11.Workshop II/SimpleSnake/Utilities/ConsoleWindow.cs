﻿using System;
using System.Text;

namespace SimpleSnake.Utilities
{
    public static class ConsoleWindow
    {
        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}
