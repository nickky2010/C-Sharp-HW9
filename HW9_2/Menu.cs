using System;
using System.Collections.Generic;
using HW9_2.Delegate;
using HW9_2.Extend;
using HW9_2.Tables;

namespace HW9_2
{
    class Menu
    {
        //Вертикальное меню
        private string[] menu;
        private Table[] table;
        private ProcessingStruct<Sportsman> pStruct;
        private bool isRun = true;
        private int current;
        private int last;

        public Menu(ref string[] menu, ref ProcessingStruct<Sportsman> pStruct, ref Table[] table)
        {
            this.menu = new string[menu.Length + 1];
            for (int i = 0; i < menu.Length; i++)
            {
                this.menu[i] = menu[i];
            }
            this.menu[menu.Length] = "Выход";
            this.table = table;
            this.pStruct = pStruct;
            isRun = true;
            current = 0;
            last = 0;
        }
        public void Show()
        {
            while (isRun)
            {
                //вывод меню
                BaseColor();
                Console.Clear();
                Console.CursorVisible = false;
                for (int i = 0; i < menu.Length; i++)
                {
                    ShowMenuItem(i, menu[i]);
                }
                // выбор пункта меню
                bool isNoEnter = true;
                while (isNoEnter)
                {
                    BaseColor();
                    ShowMenuItem(last, menu[last]);
                    LightColor();
                    ShowMenuItem(current, menu[current]);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                        isNoEnter = false;
                    else
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        last = current;
                        current = (current == menu.Length - 1) ? 0 : current + 1;
                    }
                    else
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        last = current;
                        current = (current == 0) ? menu.Length - 1 : current - 1;
                    }
                }// конец тела цикла while (isNoEnter)

                // действие в соответствии с выбором пользователя
                switch (current)
                {
                    case 0:
                        {
                            Clear();
                            ((TableAllInfo)table[0]).Print("Вывод информации о всех спортсменах", ref pStruct);
                            Wait();
                            break;
                        }
                    case 1:
                        {
                            Clear();
                            Sportsman sportsman = new Sportsman();
                            Console.Write("Введите фамилию спортсмена: ");
                            sportsman.Surname = Console.ReadLine();
                            int yearOfBirth = 0;
                            if (!CheckAndInput.InputData(ref yearOfBirth, "Введите год рождения: "))
                                throw new Exception("Ошибка! Неправильный ввод года рождения спортсмена " + sportsman.Surname + "!");
                            sportsman.YearOfBirth = yearOfBirth;
                            Console.Write("Введите вид спорта: ");
                            sportsman.Sport = Console.ReadLine();
                            Console.Write("Введите разряд спортсмена: ");
                            sportsman.Category = Console.ReadLine();
                            pStruct.Add(sportsman);
                            Wait();
                            break;
                        }
                    case 2:
                        {
                            Clear();
                            pStruct.Sort(new AgeComparer());
                            ((TableAllInfo)table[0]).Print("Сортировка по возрастанию года рождения", ref pStruct);
                            Wait();
                            break;
                        }
                    case 3:
                        {
                            Clear();
                            pStruct.Sort(new SportComparer());
                            ((TableAllInfo)table[0]).Print("Сортировка по виду спорта", ref pStruct);
                            Wait();
                            break;
                        }
                    case 4:
                        {
                            Clear();
                            int age = 20;
                            string category = "I разряд";
                            IsYoungAndHaveCategory deleg = new IsYoungAndHaveCategory(pStruct.IsYoungAndHaveCategory);
                            ProcessingStruct<Sportsman> tempPS = new ProcessingStruct<Sportsman>();
                            for (int i = 0; i < pStruct.Lenght; i++)
                            {
                                if (deleg(pStruct[i], age, category))
                                    tempPS.Add(pStruct[i]);
                            }
                            ((TableAllInfo)table[0]).Print("Вывод списка спортсменов моложе "+age+ " лет, имеющих "+category, ref tempPS);
                            Wait();
                            break;
                        }
                    case 5:
                        {
                            Clear();
                            DictionarySports<string> dictionarySports = new DictionarySports<string>();
                            for (int i = 0; i < pStruct.Lenght; i++)
                            {
                                dictionarySports.Add(pStruct[i].Sport);
                            }
                            ((TableInfoSports)table[1]).Print(ref dictionarySports);
                            Wait();
                            break;
                        }
                    case 6:
                        {
                            isRun = false;
                            break;
                        }
                }
            }// конец цикла while (isRun)
        }
        private static void BaseColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void LightColor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        private static void ShowMenuItem(int itemIndex, string item)
        {
            Console.SetCursorPosition(25, 8 + itemIndex);
            Console.WriteLine(item);
        }
        private static void Clear()
        {
            BaseColor();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
        private static void Wait(string message = "Для продолжения нажмите любую клавишу")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
