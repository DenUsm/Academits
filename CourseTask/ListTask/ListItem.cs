namespace ListTask
{
    class ListItem<T>
    {
        public T Data { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Data, (Next == null) ? "null" : Next.ToString());
        }
    }
}
