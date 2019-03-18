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
        public int Count { get; private set; }
        public int Capacity
        {
            get => items.Length;
            set
            {
                if (Capacity < Count)
                {
                    throw new ArgumentOutOfRangeException("Сapacity is less than the current array");
                }

                if (Capacity == items.Length)
                {
                    return;
                }
                else
                {
                    Array.Resize(ref items, value);
                }
            }
        }

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
            Array.Resize(ref items, items.Length * 2);
        }

        private void CheckIndex(int index)
        {
            if ((index >= Count) || (index < 0))
            {
                throw new IndexOutOfRangeException("Index must be less amount of elements");
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
                modCount++;
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

        public void TrimExcess()
        {
            if (Count == 0)
            {
                return;
            }

            if (items.Length / Count > 2)
            {
                Array.Resize(ref items, Count);
            }
        }

        public bool IsReadOnly => false;

        public void Clear()
        {
            Array.Clear(items, 0, items.Length);
            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(item, items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((index > Count) || (index < 0))
            {
                throw new IndexOutOfRangeException("Index must be less amount of elements");
            }

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

            RemoveAt(index);
            return true;
        }

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
