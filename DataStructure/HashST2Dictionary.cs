namespace DataStructure
{
    /// <summary>
    /// 哈希表字典
    /// Dictionary
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class HashST2Dictionary<Key, Value> : IDictionary<Key, Value>
    {
        private HashST2<Key, Value> hashST2;

        public int Count => hashST2.Count;
        public bool IsEmpty => hashST2.IsEmpty;
        public void Add(Key key, Value value)
        {
            hashST2.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return hashST2.Contains(key);
        }

        public Value Get(Key key)
        {
            return hashST2.Get(key);
        }

        public void Set(Key key, Value newValue)
        {
            hashST2.Set(key, newValue);
        }
    }
}