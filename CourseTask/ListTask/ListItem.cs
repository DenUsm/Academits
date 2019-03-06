
namespace ListTask
{
    class ListItem<T>
    {
        private T Data { get; set; }
        private ListItem<T> Next { get; set; }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        public T GetValue()
        {
            return Data;
        }
    }
}
