namespace DataStructure
{
    /// <summary>
    /// 链表栈 √
    /// 全部为O(1)
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkedList1Stack<E> : IStack<E>
    {
        private LinkedList1<E> list;

        public LinkedList1Stack()
        {
            list = new LinkedList1<E>();
        }


        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;
        public void Push(E e)
        {
            list.AddFirst(e);
        }

        public E Pop()
        {
            return list.RemoveFirst();
        }

        public E Peek()
        {
            return list.GetFirst();
        }

        public override string ToString()
        {
            return "Stack: top" + list;
        }
    }
}