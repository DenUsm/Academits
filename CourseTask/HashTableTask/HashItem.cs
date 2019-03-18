
namespace HashTableTask
{
    class HashItem<TKey, TValue>
    {
        public int Hash { get; private set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public HashItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Hash = GetHashCode();
        }

        //Получение hash'a из ключа
        private int GetHashCodeByKey()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Key:{0} - Value:{1}", Key, Value);
        }
    }
}
