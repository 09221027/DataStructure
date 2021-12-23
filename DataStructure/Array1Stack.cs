namespace DataStructure
{
    /// <summary>
    /// 动态数组栈 √
    /// 后入先出
    /// 全部为O(1)
    /// 系统提供Stack
    /// 基于动态数组
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class Array1Stack<E> : IStack<E>
    {
        private Array1<E> arr;

        public int Count => arr.Count;
        public bool IsEmpty => arr.IsEmpty;

        public Array1Stack(int capacity)
        {
            arr = new Array1<E>(capacity);
        }

        public Array1Stack()
        {
            arr = new Array1<E>();
        }

        public void Push(E e)
        {
            arr.AddLast(e);
        }

        public E Pop()
        {
            return arr.RemoveLast();
        }

        public E Peek()
        {
            return arr.GetLast();
        }

        public override string ToString()
        {
            return "Stack" + arr.ToString() + "top";
        }
    }
}