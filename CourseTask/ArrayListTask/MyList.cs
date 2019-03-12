using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class MyList<T> : IList<T>
    {
        private T[] Items = new T[10];
        private int Length;

        public MyList()
        {

        }

        public MyList(int capacity)
        {
            Items = new T[capacity];
        }

        private void IncreaseCapacity()
        {
            T[] old = Items;
            Items = new T[Length * 2];
            Array.Copy(old, 0, Items, 0, old.Length);
        }

        private void Check(int index)
        {
            if ((index > Items.Length) || (index < 0))
            {
                throw new ArgumentException("index must be less of items array length", nameof(index));
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
            if (Length >= Items.Length)
            {
                IncreaseCapacity();
            }
            Items[Length] = value;
            Length++;
        }

        public void RemoveAt(int index)
        {
            Check(index);
            if (index < Length)
            {
                Array.Copy(Items, index + 1, Items, index, Length - index);
            }
            Length--;
        }

        public int Count => Length;

        private void TrimToSize()
        {
            if(Items.Length / Length > 2)
            {
                T[] old = Items;
                Items = new T[Length * 2];
                Array.Copy(old, 0, Items, 0, Items.Length);
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();
   
        public void Clear()
        {
            Items = new T[10];
        }

        public bool Contains(T item)
        {
            foreach(T value in Items)
            {
                if(value.Equals(item))
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
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
