using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] HashItems;

        public int Count { get; private set; }

        private int modCount = 0;

        public HashTable()
        {
            HashItems = new List<T>[10];
            Count = 0;
        }

        public HashTable(int capasity)
        {
            HashItems = new List<T>[capasity];
            Count = 0;
        }

        public bool IsReadOnly => false;

        //добавление элемента в таблицу
        public void Add(T item)
        {
            int indexInsert = GetHashCode(item);

            if (HashItems[indexInsert] != null)
            {
                HashItems[indexInsert].Add(item);
                Count++;
                return;
            }

            HashItems[indexInsert] = new List<T>();
            HashItems[indexInsert].Add(item);
            Count++;
            modCount++;
        }

        //получение индекса в масиве на основе хэша
        public int GetHashCode(T item)
        {
            return Math.Abs((item == null) ? 0 : item.GetHashCode() % HashItems.Length);
        }

        //перестройка таблицы после изменения длинны массива списков
        private void RebuildTable()
        {
            for (int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    T value = HashItems[i][0];
                    HashItems[i] = null;
                    Count--;
                    Add(value);
                }
            }
        }

        //Обнуление списка
        public void Clear()
        {
            Array.Clear(HashItems, 0, HashItems.Length);
            Count = 0;
            modCount++;
        }

        //наличие элемента
        public bool Contains(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            int hash = GetHashCode(item);

            for (int i = 0; i < HashItems[hash].Count; i++)
            {
                if (Equals(HashItems[hash][i], item))
                {
                    return true;
                }
            }

            return false;
        }

        //удаление элементы
        public bool Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }

            int hash = GetHashCode(item);

            for (int i = 0; i < HashItems[hash].Count; i++)
            {
                if (Equals(HashItems[hash][i], item))
                {
                    HashItems[hash].RemoveAt(i);
                    Count--;
                    modCount++;
                    return true;
                }
            }

            return false;
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
            for (int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    HashItems[i].ForEach(value => { array[j] = value; j++; });
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int originModCount = modCount;

            for (int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    if (originModCount != modCount)
                    {
                        throw new InvalidOperationException("There were changes in the collection");
                    }

                    for (int j = 0; j < HashItems[i].Count; j++)
                    {
                        yield return HashItems[i][j];
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
            for (int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    str.Append(string.Format("Hash: {0} [", i));
                    int count = HashItems[i].Count;

                    if (count == 1)
                    {
                        str.Append((HashItems[i][0] == null) ? "null" : HashItems[i][0] + "] \r\n");
                        continue;
                    }

                    for (int j = 0; j < count - 1; j++)
                    {
                        str.Append(string.Format("{0}, ", (HashItems[i][j] == null) ? "null" : HashItems[i][j].ToString()));
                    }
                    str.Append((HashItems[i][count - 1] == null) ? "null" : HashItems[i][count - 1].ToString());
                    str.Append("] \r\n");
                }
            }
            str.Append("Количество элементов в хэш таблицы - ");
            str.Append(Count + "\r\n");

            return str.ToString();
        }
    }
}
