using System;

namespace HW9_2
{
    struct Sportsman:IComparable<Sportsman>
    {
        //  фамилия 
        public string Surname { get; set; }
        //  год рождения 
        int yearOfBirth;
        public int YearOfBirth
        {
            get => yearOfBirth;
            set
            {
                try
                {
                    DateTime t;
                    t = DateTime.Parse("01."+"01."+value.ToString());
                    if(t.Year<=DateTime.Now.Year)
                        yearOfBirth = t.Year;
                    else
                        throw new Exception("Ошибка! Год рождения спортсмена " + Surname + " превышает текущую дату!");
                }
                catch
                {
                    throw new Exception("Ошибка! Неверно задан год рождения спортсмена " + Surname);
                }
            }
        }

        //  вида спорта
        public string Sport { get; set; }

        //  разряд
        public string Category { get; set; }

        public Sportsman(string surname, int yearOfBirth, string sport, string category)
        {
            Surname = surname;
            try
            {
                DateTime t;
                t = DateTime.Parse("01." + "01." + yearOfBirth.ToString());
                if (t.Year <= DateTime.Now.Year)
                    this.yearOfBirth = t.Year;
                else
                    throw new Exception("Ошибка! Год рождения спортсмена " + Surname + " превышает текущую дату!");
            }
            catch
            {
                throw new Exception("Ошибка! Неверно задан год рождения спортсмена " + Surname);
            }
            Sport = sport;
            Category = category;
        }
        //  метод-расширение для структуры Спортсмен, который определяет возраст.
        public int GetAge ()
        {
            return DateTime.Now.Year - yearOfBirth;
        }

        public int CompareTo(Sportsman other)
        {
            return (yearOfBirth.CompareTo(other.YearOfBirth));
        }
        public override string ToString()
        {
            return ("Фамилия:\t"+Surname +"\nГод рождения:\t"+ yearOfBirth+ "\nВид спорта:\t"+ Sport + "\nPазряд:\t\t" + Category);
        }

    }
}
