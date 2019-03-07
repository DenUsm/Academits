using System;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        private int Count { get; set; }

        private const int nodePrevious = 1;
        private const int nodeCurrent = 0;

        public SinglyLinkedList()
        {

        }

        //Получение размера списка
        public int GetCount()
        {
            return Count;
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
            ListItem<T>[] nodes = GetNodesByIndex(index);

            if (index == 0)
            {
                Add(value);
            }
            else if (index == Count - 1)
            {
                nodes[nodeCurrent].SetNext(new ListItem<T>(value, null));
                Count++;
            }
            else
            {
                nodes[nodePrevious].SetNext(new ListItem<T>(value, nodes[nodeCurrent]));
                Count++;
            }
        }

        //удаление элемента по значению
        public bool RemoveAtValue(T value)
        {
            ListItem<T> node = Head;
            bool valueIs = false;

            int index = 0;
            for(int i = 0; i < Count - 1; i++)
            {
                if(node.GetData().Equals(value))
                {
                    valueIs = true;
                    index = i;
                    break;
                }
                node = node.GetNext();
            }

            if (valueIs)
            {
                T removeValue = RemoveAt(index);
            }

            return valueIs;
        }

        //удаление элемента по индексу
        public T RemoveAt(int index)
        {
            ListItem<T>[] nodes = GetNodesByIndex(index);

            T value = Head.GetData();
            if (index == 0)
            {
                value = Remove();
            }
            else if (index == Count - 1)
            {
                value = nodes[nodeCurrent].GetData();
                nodes[nodePrevious].SetNext(null);
                Count--;
            }
            else
            {
                value = nodes[nodeCurrent].GetData();
                nodes[nodePrevious].SetNext(nodes[nodeCurrent].GetNext());
                Count--;
            }
            return value;
        }

        //Удаление первого элемента
        public T Remove()
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head must be not null");
            }

            T value = Head.GetData();
            Head = Head.GetNext();
            Count--;
            return value;
        }

        //Изменение значения по указанному индексу
        public T ChangeValueAt(int index, T value)
        {
            ListItem<T>[] nodes = GetNodesByIndex(index);
            T data = nodes[nodeCurrent].GetData();
            nodes[nodeCurrent].SetData(value);
            return data;
        }

        //Получение значения первого элемента
        public T GetValue()
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head must be not null");
            }

            return Head.GetData();
        }

        //Получение занчения по указанному индексу
        public T GetValueAt(int index)
        {
            ListItem<T>[] nodes = GetNodesByIndex(index);
            return nodes[nodeCurrent].GetData();
        }

        //получение узла по индексу
        private ListItem<T>[] GetNodesByIndex(int index)
        {
            if ((index < 0) || (index > Count - 1))
            {
                throw new IndexOutOfRangeException("index must be >= 0 and  <= Count - 1");
            }

            ListItem<T> nodeCurrent = Head;
            ListItem<T> nodePrevious = null;
            for (int i = 0; i <= index - 1; i++)
            {
                nodePrevious = nodeCurrent;
                nodeCurrent = nodeCurrent.GetNext();
            }
            return new ListItem<T>[] { nodeCurrent, nodePrevious };
        }

        //Разворот списка
        public void Reverse()
        {
            if (Head == null)
            {
                throw new NullReferenceException("Head must be not null");
            }

            for (int i = 0; i < Count - 1; i++)
            {
                ListItem<T> node = Head;
                ListItem<T> temp = Head.GetNext();

                for (int j = 0; j < Count - i - 1; j++)
                {
                    T value = temp.GetData();
                    T value1 = node.GetData();

                    temp.SetData(value1);
                    node.SetData(value);

                    temp = temp.GetNext();
                    node = node.GetNext();
                }
            }
        }

        //Копирование списка
        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copy = new SinglyLinkedList<T>();
            for(int i = Count - 1; i >= 0; i--)
            {
                copy.Add(GetValueAt(i));
            }
            return copy;
        }

        public override string ToString()
        {
            string res = "";
            ListItem<T> nodeCurrent = Head;
            for (int i = 0; i <= Count - 1; i++)
            {
                res += nodeCurrent.ToString();
                nodeCurrent = nodeCurrent.GetNext();
            }
            return res;
        }
    }
}
