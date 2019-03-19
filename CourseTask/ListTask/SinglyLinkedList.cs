using System;
using System.Text;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public SinglyLinkedList()
        {

        }

        //Вставка элемента вначало
        public void AddFirst(T data)
        {
            ListItem<T> node = new ListItem<T>(data, Head);
            Head = node;
            Count++;
        }

        //Вставка элемента по индексу
        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                ListItem<T> previous = GetNodeByIndex(index - 1);
                previous.Next = new ListItem<T>(value, previous.Next);
                Count++;
            }
        }

        //удаление элемента по значению
        public bool RemoveByValue(T value)
        {
            ListItem<T> node = Head;

            if (Equals(node.Data, value))
            {
                Head = node.Next;
                Count--;
                return true;
            }

            node = node.Next;
            ListItem<T> previous = null;

            for (int i = 1; i < Count; i++)
            {
                if (Equals(node.Data, value))
                {
                    previous.Next = node.Next;
                    Count--;
                    return true;
                }
                previous = node;
                node = node.Next;
            }
            return false;
        }

        //удаление элемента по индексу
        public T RemoveAt(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException("index must be > 0 and  <= Count");
            }

            T value;
            if (index == 0)
            {
                value = RemoveFirst();
            }
            else
            {
                ListItem<T> previous = GetNodeByIndex(index - 1);
                value = previous.Next.Data;
                previous.Next = previous.Next.Next;
                Count--;
            }
            return value;
        }

        //Удаление первого элемента
        public T RemoveFirst()
        {
            if (Head == null)
            {
                throw new NullReferenceException("The list must have at least one item");
            }

            T value = Head.Data;
            Head = Head.Next;
            Count--;
            return value;
        }

        //Изменение значения по указанному индексу
        public T ChangeValueAt(int index, T value)
        {
            ListItem<T> node = GetNodeByIndex(index);
            T data = node.Data;
            node.Data = value;
            return data;
        }

        //Получение значения первого элемента
        public T GetFirstValue()
        {
            if (Head == null)
            {
                throw new NullReferenceException("The list must have at least one item");
            }

            return Head.Data;
        }

        //Получение занчения по указанному индексу
        public T GetValueAt(int index)
        {
            ListItem<T> node = GetNodeByIndex(index);
            return node.Data;
        }

        //получение узла по индексу
        private ListItem<T> GetNodeByIndex(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException("index must be > 0 and  <= Count");
            }

            ListItem<T> nodeCurrent = Head;

            for (int i = 1; i <= index; i++)
            {
                nodeCurrent = nodeCurrent.Next;
            }
            return nodeCurrent;
        }

        //Разворот списка
        public void Reverse()
        {
            ListItem<T> node = Head;
            ListItem<T> temp = null;

            for (int i = 0; i < Count; i++)
            {
                ListItem<T> next = node.Next;
                node.Next = temp;
                temp = node;
                node = next;
            }
            Head = temp;
        }

        //Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();

            if (Head == null)
            {
                return copy;
            }

            ListItem<T> node = Head.Next;
            ListItem<T> firstNode = new ListItem<T>(GetFirstValue(), null);
            ListItem<T> temp = firstNode;

            while (node != null)
            {
                temp.Next = new ListItem<T>(node.Data, null);
                temp = temp.Next;
                node = node.Next;
            }

            copy.Head = firstNode;
            copy.Count = Count;

            return copy;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            ListItem<T> nodeCurrent = Head;
            for (int i = 0; i < Count; i++)
            {
                str.Append(nodeCurrent);
                nodeCurrent = nodeCurrent.Next;
            }
            return str.ToString();
        }
    }
}
