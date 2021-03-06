﻿//                                                  Задание 2.	
//  Описать структуру для представления информации о спортсменах, содержащую следующие элементы:  
//  поля для хранения фамилии, года рождения, вида спорта и разряда.
//  Написать метод-расширение для структуры Спортсмен, который определяет возраст.
//  Создать класс-прототип для хранения и обработки экземпляров структур, наложить ограничение на параметр типа данных: 
//  элементы коллекции должны быть значимого типа, тип-аргумент должен реализовывать интерфейс IComparable.
//  В классе предусмотреть метод для сортировки коллекции, метод для формирования списка объектов, удовлетворяющих 
//  заданному условию (условие поиска передавать в метод через делегат), остальные элементы на свое усмотрение.
//                                 Написать приложение, выполняющее следующие функции:
//  •	Создание объекта с информацией о спортсменах.
//  •	Вывод информации в виде таблицы.
//  •	Добавление данных о спортсмене.
//  •	Сортировку по возрастанию года рождения или по виду спорта (по выбору пользователя).
//  •	Формирование и вывод списка спортсменов моложе 20 лет, имеющих I разряд(использовать стандартную коллекцию List<>).
//  •	Формирование и вывод коллекции Dictionary<>, содержащей информацию с количеством спортсменов по каждому виду спорта
//  (ключ – вид спорта, значение – количество спортсменов).

using HW9_2.Tables;
using System;

namespace HW9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Sportsman[] sportsmans = {
                    new Sportsman("Попов", 1999, "Футбол", "Кандидат в мастера спорта"),
                    new Sportsman("Дибров", 1983, "Футбол", "Мастер спорта"),
                    new Sportsman("Сидоров", 1989, "Баскетбол", "I разряд"),
                    new Sportsman("Иванов", 2000, "Бокс", "Мастер спорта"),
                    new Sportsman("Петров", 1979, "Гребля", "II разряд"),
                    new Sportsman("Панин", 2002, "Греко-римская борьба", "I разряд"),
                    new Sportsman("Хачатурян", 2005, "Греко-римская борьба", "III разряд"),
                    new Sportsman("Абрамов", 2003, "Греко-римская борьба", "I разряд"),
                    new Sportsman("Туполев", 1996, "Вольная борьба", "III разряд"),
                    new Sportsman("Рубликов", 1993, "Метание молота", "Кандидат в мастера спорта"),
                    new Sportsman("Голубев", 1990, "Фехтование", "II разряд"),
                    new Sportsman("Васечкин", 2001, "Волейбол", "I разряд"),
                    new Sportsman("Тугриков", 1997, "Пятиборье", "Кандидат в мастера спорта")
                };
                ProcessingStruct<Sportsman> pSTable = new ProcessingStruct<Sportsman>(sportsmans);
                
                Table[] table ={
                    new TableAllInfo("", new Table.Column("№", 3), new Table.Column("Фамилия", 15),
                        new Table.Column("Год рождения"), new Table.Column("Вид спорта", 25), new Table.Column("Разряд",25)),
                    new TableInfoSports("", new Table.Column("№", 3), new Table.Column("Вид спорта", 25), 
                        new Table.Column("Количество спортсменов"))
                };
                string[] menuItems = { "Вывод информации", "Добавление данных о спортсмене",
                    "Сортировка по возрастанию года рождения", "Сортировка по виду спорта",
                    "Вывод списка спортсменов моложе 20 лет, имеющих I разряд",
                    "Вывод информации о количестве спортсменов по каждому виду спорта" };
                Menu menu = new Menu(ref menuItems, ref pSTable, ref table);
                menu.Show();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка! Задан неправильный формат даты!\n" + ex.Message);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Ошибка! Задан неправильный формат таблицы!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
