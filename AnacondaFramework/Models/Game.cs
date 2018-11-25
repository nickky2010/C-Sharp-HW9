using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnacondaFramework.Enums;
using AnacondaFramework.Interfaces;
using AnacondaFramework.Models.ForConsole;

namespace AnacondaFramework.Models
{
    public class Game
    {
        public IBoa Anaconda { get; set; } = new Boa { X = 4, Y = 4 };
        public IArea GameArea { get; set; }
        public string GameResult { get; private set; }
        public int Speed { get; set; }
        bool isGameOver = false;
        bool isGamePause = false;
        public event EventHandler KeyPressed;
        public Game()
        {
            KeyPressed += OnKeyPressed;
            Speed = 100;
        }
        public void Start ()
        {
            GameArea.Show();
            Anaconda.Show();
            while(!isGameOver)
            {
                if(Console.KeyAvailable)
                {
                    KeyPressed?.Invoke(this, EventArgs.Empty); // можем передавать код нажатой клавиши
                }
                if (Anaconda.X < GameArea.Width - 1 && Anaconda.Y < GameArea.Height - 1 && Anaconda.X > 0 && Anaconda.Y > 0)
                {
                    if(!isGamePause)
                    {
                        Anaconda.Move();

                    }
                }
                else
                {
                    isGameOver = true;
                    GameResult = "Игра окончена!";
                }
                Thread.Sleep(Speed);
            }
        }
        private void OnKeyPressed(object sender, EventArgs e)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.Escape:
                    {
                        isGameOver = true;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        Anaconda.Destination = Destination.Left;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        Anaconda.Destination = Destination.Top;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        Anaconda.Destination = Destination.Right;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        Anaconda.Destination = Destination.Bottom;
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        isGamePause = isGamePause ? false : true; ;
                        break;
                    }
            }
        }
    }
}
