using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class MyList<T> : IList<T>
    {
        private T[] Items = new T[10];
        private int modCount = 0;

        public MyList()
        {
            Count = 0;
        }

        public MyList(int capacity)
        {
            Items = new T[capacity];
            Count = 0;
        }

        private void IncreaseCapacity()
        {
            T[] old = Items;
            Items = new T[Items.Length * 2];
            Array.Copy(old, 0, Items, 0, old.Length);
        }

        private void Check(int index)
        {
            if ((index >= Count) || (index < 0))
            {
                throw new ArgumentException("index must be less of Length", nameof(index));
            }
        }

        public T this[int index]
        {
            get
            {
                Check(index);
                return Items[index];
            }
            set
            {
                Check(index);
                Items[index] = value;
            }
        }

        public void Add(T value)
        {
            if (Count >= Items.Length)
            {
                IncreaseCapacity();
            }
            Items[Count] = value;
            Count++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            Check(index);
            if (index < Count - 1)
            {
                Array.Copy(Items, index + 1, Items, index, Count - index - 1);
            }
            Count--;
            modCount++;
            TrimToSize();
        }

        public int Count { get; private set; }

        private void TrimToSize()
        {
            if (Items.Length / Count > 2)
            {
                T[] old = Items;
                Items = new T[Count * 2];
                Array.Copy(old, 0, Items, 0, Items.Length);
            }
        }

        public bool IsReadOnly => false;

        public void Clear()
        {
            Count = 0;
            TrimToSize();
        }

        public bool Contains(T item)
        {
            foreach (T value in Items)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            int indexEntry = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Items[i].Equals(item))
                {
                    indexEntry = i;
                    break;
                }
            }
            return indexEntry;
        }

        public void Insert(int index, T item)
        {
            Check(index);
            Array.Copy(Items, index, Items, index + 1, Count - index);
            Items[index] = item;
            Count++;
            modCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(IndexOf(item));
            TrimToSize();

            return true;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if((array.Length - arrayIndex - 1) < Count)
            {
                throw new ArgumentException("Current array must be less destanation array", nameof(Count));
            }

            int j = arrayIndex;
            for(int i = 0; i < Count; i++)
            {
                array[j] = Items[i];
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCountSave = modCount;

            for(int i = 0; i < Count; i++)
            {
                if (modCount != modCountSave)
                {
                    throw new InvalidOperationException("There were changes in the collection");
                }
                yield return Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            str.Append(string.Join(", ", Items));
            str.Append("]");

            return str.ToString();
        }

    }
}
