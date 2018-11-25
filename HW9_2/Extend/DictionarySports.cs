using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9_2.Extend
{
    class DictionarySports<T>
    {
        Dictionary<T, int> segmentsTable;
        public DictionarySports()
        {
            segmentsTable = new Dictionary<T, int>();
        }

        public void Add(T keySegment) //добавляем сегмент в коллекцию
        {
            if (!segmentsTable.ContainsKey(keySegment))
            {
                segmentsTable.Add(keySegment, 1);
            }
            else
            {
                segmentsTable[keySegment] = segmentsTable[keySegment] + 1;
            }
        }
        public int Lenght => segmentsTable.Count;
        public int this[T key] => segmentsTable[key]; //индексатод для доступа по ключу
        public T GetKey (int i)
        {
            return segmentsTable.ElementAt(i).Key;
        }
        public string GetStringValue(T key)
        {
            return key.ToString();
        }
        public List<string> GetListLengthCount() //(len;num)
        {
            List<string> listLengthCount = new List<string>();
            int i;
            foreach (T key in segmentsTable.Keys)
            {
                i = ~listLengthCount.BinarySearch(key.ToString());
                listLengthCount.Insert(i, GetStringValue(key));
            }
            return listLengthCount;
        }
    }
}
