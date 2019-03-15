
namespace HashTableTask
{
    class HashListItem<T>
    {
        private int HashValue;
        public T Data { get; set; }
        public HashListItem<T> Next { get; set; }

        public HashListItem()
        {

        }

    }
}
