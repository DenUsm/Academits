
namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head { get; set; }
        private int Count { get; set; }

        public SinglyLinkedList()
        {
            
        }

        public int GetCount()
        {
            return Count;
        }

        public void Add(T data)
        {
            ListItem<T> p = new ListItem<T>(data, Head);
            Head = p;
            Count++;
        }

        public T GetValue()
        {
            return Head.GetValue();
        }

    }
}
