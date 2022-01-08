﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleVkManager.Tools
{
    internal class Logger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now}] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public string Input(string title)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now}] ");
            Console.Write(title + ": ");
            var input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        public void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now}] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{DateTime.Now}] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
