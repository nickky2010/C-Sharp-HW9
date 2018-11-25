using System.Collections.Generic;
namespace HW9_2
{
    class AgeComparer : IComparer<Sportsman>
    {
        public int Compare(Sportsman x, Sportsman y)
        {
            return (x.YearOfBirth.CompareTo(y.YearOfBirth));
        }
    }
}