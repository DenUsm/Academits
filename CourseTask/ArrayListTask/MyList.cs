using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class MyList<T> : IList<T>
    {
        private T[] items;
        private int modCount = 0;

        public MyList()
        {
            items = new T[10];
            Count = 0;
        }

        public MyList(int capacity)
        {
            items = new T[capacity];
            Count = 0;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[items.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        private void CheckIndex(int index)
        {
            if ((index >= Count) || (index < 0))
            {
                throw new IndexOutOfRangeException("index must be less of Length");
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }
            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }

        public void Add(T value)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }
            items[Count] = value;
            Count++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }
            Count--;
            modCount++;
        }

        public int Count { get; private set; }

        public void TrimToSize()
        {
            if (items.Length / Count > 2)
            {
                T[] old = items;
                items = new T[Count * 2];
                Array.Copy(old, 0, items, 0, items.Length);
            }
        }

        public bool IsReadOnly => false;

        public void Clear()
        {
            Count = 0;
            Array.Clear(items, 0, items.Length);
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);
            Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;
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

            return true;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((array.Length - arrayIndex - 1) < Count)
            {
                throw new ArgumentException("Current array must be less destanation array", nameof(Count));
            }

            int j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array[j] = items[i];
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modCountSave = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (modCount != modCountSave)
                {
                    throw new InvalidOperationException("There were changes in the collection");
                }
                yield return items[i];
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
            str.Append(string.Join(", ", items));
            str.Append("]");

            return str.ToString();
        }

    }
}
