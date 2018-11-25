using AnacondaFramework.Interfaces;
using System;

namespace AnacondaFramework.Models.ForConsole
{
    public class GameArea : IArea
    {
        IBox[] boxes = new IBox[0];//препятствия
        public int Width { get; set; } 

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public IBox[] GetBoxes()
        {
            return boxes;
        }
        public ConsoleColor Color
        {
            get;set;
        }
        public void Show()
        {
            Console.Title = "Удавчик";
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
            Console.WindowLeft = X;
            Console.WindowTop = Y;
            Console.SetBufferSize(Width + X, Height + Y);
            Console.BackgroundColor = Color;
            Console.CursorVisible = false;
            Console.Clear();

            foreach (IBox box in boxes)
            {
                box.Show();
            }
        }
    }
}
