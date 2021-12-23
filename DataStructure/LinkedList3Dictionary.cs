namespace DataStructure
{
    /// <summary>
    /// 链表映射
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public struct LinkedList3Dictionary<Key, Value> : IDictionary<Key, Value>
    {
        private LinkedList3<Key, Value> list;
        public int Count => list.Count;
        public bool IsEmpty => Count == 0;
        public void Add(Key key, Value value)
        {
            list.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return list.Contains(key);
        }

        public Value Get(Key key)
        {
            return list.Get(key);
        }

        public void Set(Key key, Value newValue)
        {
            list.Set(key, newValue);
        }
    }
}