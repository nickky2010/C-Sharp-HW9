//                                                          Задание 1.
//                                      Разработать консольную игру «Удавчик». 
//    Змея перемещается по экрану в заданном направлении, которое можно изменить, нажимая клавиши со стрелками.
//    При столкновении змеи с препятствием или с границей игровой области игра заканчивается.
//    При нажатии на пробел игра останавливается, движение змеи возобновляется при повторном нажатии пробела.
//    При нажатии на клавишу Escape происходит выход из игры.
//    На игровом поле случайным образом появляются «плюшки» для удава, которые через некоторое время исчезают.
//    Если удав «съедает» такую «плюшку», его длина увеличивается, а также возрастает скорость его движения. 
//    За каждый съеденный приз начисляются очки. По окончании игры выводится результат.

using AnacondaFramework.Interfaces;
using AnacondaFramework.Models;
using AnacondaFramework.Models.ForConsole;
using System;

namespace AnacondaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IArea gameArea = new GameArea
            {
                X = 0,
                Y = 0,
                Width = 40,
                Height = 24,
                Color = ConsoleColor.DarkBlue
            };
            gameArea.Show();
            IBoa anaconda = new Boa
            {
                X = 4,
                Y = 4,
                BackgroundColor = ((GameArea)gameArea).Color,
                BoaColor = ConsoleColor.Yellow
            };
            Game game = new Game { Anaconda = anaconda, GameArea = gameArea };
            Console.ReadKey();
            game.Start();
            Console.WriteLine(game.GameResult);
            Console.ReadKey();
        }
    }
}
