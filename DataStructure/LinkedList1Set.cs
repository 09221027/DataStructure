namespace DataStructure
{
    /// <summary>
    /// 链表集合
    /// 连续查找
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkedList1Set<E> : ISet<E>
    {
        private LinkedList1<E> list;

        public bool IsEmpty => list.IsEmpty;
        public int Count => list.Count;
        public void Add(E e)
        {
            if (!list.Contains(e))
            {
                list.AddFirst(e);
            }
        }

        public void Remove(E e)
        {
            list.Remove(e);
        }

        public bool Contains(E e)
        {
            return list.Contains(e);
        }
    }
}