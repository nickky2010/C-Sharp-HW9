using System.Collections.Generic;

namespace HW9_2
{
    class SportComparer : IComparer<Sportsman>
    {
        public int Compare(Sportsman x, Sportsman y)
        {
            return (x.Sport.CompareTo(y.Sport));
        }
    }
}
