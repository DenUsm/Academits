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
        public void Add(T data)
        {
            ListItem<T> node = new ListItem<T>(data, Head);
            Head = node;
            Count++;
        }

        //Вставка элемента по индексу
        public void Insert(int index, T value)
        {
            if (Head == null)
            {
                throw new ArgumentNullException("The list must have at least one item", nameof(Head));
            }

            ListItem<T> node = Head;
            ListItem<T> previous = null;

            for (int i = 1; i < index; i++)
            {
                previous = node;
                node = node.GetNext();
            }

            if (index == 1)
            {
                Add(value);
            }
            else if (index == Count)
            {
                node.SetNext(new ListItem<T>(value, null));
                Count++;
            }
            else
            {
                previous.SetNext(new ListItem<T>(value, node));
                Count++;
            }
        }

        //удаление элемента по значению
        public bool RemoveByValue(T value)
        {
            if (Head == null)
            {
                throw new ArgumentNullException("The list must have at least one item", nameof(Head));
            }

            ListItem<T> node = Head;
            ListItem<T> previous = null;

            for (int i = 1; i <= Count; i++)
            {
                if (node.GetData().Equals(value))
                {
                    if (previous == null)
                    {
                        Head = node.GetNext();
                    }
                    else if (i == Count)
                    {
                        previous.SetNext(null);
                    }
                    else
                    {
                        previous.SetNext(node.GetNext());
                    }
                    Count--;
                    return true;
                }
                previous = node;
                node = node.GetNext();
            }
            return false;
        }

        //удаление элемента по индексу
        public T RemoveAt(int index)
        {
            ListItem<T> node = Head;
            ListItem<T> previous = null;

            for (int i = 1; i < index; i++)
            {
                previous = node;
                node = node.GetNext();
            }

            T value = Head.GetData();
            if (index == 1)
            {
                value = RemoveFirst();
            }
            else if (index == Count)
            {
                value = node.GetData();
                previous.SetNext(null);
                Count--;
            }
            else
            {
                value = node.GetData();
                previous.SetNext(node.GetNext());
                Count--;
            }
            return value;
        }

        //Удаление первого элемента
        public T RemoveFirst()
        {
            if (Head == null)
            {
                throw new ArgumentNullException("The list must have at least one item", nameof(Head));
            }

            T value = Head.GetData();
            Head = Head.GetNext();
            Count--;
            return value;
        }

        //Изменение значения по указанному индексу
        public T ChangeValueAt(int index, T value)
        {
            ListItem<T> node = GetNodeByIndex(index);
            T data = node.GetData();
            node.SetData(value);
            return data;
        }

        //Получение значения первого элемента
        public T GetValue()
        {
            if (Head == null)
            {
                throw new ArgumentNullException("The list must have at least one item", nameof(Head));
            }

            return Head.GetData();
        }

        //Получение занчения по указанному индексу
        public T GetValueAt(int index)
        {
            ListItem<T> node = GetNodeByIndex(index);
            return node.GetData();
        }

        //получение узла по индексу
        private ListItem<T> GetNodeByIndex(int index)
        {
            if ((index <= 0) || (index > Count))
            {
                throw new IndexOutOfRangeException("index must be > 0 and  <= Count");
            }

            ListItem<T> nodeCurrent = Head;

            for (int i = 1; i < index; i++)
            {
                nodeCurrent = nodeCurrent.GetNext();
            }
            return nodeCurrent;
        }

        //Разворот списка
        public void Reverse()
        {
            ListItem<T> node = Head;
            ListItem<T> next = null;
            ListItem<T> temp = null;

            for (int i = 0; i < Count; i++)
            {
                next = node.GetNext();
                node.SetNext(temp);
                temp = node;
                node = next;
            }
            Head = temp;
        }

        //Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();
            for (int i = Count; i >= 1; i--)
            {
                copy.Add(GetValueAt(i));
            }
            return copy;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            ListItem<T> nodeCurrent = Head;
            for (int i = 1; i <= Count; i++)
            {
                str.Append(nodeCurrent.ToString());
                nodeCurrent = nodeCurrent.GetNext();
            }
            return str.ToString();
        }
    }
}
