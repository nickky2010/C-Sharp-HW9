using System;
using System.Collections.Generic;

namespace HW9_2
{
    //  Создать класс-прототип для хранения и обработки экземпляров структур, наложить ограничение на параметр типа данных: 
    //  элементы коллекции должны быть значимого типа, тип-аргумент должен реализовывать интерфейс IComparable.
    //  В классе предусмотреть метод для сортировки коллекции, метод для формирования списка объектов, удовлетворяющих 
    //  заданному условию (условие поиска передавать в метод через делегат), остальные элементы на свое усмотрение.

    class ProcessingStruct<T> where T:struct,IComparable<T>
    {
        List<T> array;
        int heapSize;
        IComparer<T> comparer; // объект для сравнения элементов
        public ProcessingStruct(T[] arr, IComparer<T> comparer = null)
        {
            array = new List<T>();
            array.AddRange(arr);
            heapSize = arr.Length;
            this.comparer = comparer;
        }
        public ProcessingStruct()
        {
            array = new List<T>();
        }
        public int Lenght => array.Count;           //количество элементов
        public T this [int i] => array[i];          //индексатор доступа
        public void Add(T elem)                     //добавление элемента
        {
            array.Add(elem);
            heapSize = Lenght;
        }

        private int Left(int i) => (2 * i + 1);     //индекс левого потомка
        private int Right(int i) => (2 * i + 2);    //индекс правого потомка
        private int Parent(int i) => (i - 1) / 2;   //индекс родительского узла
        private bool IsLesser(T t1, T t2)
        {
            if (comparer == null)
                return t1.CompareTo(t2) < 0;
            return (comparer.Compare(t1, t2) < 0);
        }
        private void OrderHeapIfNeed(int i) // ш больше хотя бы 1 из
        {
            int l = Left(i);
            int r = Right(i);
            int lesser = i;
            if (l < heapSize && IsLesser(array[l], array[i]))
                lesser = l;
            if (r < heapSize && IsLesser(array[r], array[lesser]))
                lesser = r;
            if (lesser != i)
            {
                T temp = array[i];
                array[i] = array[lesser];
                array[lesser] = temp;
                OrderHeapIfNeed(lesser);
            }
        }
        // метод строит возрастающую пирамиду
        private void BuildHeap()
        {
            int i = (array.Count - 1) / 2;
            while (i >= 0)
            {
                OrderHeapIfNeed(i);
                i--;
            }
        }
        public List<T> HeapSort(IComparer<T> comparer = null)
        {
            this.comparer = comparer;
            BuildHeap(); //построение пирамиды
            for (int i = array.Count - 1; i > 0; i--)
            {
                T temp = array[0]; //текущий минимальный  из 0 поз в хвост
                array[0] = array[i];
                array[i] = temp;
                heapSize--; //уменьшим число необработанных элементов
                OrderHeapIfNeed(0); //восстановление свойства пирамиды
            }
            return array;
        }
        public List<T>Sort(IComparer<T> comparer = null)
        {
            array.Sort(comparer);
            return array;
        }
        // Формирование и вывод списка спортсменов моложе 20 лет, имеющих I разряд
        public bool IsYoungAndHaveCategory(Sportsman s, int age, string category)
        {
            return (s.GetAge()<age && s.Category==category);
        }
    }
}
