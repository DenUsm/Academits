using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        List<T> [] HashItems;

        public int Count { get; private set; }

        private int modCount = 0;

        public int Capasity
        {
            get => HashItems.Length;
            set
            {
                if(Capasity < Count)
                {
                    throw new ArgumentOutOfRangeException("Capasity is less than the current array");
                }

                if(Capasity != HashItems.Length)
                {
                    Array.Resize(ref HashItems, value);
                }
            }
        }

        public HashTable()
        {
            HashItems = new List<T>[10];
            Count = 0;
        }

        public HashTable(int capasity)
        {
            HashItems = new List<T>[capasity];
            Capasity = capasity;
            Count = 0;
        }

        public bool IsReadOnly => false;

        //увелечение длинны списка
        public void IncreaseCapacity()
        {
            Array.Resize(ref HashItems, HashItems.Length * 2);
        }

        //добавление элемента в таблицу
        public void Add(T item)
        {
            int indexInsert = GetHashCode(item);


            if(HashItems[indexInsert] == null)
            {
                HashItems[indexInsert] = new List<T>();
                HashItems[indexInsert].Add(item);
            }
            else
            {
                indexInsert++;
                while(indexInsert < HashItems.Length)
                {
                    if(HashItems[indexInsert] == null)
                    {
                        HashItems[indexInsert] = new List<T>();
                        HashItems[indexInsert].Add(item);
                        break;
                    }
                    indexInsert++;
                }

                if (indexInsert == HashItems.Length)
                {
                    IncreaseCapacity();
                    HashItems[indexInsert] = new List<T>();
                    HashItems[indexInsert].Add(item);
                    RebuildTable();
                }
            }
            Count++;
            modCount++;
        }

        //получение индекса в масиве на основе хэша
        public int GetHashCode(T item)
        {
            return Math.Abs(item.GetHashCode() % HashItems.Length);
        }

        //перестройка таблицы после изменения длинны массива списков
        private void RebuildTable()
        {
            for(int i = 0; i < HashItems.Length; i++)
            {
                if(HashItems[i] != null)
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

            int i = hash;
            while (i <= HashItems.Length && HashItems[i] != null)
            {
                if (Equals(HashItems[i][0], item))
                {
                    return true;
                }
                i++;
            }

            return false;
        }

        //удаление элементы
        public bool Remove(T item)
        {
            if(Count == 0)
            {
                return false;
            }

            int hash = GetHashCode(item);

            int i = hash;
            while (i <= HashItems.Length && HashItems[i] != null)
            {
                if (Equals(HashItems[i][0], item))
                {
                    HashItems[i] = null;
                    Count--;
                    modCount++;
                    return true;
                }
                i++;
            }

            return false;
        }

        //копирование в массив 
        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException("Array must not be empty", nameof(array));
            }

            if((arrayIndex < 0) || (arrayIndex >= array.Length))
            {
                throw new ArgumentOutOfRangeException("ArrayIndex must be less amount of element array", nameof(arrayIndex));
            }

            if(array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Current array must be less destanation array", nameof(Count));
            }

            int j = arrayIndex;
            for(int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    array[j] = HashItems[i][0];
                    j++;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int originModCount = modCount;

            for(int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    if (originModCount != modCount)
                    {
                        throw new InvalidOperationException("There were changes in the collection");
                    }

                    yield return HashItems[i][0];
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
            int count = 1;
            for (int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    str.Append(string.Format("{0} Hash: {1} Index: {2} Value: {3} \r\n", count, GetHashCode(HashItems[i][0]), i, HashItems[i][0].ToString()));
                    count++;
                }
            }
            return str.ToString();
        }
    }
}
