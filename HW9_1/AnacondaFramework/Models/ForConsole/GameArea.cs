using AnacondaFramework.Interfaces;
using HW9_1.AnacondaFramework.Models.ForConsole;
using System;

namespace AnacondaFramework.Models.ForConsole
{
    public class GameArea : IArea
    {
        static Random r = new Random();

        public int Width { get; set; } 
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        IBox[] boxes; //препятствия
        public void CreatBox(int count)
        {
            boxes = new IBox[count];
            for (int i = 0; i < count; i++)
            {
                boxes[i] = new Box() { X = r.Next(1, Width - 1), Y = r.Next(1, Height - 1), BoxColor = (ConsoleColor)r.Next(2, 12) };
            }
        }
        public IBox[] GetBoxes()
        {
            return boxes;
        }
        public ConsoleColor Color { get; set; }
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
        }
        public void ShowBox()
        {
            if (boxes != null)
            {
                foreach (IBox box in boxes)
                {
                    box.Show();
                }
            }
        }
    }
}
