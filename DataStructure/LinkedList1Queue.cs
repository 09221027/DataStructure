namespace DataStructure
{
    /// <summary>
    /// 链表队列
    /// Enqueue O(n)
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkedList1Queue<E> : IQueue<E>
    {
        private LinkedList1<E> list;

        public LinkedList1Queue()
        {
            list = new LinkedList1<E>();
        }

        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;
        public void Enqueue(E e)
        {
            list.AddLast(e);
        }

        public E Dequeue()
        {
            return list.RemoveFirst();
        }

        public E Peek()
        {
            return list.GetFirst();
        }

        public override string ToString()
        {
            return "Queue front " + list + " tail";
        }
    }
}