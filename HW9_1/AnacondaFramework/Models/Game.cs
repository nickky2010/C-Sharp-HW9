using System;
using System.Threading;
using AnacondaFramework.Enums;
using AnacondaFramework.Interfaces;
using AnacondaFramework.Models.ForConsole;
using HW9_1.AnacondaFramework.Interfaces;
using HW9_1.AnacondaFramework.Models;
using HW9_1.AnacondaFramework.Models.ForConsole;

namespace AnacondaFramework.Models
{
    public class Game
    {
        public IBoa Anaconda { get; set; } = new Boa { X = 4, Y = 4 };
        public IArea GameArea { get; set; }
        public IBun Bun { get; set; } = new Bun();
        public string GameResult { get; private set; }
        bool isGameOver = false;
        bool isWin = false;
        bool isGamePause = false;
        Levels levels = new Levels();
        public event EventHandler KeyPressed;
        public Game()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((int)(Console.WindowWidth * 0.48), Console.WindowHeight / 2 - 1);
            Console.WriteLine("BOA");
            Console.SetCursorPosition((int)(Console.WindowWidth * 0.35), Console.WindowHeight / 2+1);
            Console.Write("@@@       @@@$       &");
            Console.SetCursorPosition((int)(Console.WindowWidth * 0.35), Console.WindowHeight / 2 + 2);
            Console.Write("  @@@@@@@@@");
            KeyPressed += OnKeyPressed;
        }
        public void Start ()
        {
            GameArea.Show();
            Anaconda.Show();
            Bun.ChangePosition(GameArea.Width, GameArea.Height);
            Bun.Show();

            DateTime timeСounting = DateTime.Now;
            TimeSpan timer = new TimeSpan(0,0, levels.TimeShowBun);
            DateTime timeChangePosition = timeСounting.Add(timer);
            while (!isGameOver)
            {
                if(Console.KeyAvailable)
                {
                    KeyPressed?.Invoke(this, EventArgs.Empty); // можем передавать код нажатой клавиши
                }
                if (Anaconda.X < GameArea.Width - 1 && Anaconda.Y < GameArea.Height - 1 && Anaconda.X > 0 && Anaconda.Y > 0 )
                {
                    if(!isGamePause)
                    {
                        if (GameArea.GetBoxes() != null)
                        {
                            foreach (IBox item in GameArea.GetBoxes())
                            {
                                if (Anaconda.X == item.X && Anaconda.Y == item.Y)
                                {
                                    isGameOver = true;
                                    break;
                                }
                            }
                        }
                        if (!isGameOver)
                        {
                            levels.ShowData();
                            Anaconda.Move();
                            Bun.Show();
                            GameArea.ShowBox();
                            if (Anaconda.X == Bun.X && Anaconda.Y == Bun.Y)         // если змейка "кушает плюшку"
                            {
                                Bun.ChangePosition(GameArea.Width, GameArea.Height);// плюшка меняет позицию
                                Anaconda.Growth();                                  // змея растет
                                levels.AdditionPoint();                             // прибавляем количество съеденых плюшек +1
                                levels.ShowData();                                  // меняем данные сверху об уровне и очках
                                timeСounting = DateTime.Now;                        // запоминаем текущее время
                                timeChangePosition = timeСounting.Add(timer);       // запоминаем время когда нужно сменить положение плюшки
                                if (levels.ChangeLevel())                           // проверяем достигнут ли новый уровень и если достигнут то переводим на новый
                                {
                                    isGamePause = true;                             // ставим на паузу
                                    if (levels.Level == 15)                    
                                    {
                                        isGameOver = true;
                                        isWin = true;
                                    }
                                    else
                                    {
                                        if (levels.Level >= 1)
                                        {
                                            GameArea.CreatBox(levels.Level);
                                        }
                                        levels.ShowChangeLevel("LEVEL ", GameArea.Width, 0.4, GameArea.Height, 0.5);
                                        Anaconda.Narrow();
                                        isGamePause = false;
                                    }
                                }
                            }
                            else if (DateTime.Now >= timeChangePosition)        // проверяем наступило ли время смены плюшки, если да - меняем местоположение плюшки у ставим новое время смены
                            {
                                Bun.ChangePosition(GameArea.Width, GameArea.Height);
                                timeСounting = DateTime.Now;
                                timeChangePosition = timeСounting.Add(timer);
                            }
                        }
                    }
                }
                else
                    isGameOver = true;
                Thread.Sleep(levels.Speed);
            }
            Console.Clear();
            Console.SetCursorPosition((int)(GameArea.Width * 0.35), GameArea.Height / 2 - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            if(isWin)
                GameResult = "YOU WIN!\nScore: " + levels.Score;
            else
                GameResult = "Game over!\nScore: " + levels.Score;
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
                        isGamePause = isGamePause ? false : true;
                        break;
                    }
            }
        }
    }
}
