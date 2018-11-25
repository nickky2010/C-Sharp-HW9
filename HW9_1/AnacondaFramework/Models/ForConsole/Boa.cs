using AnacondaFramework.Enums;
using AnacondaFramework.Interfaces;
using System;
using System.Collections.Generic;

namespace AnacondaFramework.Models.ForConsole
{
    public class Boa : IBoa
    {
        List<int> snake = new List<int>() { 0, 3, 3, 3, 3 };//змея 
        //0-начало  1-вниз   2-вправо   3-влево   4-вверх
        public int Length => snake.Count;
        public Destination Destination { get; set; } = Destination.Right;
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor BoaColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public void Move()
        {
            Show(true);
            for (int i = Length - 1; i > 0; i--)
            {
                snake[i] = snake[i - 1];
            }
            switch (Destination) 
            {
                case Destination.Right: { snake[1] = 3; X++; break; }
                case Destination.Bottom: { snake[1] = 4; Y++; break; }
                case Destination.Left: { snake[1] = 2; X--; break; }
                case Destination.Top: { snake[1] = 1; Y--; break; }
            }
            Show(false);
        }
        public void Growth()
        {
            snake.Add(snake[snake.Count - 1]);
        }
        public void Narrow()
        {
            snake.RemoveRange(4,snake.Count - 5);
        }

        public void Show(bool hide)
        {
            Console.ForegroundColor =(hide)?BackgroundColor:BoaColor;
            Show();
        }
        public void Show()
        {
            int x = X;
            int y = Y;
            Console.SetCursorPosition(x, y);
            Console.Write('$');//голова
            for (int i = 1; i < Length; i++)
            {
                switch (snake[i])
                {
                    case 1: { y++; break; }
                    case 2: { x++; break; }
                    case 3: { x--; break; }
                    case 4: { y--; break; }
                }
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }
        }
    }
}
