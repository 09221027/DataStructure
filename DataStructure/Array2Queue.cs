namespace DataStructure
{
    /// <summary>
    /// 循环数组队列 √
    /// Enqueue, Dequeue, Peek O(1)
    /// 系统提供Queue
    /// 基于循环数组
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Array2Queue<E> : IQueue<E>
    {
        private Array2<E> arr;

        public Array2Queue(int capacity)
        {
            arr = new Array2<E>(capacity);
        }

        public Array2Queue()
        {
            arr = new Array2<E>();
        }

        public int Count => arr.Count;
        public bool IsEmpty => arr.IsEmpty;
        public void Enqueue(E e)
        {
            arr.AddLast(e);
        }

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
            return "Queue: front " + arr + " tail";
        }
    }
}