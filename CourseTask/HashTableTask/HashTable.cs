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

        public void IncreaseCapacity()
        {
            Array.Resize(ref HashItems, HashItems.Length * 2);
        }

        public bool IsReadOnly => false;

        //добавление элемента в таблицу
        public void Add(T item)
        {
            int indexInsert = GetHashCode(item);

            while(HashItems[indexInsert] != null)
            {
                indexInsert++;
                if (indexInsert >= HashItems.Length)
                {
                    IncreaseCapacity();
                    HashItems[GetHashCode(item)] = new List<T>();
                    HashItems[GetHashCode(item)].Add(item);
                    break;
                }          
            }

            HashItems[indexInsert] = new List<T>();
            HashItems[indexInsert].Add(item);

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

        }

        private void CheckIndexAndInsert()
        {
            for(int i = 0; i < HashItems.Length; i++)
            {
                if (HashItems[i] != null)
                {
                    
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

        public bool Contains(T item)
        {
            int hash = GetHashCode(item);

            int i = hash;
            while (i <= HashItems.Length || HashItems[i] == null)
            {
                if (Equals(HashItems[i], item))
                {
                    return true;
                }
            }

            return false;
        }






        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();

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
                    str.Append(string.Format("Hash: {0} Index: {1} Value: {2} \r\n", GetHashCode(HashItems[i][0]), i, HashItems[i][0].ToString()));
                }
            }
            return str.ToString();
        }
    }
}
