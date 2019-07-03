# C# - Home work 9
***
#### Task 1. 


Разработать консольную игру `«Удавчик»`. Змея перемещается по экрану в заданном направлении, которое можно изменить, нажимая клавиши со стрелками. 

`При столкновении` змеи с препятствием или с границей игровой области игра заканчивается. 

`При нажатии на пробел` игра останавливается, движение змеи возобновляется при повторном нажатии пробела. 

`При нажатии на клавишу Escape` происходит выход из игры. 

На игровом поле случайным образом появляются `«плюшки»` для удава, которые  через некоторое время исчезают. Если удав `«съедает»` такую `«плюшку»`, его длина увеличивается, а также возрастает скорость его движения. За каждый съеденный приз начисляются очки. 

По окончании игры выводится результат.

![Alt text](/Task/Image/1.PNG?raw=true "Удавчик")

***
#### Task 2. 

Описать структуру для представления информации о спортсменах, содержащую следующие элементы:  
* поля для хранения фамилии;
* года рождения, вида спорта и разряда. 

Написать метод-расширение для структуры `Спортсмен`, который определяет возраст.


Создать класс-прототип для хранения и обработки экземпляров структур, наложить ограничение на параметр типа данных: 
* элементы коллекции должны быть значимого типа;
* тип-аргумент должен реализовывать интерфейс `IComparable`. 

В классе предусмотреть метод для сортировки коллекции, метод для формирования списка объектов, удовлетворяющих заданному условию (условие поиска передавать в метод через делегат), остальные элементы на свое усмотрение.


Написать приложение, выполняющее следующие функции:
* Создание объекта с информацией о спортсменах.
* Вывод информации в виде таблицы.
* Добавление данных о спортсмене.
* Сортировку по возрастанию года рождения или по виду спорта (по выбору пользователя).
* Формирование и вывод списка спортсменов моложе 20 лет, имеющих `I разряд` (использовать стандартную коллекцию `List<>`).
* Формирование и вывод коллекции `Dictionary<>`, содержащей информацию с количеством спортсменов по каждому виду спорта (ключ – вид спорта, значение – количество спортсменов).

***
## Решение задания консольной игры `«Удавчик»`: 

#### Вид консольной игры `«Удавчик»`:

![Alt text](Task/Image/2.PNG?raw=true "Уровни")

![Alt text](Task/Image/3.PNG?raw=true "Game over")

![Alt text](Task/Image/4.PNG?raw=true "Игровой процесс")

