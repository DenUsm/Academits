namespace ListTask
{
    class ListItem<T>
    {
        private T Data;
        private ListItem<T> Next;

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        public T GetData()
        {
            return Data;
        }

        public void SetData(T data)
        {
            Data = data;
        }

        public ListItem<T> GetNext()
        {
            return Next;
        }

        public void SetNext(ListItem<T> next)
        {
            Next = next;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Data, (Next == null) ? "null" : Next.ToString());
        }
    }
}
