namespace DataStructure
{
    /// <summary>
    /// 具备尾指针链表队列 √
    /// 全部为O(1)
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkedList2Queue<E> : IQueue<E>
    {
        private LinkedList2<E> list;

        public LinkedList2Queue()
        {
            list = new LinkedList2<E>();
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