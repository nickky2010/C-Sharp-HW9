using AnacondaFramework.Interfaces;
using System;

namespace HW9_1.AnacondaFramework.Models.ForConsole
{
    class Box : IBox
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor BoxColor { get; set; }
        public void Show()
        {
            Console.ForegroundColor = BoxColor;
            Console.SetCursorPosition(X, Y);
            Console.Write('▓');
        }
    }
}
