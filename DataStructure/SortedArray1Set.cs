using System;

namespace DataStructure
{
    /// <summary>
    /// 有序数组集合
    /// 二分查找
    /// contains为O(log n)
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class SortedArray1Set<Key> : ISet<Key> where Key : IComparable<Key>
    {
        private SortedArray1<Key> s;

        public bool IsEmpty => s.IsEmpty;
        public int Count => s.Count;
        public void Add(Key key)
        {
            s.Add(key);
        }

        public void Remove(Key key)
        {
            s.Remove(key);
        }

        public bool Contains(Key key)
        {
            return s.Contains(key);
        }
    }
}