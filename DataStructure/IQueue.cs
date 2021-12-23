namespace DataStructure
{
    /// <summary>
    /// 先入先出
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public interface IQueue<E>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Enqueue(E e);
        E Dequeue();
        E Peek();
    }
}