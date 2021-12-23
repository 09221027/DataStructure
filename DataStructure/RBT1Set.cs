using System;

namespace DataStructure
{
    /// <summary>
    /// 红黑树集合
    /// SortedSet
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class RBT1Set<E> :ISet<E> where E : IComparable<E>
    {
        private RBT1<E> rbt;
        public bool IsEmpty => rbt.IsEmpty;
        public int Count => rbt.Count;
        public void Add(E e)
        {
            rbt.Add(e);
        }

        public void Remove(E e)
        {
            throw new NotImplementedException();
        }

        public bool Contains(E e)
        {
            return rbt.Contains(e);
        }

        public int MaxHeight()
        {
            return rbt.MaxHeight();
        }
    }
}