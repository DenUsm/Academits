using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<TKey, TValue> : ICollection<T>
    {
        HashItem<TKey, TValue> [] KeyValuePair;

        int modCount = 0;

        public int Count { get; private set; }

        public int Capacity
        {
            get => KeyValuePair.Length;
            set
            {
                if(Capacity < Count)
                {
                    throw new ArgumentOutOfRangeException("Сapacity is less than the current array");
                }

                if(Capacity == KeyValuePair.Length)
                {
                    return;
                }
                else
                {
                    Array.Resize(ref KeyValuePair, Capacity);
                }
            }
        }

        public HashTable()
        {
            KeyValuePair = new HashItem<TKey, TValue>[10];
            Count = 0;
        }

        public HashTable(int capasity)
        {
            KeyValuePair = new HashItem<TKey, TValue>[capasity];
            Count = 0;
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref KeyValuePair, KeyValuePair.Length * 2);
        }

        public bool IsReadOnly => false;

        public void Add(HashItem<TKey, TValue> item)
        {
            if (Count > KeyValuePair.Length)
            {
                IncreaseCapacity();
            }

            KeyValuePair[Count] = item;
            Count++;
            modCount++;
        }

        public bool Contains(HashItem<TKey, TValue> item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(KeyValuePair[i].Hash, item.Hash))
                {
                    return true;
                }
            }
            return false;
        }


        public void Clear()
        {
            throw new System.NotImplementedException();
        }

     
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

  
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
