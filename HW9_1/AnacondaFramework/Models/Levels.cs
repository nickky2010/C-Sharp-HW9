using System;

namespace HW9_1.AnacondaFramework.Models
{
    class Levels
    {
        public int Level { get; set; }  // уровень
        public int Score { get; set; }  // очки
        int countAte; // счетчик съеденых плюшек на уровне
        public int Speed { get; set; }  // скорость игры
        public int TimeShowBun { get; set; } // время показа плюшки
        public void ShowData()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Level: " + Level + "  " + "Score: " + Score);
        }
        public void ShowChangeLevel(string message, int GameAreaWidth, double kWidth, int GameAreaHeight, double kHeight)
        {
            Console.Clear();
            Console.SetCursorPosition((int)(GameAreaWidth * kWidth), (int)(GameAreaHeight * kHeight) - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message + Level);
            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.Clear();
        }
        public Levels()
        {
            Level = 1;
            Speed = 250;
            TimeShowBun = 15;
        }
        public void AdditionPoint ()
        {
            Score += Level;
            Speed--;
            countAte++;
        }
        public bool ChangeLevel()
        {
            if (countAte == Level)
            {
                Level++;
                countAte = 0;
                return true;
            }
            return false;
        }
    }
}
