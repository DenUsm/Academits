using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] hashItems;

        public int Count { get; private set; }

        private int modCount = 0;

        public HashTable()
        {
            hashItems = new List<T>[10];
            Count = 0;
        }

        public HashTable(int size)
        {
            hashItems = new List<T>[size];
            Count = 0;
        }

        public bool IsReadOnly => false;

        //добавление элемента в таблицу
        public void Add(T item)
        {
            int indexInsert = GetHashCode(item);

            if (hashItems[indexInsert] != null)
            {
                hashItems[indexInsert].Add(item);
                Count++;
                modCount++;
                return;
            }

            hashItems[indexInsert] = new List<T>();
            hashItems[indexInsert].Add(item);
            Count++;
            modCount++;
        }

        //получение индекса в масиве на основе хэша
        private int GetHashCode(T item)
        {
            return Math.Abs((item == null) ? 0 : item.GetHashCode() % hashItems.Length);
        }

        //Обнуление списка
        public void Clear()
        {
            Array.Clear(hashItems, 0, hashItems.Length);
            Count = 0;
            modCount++;
        }

        //наличие элемента
        public bool Contains(T item)
        {
            int hash = GetHashCode(item);

            if (hashItems[hash] == null)
            {
                return false;
            }

            return hashItems[hash].Contains(item);
        }

        //удаление элементы
        public bool Remove(T item)
        {
            int hash = GetHashCode(item);

            if (hashItems[hash] == null)
            {
                return false;
            }

            return hashItems[hash].Remove(item);
        }

        //копирование в массив 
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array must not be empty", nameof(array));
            }

            if ((arrayIndex < 0) || (arrayIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException("ArrayIndex must be less amount of element array", nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Current array must be less destanation array", nameof(Count));
            }

            int j = arrayIndex;

            foreach (var value in this)
            {
                array[j] = value;
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int originModCount = modCount;

            for (int i = 0; i < hashItems.Length; i++)
            {
                if (hashItems[i] != null)
                {
                    if (originModCount != modCount)
                    {
                        throw new InvalidOperationException("There were changes in the collection");
                    }

                    for (int j = 0; j < hashItems[i].Count; j++)
                    {
                        yield return hashItems[i][j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < hashItems.Length; i++)
            {
                if (hashItems[i] != null)
                {
                    str.AppendFormat("Hash: {0} [", i);
                    int count = hashItems[i].Count;

                    if (count == 1)
                    {
                        str.Append((hashItems[i][0] == null) ? "null" : hashItems[i][0].ToString());
                        str.Append("]");
                        str.AppendLine();
                        continue;
                    }

                    for (int j = 0; j < count - 1; j++)
                    {
                        str.AppendFormat("{0}, ", (hashItems[i][j] == null) ? "null" : hashItems[i][j].ToString());
                    }
                    str.Append((hashItems[i][count - 1] == null) ? "null" : hashItems[i][count - 1].ToString());
                    str.Append("]");
                    str.AppendLine();
                }
            }
            str.Append("Количество элементов в хэш таблицы - ");
            str.Append(Count);
            str.AppendLine();

            return str.ToString();
        }
    }
}
