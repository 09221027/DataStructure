using System;

namespace DataStructure
{
    /// <summary>
    /// 红黑树映射
    /// SortedDictionary
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class RBT2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private RBT2<Key, Value> rbt;
        public int Count => rbt.Count;
        public bool IsEmpty => rbt.IsEmpty;
        public void Add(Key key, Value value)
        {
            rbt.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return rbt.Contains(key);
        }

        public Value Get(Key key)
        {
            return rbt.Get(key);
        }

        public void Set(Key key, Value newValue)
        {
            rbt.Set(key, newValue);
        }
    }
}