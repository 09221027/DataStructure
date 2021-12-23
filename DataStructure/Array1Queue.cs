namespace DataStructure
{
    /// <summary>
    /// 动态数组队列
    /// 先入先出
    /// Dequeue O(n)
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Array1Queue<E>:IQueue<E>
    {
        private Array1<E> arr;

        public Array1Queue(int capacity)
        {
            arr = new Array1<E>(capacity);
        }

        public Array1Queue()
        {
            arr = new Array1<E>();
        }

        public int Count => arr.Count;
        public bool IsEmpty => arr.IsEmpty;
        public void Enqueue(E e)
        {
            arr.AddLast(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public E Dequeue()
        {
            return arr.RemoveFirst();
        }

        public E Peek()
        {
            return arr.GetFirst();
        }

        public override string ToString()
        {
            return "Queue: front" + arr + "tail";
        }
    }
}