using System;

namespace DataStructure
{
    public class SortedArray2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private SortedArray2<Key, Value> s2;
        public int Count => s2.Count;
        public bool IsEmpty => s2.IsEmpty;
        public void Add(Key key, Value value)
        {
            s2.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return s2.Contains(key);
        }

        public Value Get(Key key)
        {
            return s2.Get(key);
        }

        public void Set(Key key, Value newValue)
        {
            s2.Add(key, newValue);
        }
    }
}