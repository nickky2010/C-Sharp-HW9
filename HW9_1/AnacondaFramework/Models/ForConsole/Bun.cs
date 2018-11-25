using HW9_1.AnacondaFramework.Interfaces;
using System;

namespace HW9_1.AnacondaFramework.Models.ForConsole
{
    public class Bun : IBun
    {
        public int X { get; set; }
        public int Y { get; set; }
        Random random = new Random();
        public void Show()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('&');
        }
        public void ChangePosition (int width, int height)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            X = random.Next(1, width-1);
            Y = random.Next(1, height-1);
        }
    }
}
